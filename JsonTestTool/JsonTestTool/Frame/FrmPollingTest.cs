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

namespace JsonTestTool.Frame
{
    public partial class FrmPollingTest : Form
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
        private delegate void SetData(string postData);
        private Point m_frmCoordinate = new Point();

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

        public FrmPollingTest()
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
                this.gb_RequestMode.Enabled = true;
                this.gb_CaseManager.Enabled = true;
                this.tv_Method.Enabled = true;
                processBGWorker.DoWork += ProcessBGWorker_DoWork;
                processBGWorker.WorkerReportsProgress = true;
                processBGWorker.ProgressChanged += ProcessBGWorker_ProgressChanged;
                processBGWorker.RunWorkerCompleted += ProcessBGWorker_RunWorkerCompleted;


                //显示默认的Log目录
                this.tb_LogPath.Text = Path.Combine(Application.StartupPath, "Reports");
                //默认加载程序平级目录Cases下的所有子目录和xml文件
                string caseUrl = Path.Combine(Application.StartupPath, "Cases");
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

        private void rbtn_POST_CheckedChanged(object sender, EventArgs e)
        {
            requestType = RequestMode.POST;
        }

        private void rbtn_POSTUTF8_CheckedChanged(object sender, EventArgs e)
        {
            requestType = RequestMode.POSTUTF8;
        }

        private void rbtn_GET_CheckedChanged(object sender, EventArgs e)
        {
            requestType = RequestMode.GET;
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
                reportFullPath = Logger.CreateReportCSV(this.tb_LogPath.Text);
                this.processBGWorker.RunWorkerAsync();
                EnableRequestButton(false);
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

                string strForRTB = logStringCreator(e.ProgressPercentage, tr.result);
                this.rtb_Logs.Text += strForRTB;

                string strForReport = reportLineCreator(e.ProgressPercentage, tr.nodeName, tr.isSucceesul, tr.reqStr, tr.result);
                Logger.WriteReport(reportFullPath, strForReport);
            }
            else
            {
                this.lb_Process.Text = string.Format("测试进度：({0}/{1})", nodesCount, nodesCount);
                this.rtb_Logs.Text += "测试结束！";
                
                Logger.WriteReport(reportFullPath, "All Done!!!");
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
                tr.isSucceesul = true;
                tr.result = "测试结束！！！";
                bgWorker.ReportProgress(0, tr);
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
            string strUrl = GetUrlFromMain();
            string postData = string.Empty;
            string postResult = string.Empty;
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            tr.isSucceesul = true;
            foreach (TreeNode node in nodes)
            {
                tr.nodeName = Path.GetFileName(node.Text);
                if (bgWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                nodeIndex++;
                if (string.IsNullOrEmpty(node.Name))
                {
                    tr.reqStr = "父节点无请求文本。";
                    tr.result = "空";
                    bgWorker.ReportProgress(nodeIndex, tr);
                    Thread.Sleep(100);
                    TraverseTreeView(node.Nodes, sender, e);
                }
                else
                {
                    doc.Load(node.Name);
                    if (doc.DocumentElement != null)
                    {
                        postData = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);
                        SetDataToRTB(postData);
                    }
                    tr.reqStr = postData;
                    tr.nodeName = Path.GetFileName(node.Text);
                    try
                    {
                        switch (requestType)
                        {
                            case RequestMode.POST:
                                postResult = htmlUtil.HttpPost(strUrl, postData);
                                break;
                            case RequestMode.POSTUTF8:
                                postResult = htmlUtil.HttpPostUTF8(strUrl, postData);
                                break;
                            case RequestMode.GET:
                                postResult = htmlUtil.HttpGet(strUrl, postData);
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
                    //bgWorker.ReportProgress(nodeIndex, temp);
                    Thread.Sleep(100);
                }
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
            //通过判断子节点的方式，来判断是否处理XML
            if (e.Node.Nodes.Count == 0)
            {
                try
                {
                    //通过节点获得XML路径
                    doc.Load(e.Node.Name);
                    if (doc.DocumentElement != null)
                    {
                        this.rtb_Data.Text = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);
                    }
                }
                catch (FileNotFoundException fnfe)
                {
                    this.rtb_Data.Text = string.Format("加载XML出现异常，请检查路径({0})文件是否存在.{1}", e.Node.Name, fnfe.Message);
                }
                catch (XmlException xml)
                {
                    this.rtb_Data.Text = string.Format("XML文件不合法。{0}", xml.Message);
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

        private void btb_SaveNodesToXml_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipMouseEnter(sender, "保存左侧目录树所有内容为Xml文件至自定义路径。");
        }

        private void btn_Expand_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipMouseEnter(sender, "收缩或展开左侧目录树。");
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
                this.gb_RequestMode.Enabled = true;
                this.gb_CaseManager.Enabled = true;
                this.btn_BeginTest.Enabled = true;
                this.btn_StopTest.Enabled = false;
                this.tv_Method.Enabled = true;
            }
            else
            {
                this.gb_TargeServerInfo.Enabled = false;
                this.gb_RequestMode.Enabled = false;
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
                Uri uri = new Uri(new Uri("http://" + this.Tb_IP.Text + ":" + this.Tb_Port.Text + "/"), this.cb_Request.SelectedItem.ToString());
                strUrl = uri.OriginalString;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Url不合法，请检查输入项。\r\n{0}", ex.Message);
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

        private void SetDataToRTB(string msg)
        {
            if (this.InvokeRequired)
            {
                SetData setD = new SetData(SetDataToRTB);
                this.Invoke(setD, new object[] { msg });
            }
            else
            {
                this.rtb_Data.Text = msg;
            }
        }

        private string logStringCreator(int time, string msg)
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

        private string reportLineCreator(int time, string nodeName, bool isSucessful, string reqStr, string msg)
        {
            try
            {
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
                string sucessful = isSucessful ? "成功" : "失败";
                string strTime = DateTime.Now.ToString();
                sb.Append(string.Format("{0},{1},{2},{3},{4},{5}", time, nodeName, strTime, sucessful, reqStr, msg));
                return sb.ToString();
            }
            catch (Exception e)
            {
                return string.Format("Report生成出错，异常：{0}", e);
            }
        }

        #endregion
    }
}
