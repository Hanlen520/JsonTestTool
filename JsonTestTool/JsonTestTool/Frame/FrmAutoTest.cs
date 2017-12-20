using System;
using System.Windows.Forms;
using Util;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using JsonTestTool.Util;
using System.Text.RegularExpressions;

namespace JsonTestTool.Frame
{
    public partial class FrmAutoTest : Form
    {
        #region 字段属性
        const string EXPAND = "展开节点";
        const string COLLAPSE = "收缩节点";
        HttpUtil htmlUtil = new HttpUtil();
        XmlDocument doc = new XmlDocument();
        private BackgroundWorker processBGWorker = new BackgroundWorker();
        private RequestMode requestType = RequestMode.POST;
        private string reportFullPath = string.Empty;
        private int nodesCount = 0;
        private int nodeIndex = 0;
        private delegate string GetUrlOrData();
        private delegate void SetData(string url, string requestType, string postData);
        private delegate void SetMainFormTopMost(bool isTopMost);
        private Point m_frmCoordinate = new Point();

        private enum xmlElementType
        {
            isSSL,
            IP,
            Port,
            RequestType,
            RequestMode,
            RequestData,
            None,
        }
        /// <summary>
        /// 获取当前窗口的屏幕坐标
        /// </summary>
        private Point FrmCoordinate
        {
            get { return this.PointToScreen(this.Location); }
            set { this.m_frmCoordinate = value; }
        }


        //用于BackgroundWorkers传递测试结果
        public struct TestResult
        {
            public bool isSucceesul;    //测试是否成功
            public string nodeName;     //测试的节点
            public string reqUrl;   //测试的请求路径
            public string reqMode;  //测试的请求方式
            public string reqStr;       //测试的Json请求文本
            public string result;       //测试返回值(Json返回数据或者返回的异常)
        }
        #endregion

        #region  user32.dll
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(IntPtr classname, string title);
        [DllImport("user32.dll")]
        static extern IntPtr MoveWindow(IntPtr hwnd, int x, int y, int nWidth, int nHeigh, bool rePaint);
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowRect(IntPtr hwnd, out Rectangle rect);
        #endregion

        public FrmAutoTest()
        {
            InitializeComponent();
        }

        #region 事件
        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                //默认为不可操作，需要先选择请求文本之后，才可用
                //EnableRequestButton(false);
                this.gb_TargeServerInfo.Enabled = true;
                this.gb_CaseManager.Enabled = true;
                this.tv_Method.Enabled = true;
                processBGWorker.DoWork += ProcessBGWorker_DoWork;
                processBGWorker.WorkerReportsProgress = true;
                processBGWorker.ProgressChanged += ProcessBGWorker_ProgressChanged;
                processBGWorker.RunWorkerCompleted += ProcessBGWorker_RunWorkerCompleted;


                //显示默认的Log目录
                this.tb_LogPath.Text = Path.Combine(Application.StartupPath, "Reports");
                //默认加载程序平级目录Cases下的所有子目录和xml文件
                string caseUrl = Path.Combine(Application.StartupPath, "AutoCases");
                //显示Cases目录
                this.tb_CaseFolder.Text = caseUrl;
                //遍历并添加TreeView节点
                nodesCount = LoadFilesAndDirectoriesToTree(caseUrl, tv_Method.Nodes);
                //默认展开所有节点
                this.tv_Method.ExpandAll();
                if (tv_Method.Nodes.Count > 0)
                {
                    //首节点置顶
                    this.tv_Method.SelectedNode = tv_Method.Nodes[0];
                }
            }
            catch (Exception ee)
            {
                this.rtb_Data.Text = ee.Message;
            }
        }

        private void btn_Choose_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.Description = "请选择保存Case XML文件的目录";
                folderBrowserDialog1.ShowNewFolderButton = true;
                folderBrowserDialog1.SelectedPath = string.IsNullOrEmpty(this.tb_CaseFolder.Text) ? "请选择目录" : this.tb_CaseFolder.Text;
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.tb_CaseFolder.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                this.rtb_Logs.Text = "展开Folder失败。";
                this.rtb_Logs.Text += ex.ToString();
            }

        }

        private void btn_LoadTree_Click(object sender, EventArgs e)
        {
            this.tv_Method.Nodes.Clear();
            this.btn_Expand.Text = EXPAND;
            try
            {
                nodesCount = LoadFilesAndDirectoriesToTree(this.tb_CaseFolder.Text, this.tv_Method.Nodes);
            }
            catch (Exception es)
            {
                this.rtb_Data.Text = es.Message;
            }
        }

        private void btn_LogPathChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.SelectedPath = this.tb_LogPath.Text;
            path.ShowDialog();
            this.tb_LogPath.Text = path.SelectedPath;
        }

        private void btn_BeginTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.rtb_Logs.Text = string.Empty;
                this.pbar_TestProcess.Maximum = nodesCount;
                reportFullPath = Logger.CreateAutoReportCSV(this.tb_LogPath.Text);
                this.processBGWorker.RunWorkerAsync();
                EnableRequestButton(false);
                SetMainTop(true);
            }
            catch (ApplicationException aex)
            {
                DialogResult result;
                result = MessageBox.Show("Yes：关闭。No：取消", "Report文件创建失败，是否继续执行测试？", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.processBGWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                FindAndMoveMsgBox(FrmCoordinate.X, FrmCoordinate.Y, true, "测试无法开始");
                MessageBox.Show(ex.Message, "测试无法开始", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_StopTest_Click(object sender, EventArgs e)
        {
            EnableRequestButton(true);
            SetMainTop(false);
            processBGWorker.WorkerSupportsCancellation = true;
            processBGWorker.CancelAsync();
        }

        private void btn_LogPathOpen_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(this.tb_LogPath.Text))
                {
                    throw new DirectoryNotFoundException("报表目录为空，请选择目录后重试。");
                }
                else
                {
                    path = this.tb_LogPath.Text;
                }
                System.Diagnostics.Process.Start("Explorer.exe", path);
            }
            catch (DirectoryNotFoundException dnfEx)
            {
                FindAndMoveMsgBox(FrmCoordinate.X, FrmCoordinate.Y, true, "打开目录");
                MessageBox.Show(dnfEx.Message, "打开目录", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                FindAndMoveMsgBox(FrmCoordinate.X, FrmCoordinate.Y, true, "打开目录");
                MessageBox.Show(string.Format("打开目录失败。\r\n {0}", ex.Message), "打开目录", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GetScreenshots()
        {
            try
            {
                Bitmap bitmap = new Bitmap(this.Parent.Width, this.Parent.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(this.Parent.PointToScreen(Point.Empty), Point.Empty, Parent.Size);
                }
                bitmap.Save(Path.Combine(Application.StartupPath, string.Format("自动测试Screenshots{0}.jpg", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"))));
            }
            catch
            {

            }
        }
        #endregion

        #region BackgroundWorker 处理
        private void ProcessBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("停止测试。");
            }
            else
            {
                MessageBox.Show("测试完成。");
            }
            EnableRequestButton(true);
            SetMainTop(false);
            GetScreenshots();
            reportFullPath = string.Empty;
            nodeIndex = 0;
            nodesCount = 0;
        }

        private void ProcessBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TestResult tr = new TestResult();
            this.pbar_TestProcess.Value = e.ProgressPercentage;
            string message = string.Empty;
            if (e.UserState != null)
            {
                tr = (TestResult)e.UserState;
            }
            if (e.ProgressPercentage > 0)
            {
                this.lb_Process.Text = string.Format("测试进度：({0}/{1})", e.ProgressPercentage, nodesCount);

                string strForRTB = LogStringCreator(e.ProgressPercentage, tr.result);
                this.rtb_Logs.Text += strForRTB;

                string strForReport = ReportLineCreator(e.ProgressPercentage, tr);
                Logger.WriteReport(reportFullPath, strForReport);
            }
            else
            {
                this.lb_Process.Text = string.Format("测试进度：({0}/{1})", nodesCount, nodesCount);
                this.rtb_Logs.Text += "测试结束！";

                Logger.WriteReport(reportFullPath, "All Done!!!");
            }
            this.rtb_Logs.Focus();//让文本框获取焦点   
            this.rtb_Logs.Select(this.rtb_Logs.TextLength, 0);//设置光标的位置到文本尾  
            this.rtb_Logs.ScrollToCaret();//滚动到控件光标处
            if (this.cb_Scrrenshots.Checked)
            {
                this.pbar_TestProcess.Update();
                this.rtb_Logs.Update();
                GetScreenshots();
            }
        }

        private void ProcessBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            TestResult tr = new TestResult();
            tr.nodeName = "--";
            try
            {
                TraverseTreeView(this.tv_Method.Nodes, sender, e);
            }
            catch (Exception ex)
            {
                tr.isSucceesul = false;
                tr.result = ex.Message;
                bgWorker.ReportProgress(nodesCount, tr);
            }
            e.Result = tr;
        }

        private TestResult TraverseTreeView(TreeNodeCollection nodes, object sender, DoWorkEventArgs e)
        {
            TestResult tr = new TestResult();
            string reqFullUrl = string.Empty;
            string postData = string.Empty;
            string postResult = string.Empty;
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            tr.isSucceesul = true;
            foreach (TreeNode node in nodes)
            {
                tr.nodeName = Path.GetFileNameWithoutExtension(node.Name);
                if (bgWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                nodeIndex++;
                if (string.IsNullOrEmpty(node.Name))
                {
                    tr.reqStr = "父节点无请求文本";
                    tr.nodeName = node.Name;
                    tr.reqUrl = "空";
                    tr.reqMode = "空";
                    tr.result = "空";
                    bgWorker.ReportProgress(nodeIndex, tr);
                    Thread.Sleep(100);
                    TraverseTreeView(node.Nodes, sender, e);
                }
                else
                {
                    //加载测试用例XML文件
                    doc.Load(node.Name);
                    tr.nodeName = Path.GetFileNameWithoutExtension(node.Name);
                    if (doc.DocumentElement != null)
                    {
                        string parseResult = ParseXmlValidity(doc);
                        string headerStr = ParseXml(doc, xmlElementType.isSSL);
                        string ipStr = ParseXml(doc, xmlElementType.IP).Trim('/');
                        string portStr = ParseXml(doc, xmlElementType.Port).Trim('/');
                        string reqTypeStr = ParseXml(doc, xmlElementType.RequestType).Trim('/');
                        string regUrl = string.Format("{0}{1}/{2}", headerStr, ipStr, portStr);
                        string reqModeStr = Enum.ToObject(typeof(RequestMode), Convert.ToInt32(ParseXml(doc, xmlElementType.RequestMode))).ToString();
                        reqFullUrl = string.Format("{0}/{1}", regUrl, reqTypeStr);
                        tr.reqUrl = reqFullUrl;
                        tr.reqMode = reqModeStr;
                        postData = ParseXml(doc, xmlElementType.RequestData);
                        tr.reqStr = postData;
                        //更新主窗体内容
                        SetDataToMainForm(regUrl, reqModeStr, postData);
                        //XML文件合法性检查
                        if (!string.IsNullOrEmpty(parseResult))
                        {
                            tr.result = parseResult;
                            tr.reqUrl = string.Empty;
                            tr.isSucceesul = false;
                            bgWorker.ReportProgress(nodeIndex, tr);
                        }
                        else
                        {
                            try
                            {
                                switch (requestType)
                                {
                                    case RequestMode.POST:
                                        postResult = htmlUtil.HttpPost(reqFullUrl, postData);
                                        break;
                                    case RequestMode.POSTUTF8:
                                        postResult = htmlUtil.HttpPostUTF8(reqFullUrl, postData);
                                        break;
                                    case RequestMode.GET:
                                        postResult = htmlUtil.HttpGet(reqFullUrl, postData);
                                        break;
                                    default:
                                        break;
                                }
                                tr.result = postResult;
                                bgWorker.ReportProgress(nodeIndex, tr);
                            }
                            catch (Exception reqEX)
                            {
                                tr.isSucceesul = false;
                                tr.result = reqEX.Message;
                                bgWorker.ReportProgress(nodeIndex, tr);
                            }
                        }
                    }
                }
                Thread.Sleep(100);
            }
            return tr;
        }
        #endregion

        #region 控件处理
        /// <summary>
        /// 遍历指定目录，获取所有下级文件夹和XML文件
        /// </summary>
        /// <param name="path">指定目录全路径</param>
        /// <param name="treeNodeCollection">TreeView节点集合</param>
        private int LoadFilesAndDirectoriesToTree(string path, TreeNodeCollection treeNodeCollection)
        {
            int count = 0;
            //1.先根据路径获取所有的子文件和子文件夹
            var files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".xml"));
            string[] dirs = Directory.GetDirectories(path);
            //2.把所有的子文件与子目录加到TreeView上。
            foreach (string item in files)
            {
                count++;
                TreeNode node = new TreeNode(item);
                //这里存储的是全路径
                node.Name = item;
                //存储的是文件名
                node.Text = Path.GetFileNameWithoutExtension(item);
                //把文件节点加到TreeView上
                treeNodeCollection.Add(node);
            }
            //文件夹
            foreach (string item in dirs)
            {
                count++;
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));
                //由于目录，可能下面还存在子目录，所以这时要对每个目录再次进行获取子目录与子文件的操作
                count += LoadFilesAndDirectoriesToTree(item, node.Nodes);
            }
            return count;
        }

        private void tv_Method_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;//指向展开的图标
        }

        private void tv_Method_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;//指向关闭的图标
        }

        private void tv_Method_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.tb_Url.Text = string.Empty;
            this.cb_Request.Text = string.Empty;
            this.rtb_Data.Text = string.Empty;
            //通过判断子节点的方式，来判断是否处理XML
            if (e.Node.Nodes.Count == 0)
            {
                try
                {
                    //通过节点获得XML路径
                    doc.Load(e.Node.Name);
                    if (doc.DocumentElement != null)
                    {
                        string headerStr = ParseXml(doc, xmlElementType.isSSL);
                        string ipStr = ParseXml(doc, xmlElementType.IP).Trim('/');
                        string portStr = ParseXml(doc, xmlElementType.Port).Trim('/');
                        string reqTypeStr = ParseXml(doc, xmlElementType.RequestType).Trim('/');
                        this.tb_Url.Text = string.Format("{0}{1}/{2}/", headerStr, ipStr, portStr);
                        this.cb_Request.Text = reqTypeStr;
                        this.tb_RequestMode.Text = Enum.ToObject(typeof(RequestMode), Convert.ToInt32(ParseXml(doc, xmlElementType.RequestMode))).ToString();
                        this.rtb_Data.Text = ParseXml(doc, xmlElementType.RequestData);
                        //XML文件格式检查
                        string parseResult = ParseXmlValidity(doc);
                        if (!string.IsNullOrEmpty(parseResult))
                        {
                            throw new XmlException(parseResult);
                        }
                    }
                }
                catch (FileNotFoundException fnfe)
                {
                    this.rtb_Data.Text = string.Format("加载XML出现异常，请检查路径({0})文件是否存在.{1}", e.Node.Name, fnfe.Message);
                }
                catch (XmlException xml)
                {
                    this.rtb_Data.Text = string.Format("XML文件合法性检查未通过,原因如下.\r\n{0}", xml.Message);
                }
                catch (Exception exc)
                {
                    this.rtb_Data.Text = string.Format("加载XML出现异常", exc.ToString());
                }
            }
            else
            {
                this.rtb_Data.Text = string.Format("【{0}】为父节点，请选择子节点获取Json请求模板。", e.Node.Text);
            }
        }

        /// <summary>
        /// 选中TreeView节点,返回相应的请求数据并更新至RichTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Expand_Click(object sender, EventArgs e)
        {
            object locker = new object();
            lock (locker)
            {
                if (string.Equals(this.btn_Expand.Text, COLLAPSE))
                {
                    tv_Method.CollapseAll();
                    btn_Expand.Text = EXPAND;
                }
                else if (string.Equals(this.btn_Expand.Text, EXPAND))
                {
                    tv_Method.ExpandAll();
                    if (tv_Method.Nodes.Count > 0)
                    {
                        if (tv_Method.Nodes[0] != null)
                        {
                            tv_Method.TopNode = tv_Method.Nodes[0];
                            btn_Expand.Text = COLLAPSE;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 为控件显示ToolsTips
        /// </summary>
        /// <param name="sender">控件对象</param>
        /// <param name="str">ToolTips显示的内容</param>
        private void ShowToolTipMouseEnter(object sender, string str)
        {
            ToolTip tt = new ToolTip();
            tt.ShowAlways = true;
            tt.SetToolTip((Control)sender, str);
        }

        private void btn_Expand_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipMouseEnter(sender, "收缩或展开下方目录树。");
        }

        private void Tb_IP_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipMouseEnter(sender, "测试服务器的IP地址");
        }

        /// <summary>
        /// 控制MessageBox的弹出位置
        /// </summary>
        /// <param name="x">新的x坐标</param>
        /// <param name="y">新的y坐标</param>
        /// <param name="rePaint">是否重绘</param>
        /// <param name="title">MessageBox的Title</param>
        private void FindAndMoveMsgBox(int x, int y, bool rePaint, string title)
        {
            ThreadPool.QueueUserWorkItem(a =>
            {
                IntPtr msgBox = IntPtr.Zero;
                while ((msgBox = FindWindow(IntPtr.Zero, title)) == IntPtr.Zero) ;
                Rectangle r = new Rectangle();
                GetWindowRect(msgBox, out r);
                //取父窗体的大小取中间范围
                int xx = x + (this.Width - r.Width + r.X) / 2;
                int yy = y + (this.Height - r.Height + r.Y) / 2;
                MoveWindow(msgBox, xx, yy, r.Width - r.X, r.Height - r.Y, rePaint);
            }, null);
        }

        /// <summary>
        /// 控件Enable控制逻辑，在测试期间Disabled一部分输入控件
        /// </summary>
        /// <param name="isEnable"></param>
        private void EnableRequestButton(bool isEnable)
        {
            if (isEnable)
            {
                this.gb_TargeServerInfo.Enabled = true;
                this.gb_CaseManager.Enabled = true;
                this.btn_BeginTest.Enabled = true;
                this.btn_StopTest.Enabled = false;
                this.tv_Method.Enabled = true;
            }
            else
            {
                this.gb_TargeServerInfo.Enabled = false;
                this.gb_CaseManager.Enabled = false;
                this.btn_BeginTest.Enabled = false;
                this.btn_StopTest.Enabled = true;
                this.tv_Method.Enabled = false;
            }
        }
        #endregion

        #region 字符串处理
        private string GetUrlString()
        {
            string strUrl = string.Empty;
            try
            {
                Uri uri = new Uri(new Uri(this.tb_Url.Text + "/"), this.cb_Request.SelectedItem.ToString());
                strUrl = uri.OriginalString;
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("Url不合法，请检查输入项。\r\n{0}", ex.Message);
            }
            return strUrl;
        }

        private string GetUrlFromMain()
        {
            string temp = string.Empty;
            if (this.InvokeRequired)
            {
                GetUrlOrData guod = new GetUrlOrData(GetUrlFromMain);
                return this.Invoke(guod).ToString();
            }
            else
            {
                return this.GetUrlString();
            }
        }

        private void SetMainTop(bool isTopMost)
        {
            string temp = string.Empty;
            if (this.InvokeRequired)
            {
                SetMainFormTopMost guod = new SetMainFormTopMost(SetMainTop);
                this.Invoke(guod);
            }
            else
            {
                this.ParentForm.TopMost = isTopMost;
            }
        }

        private string GetDataFromMain()
        {
            string temp = string.Empty;
            if (this.InvokeRequired)
            {
                GetUrlOrData guod = new GetUrlOrData(GetDataFromMain);
                return this.Invoke(guod).ToString();
            }
            else
            {
                return this.rtb_Data.Text;
            }
        }

        private void SetDataToMainForm(string url, string requestType, string msg)
        {
            if (this.InvokeRequired)
            {
                SetData setD = new SetData(SetDataToMainForm);
                this.Invoke(setD, new object[] { url, requestType, msg });
            }
            else
            {
                this.tb_Url.Text = url;
                this.cb_Request.Text = requestType;
                this.rtb_Data.Text = msg;
            }
        }

        private string LogStringCreator(int time, string msg)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("{0} 测试进度: ({1}/{2})", DateTime.Now.ToString("MM-dd HH:mm:ss,fff"), time, nodesCount));
                sb.AppendLine(string.Format("请求路径为:{0}", GetUrlFromMain()));
                sb.AppendLine(string.Format("Json请求为:{0}", requestType.ToString()));
                sb.AppendLine(string.Format("返回结果：{0}", msg));
                return sb.ToString();
            }
            catch (Exception e)
            {
                return string.Format("日志生成出错，异常：{0}", e);
            }
        }

        private string ReportLineCreator(int time, TestResult tr)
        {
            try
            {
                string msg = tr.result;
                string reqStr = tr.reqStr;
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(msg))
                {
                    msg = msg.Replace("\"", "\"\"");
                    if (msg.Contains(',') | msg.Contains('"') | msg.Contains('\r') | msg.Contains('\n'))
                    {
                        msg = string.Format("\"{0}\"", msg);
                    }
                }
                if (!string.IsNullOrEmpty(reqStr))
                {
                    reqStr = reqStr.Replace("\"", "\"\"");
                    if (reqStr.Contains(',') | reqStr.Contains('"') | reqStr.Contains('\r') | reqStr.Contains('\n'))
                    {
                        reqStr = string.Format("\"{0}\"", reqStr);
                    }
                }
                string sucessful = tr.isSucceesul ? "成功" : "失败";
                string strTime = DateTime.Now.ToString();
                sb.Append(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", time, tr.nodeName, strTime, tr.reqUrl, tr.reqMode, sucessful, reqStr, msg));
                return sb.ToString();
            }
            catch (Exception e)
            {
                return string.Format("Report生成出错，异常：{0}", e);
            }
        }

        private string ParseXml(XmlDocument doc, xmlElementType xeType)
        {
            string tempStr = string.Empty;
            XmlNode node = null;
            try
            {
                if (doc.DocumentElement != null)
                {
                    switch (xeType)
                    {
                        case xmlElementType.isSSL:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            tempStr = (0 == Convert.ToInt32(node.InnerXml)) ? "http://" : "https://";
                            break;
                        case xmlElementType.IP:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            string regIP = @"^(?:(?:1[0-9][0-9]\.)|(?:2[0-4][0-9]\.)|(?:25[0-5]\.)|(?:[1-9][0-9]\.)|(?:[0-9]\.)){3}(?:(?:1[0-9][0-9])|(?:2[0-4][0-9])|(?:25[0-5])|(?:[1-9][0-9])|(?:[0-9]))$";
                            if (Regex.IsMatch(node.InnerXml, regIP))
                            {
                                tempStr = node.InnerXml;
                            }
                            else
                            {
                                tempStr = "错误的IP";
                            }
                            break;
                        case xmlElementType.Port:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            string regPort = @"^([0-9]|[1-9]\d{1}|[1-9]\d{2}|[1-9]\d{3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5])$";
                            if (Regex.IsMatch(node.InnerXml, regPort))
                            {
                                tempStr = node.InnerXml;
                            }
                            else
                            {
                                tempStr = "错误的端口号";
                            }
                            break;
                        case xmlElementType.RequestType:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            tempStr = node.InnerXml;
                            break;
                        case xmlElementType.RequestMode:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            tempStr = node.InnerXml;
                            break;
                        case xmlElementType.RequestData:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            tempStr = JsonConvert.SerializeXmlNode(node, Newtonsoft.Json.Formatting.Indented, true);
                            break;
                        case xmlElementType.None:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (NullReferenceException)
            {
                tempStr = string.Format("元素不存在。");
            }
            catch (Exception ex)
            {
                tempStr = ex.Message;
            }
            return tempStr;
        }

        private string ParseXmlValidity(XmlDocument doc)
        {
            //记录三轮检查结果
            string tempStr1 = string.Empty;
            string tempStr2 = string.Empty;
            string tempStr3 = string.Empty;
            XmlNode node = null;
            int flag = 0;
            XmlNodeList oList = doc.DocumentElement.ChildNodes;
            xmlElementType xeType = xmlElementType.None;
            //元素不合法标记,用于检查元素是否完整
            List<string> elementTypes = new List<string>() { "isSSL", "IP", "Port", "RequestType", "RequestMode", "RequestData" };
            //遍历检查元素是否都是合法元素
            foreach (XmlNode temp in oList)
            {
                if (!Enum.TryParse(temp.Name, out xeType))
                {
                    tempStr1 += temp.Name.ToLower() + ",";
                    flag++;
                }
                else
                {
                    //如果元素合法,删除不合法标记
                    elementTypes.Remove(temp.Name);
                    //检查合法元素的内容是否是正确格式
                    switch (xeType)
                    {
                        case xmlElementType.isSSL:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            tempStr3 += ((0 == Convert.ToInt32(node.InnerXml)) || (1 == Convert.ToInt32(node.InnerXml))) ? "" : string.Format("[{0}:{1}]\r\n", xeType.ToString(), node.InnerXml);
                            break;
                        case xmlElementType.IP:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            string regIP = @"^(?:(?:1[0-9][0-9]\.)|(?:2[0-4][0-9]\.)|(?:25[0-5]\.)|(?:[1-9][0-9]\.)|(?:[0-9]\.)){3}(?:(?:1[0-9][0-9])|(?:2[0-4][0-9])|(?:25[0-5])|(?:[1-9][0-9])|(?:[0-9]))$";
                            if (!Regex.IsMatch(node.InnerXml, regIP))
                            {
                                tempStr3 += string.Format("[{0}:{1}]\r\n", xeType.ToString(), node.InnerXml);
                            }
                            break;
                        case xmlElementType.Port:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            string regPort = @"^([0-9]|[1-9]\d{1}|[1-9]\d{2}|[1-9]\d{3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5])$";
                            if (!Regex.IsMatch(node.InnerXml, regPort))
                            {
                                tempStr3 += string.Format("[{0}:{1}]\r\n", xeType.ToString(), node.InnerXml);
                            }
                            break;
                        case xmlElementType.RequestMode:
                            node = doc.DocumentElement.SelectSingleNode(xeType.ToString());
                            tempStr3 += (Convert.ToInt32(node.InnerXml) >= 1 || (Convert.ToInt32(node.InnerXml) <= 3)) ? "" : string.Format("[{0}:{1}]\r\n", xeType.ToString(), node.InnerXml);
                            break;
                        case xmlElementType.RequestData:
                        case xmlElementType.RequestType:
                        case xmlElementType.None:
                            break;
                        default:
                            break;
                    }
                }
            }
            //经过三轮检查,如果XML文件有异常刚返回Error信息
            if (elementTypes.Count > 0 || flag > 0 || !string.IsNullOrEmpty(tempStr3))
            {
                string xmlError = string.Empty;
                if (elementTypes.Count > 0)
                {
                    foreach (string item in elementTypes)
                    {
                        tempStr2 += item + ',';
                    }
                    xmlError += string.Format("缺失必要节点: \r\n{0}\r\n", tempStr2.Trim(','));

                }
                if (flag > 0)
                {
                    xmlError += string.Format("名称不合法节点: \r\n{0}\r\n", tempStr1.Trim(','));
                }
                if (!string.IsNullOrEmpty(tempStr3))
                {
                    xmlError += string.Format("格式不正确的节点:\r\n{0}\r\n", tempStr3);
                }
                return xmlError;
            }
            return tempStr1;
        }
        #endregion
    }
}
