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

namespace JsonTestTool.Frame
{
    public partial class FrmPollingTest : Form
    {
        const string EXPAND = "展开节点";
        const string COLLAPSE = "收缩节点";
        HttpUtil htmlUtil = new HttpUtil();
        XmlDocument doc = new XmlDocument();
        private BackgroundWorker processBGWorker = new BackgroundWorker();
        private BtnRequestType requestType = BtnRequestType.POST;
        private string reportName = string.Empty;
        private int nodesCount = 0;
        private int nodeIndex = 0;
        private delegate string GetUrlOrData();
        private delegate void SetData(string postData);

        private enum BtnRequestType
        {
            POST,
            POSTUTF8,
            GET,
        }

        public struct TestResult
        {
            public bool isSucceesul;
            public string nodeName;
            public string reqStr;
            public string result;
        }

        public FrmPollingTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                processBGWorker.DoWork += ProcessBGWorker_DoWork;
                processBGWorker.WorkerReportsProgress = true;
                processBGWorker.ProgressChanged += ProcessBGWorker_ProgressChanged;
                processBGWorker.RunWorkerCompleted += ProcessBGWorker_RunWorkerCompleted;


                //显示默认的Log目录
                this.tb_LogPath.Text = Path.Combine(Application.StartupPath, "Logs");
                //默认加载程序平级目录Cases下的所有子目录和xml文件
                string caseUrl = Path.Combine(Application.StartupPath, "Cases1");
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
            reportName = string.Empty;
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
            this.lb_Process.Text = string.Format("测试进度：({0}/{1})", e.ProgressPercentage, nodesCount);

            string strForRTB = logStringCreator(e.ProgressPercentage, tr.result);

            string strForReport = reportLineCreator(e.ProgressPercentage, tr.nodeName, tr.isSucceesul,tr.reqStr,tr.result);
            this.rtb_Logs.Text += strForReport ;
            FileStream fs = new FileStream(Path.Combine(this.tb_LogPath.Text, reportName), System.IO.FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine(strForReport);
            sw.Close();
            fs.Close();
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
                bgWorker.ReportProgress(nodesCount, tr);
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
                            case BtnRequestType.POST:
                                postResult = htmlUtil.HttpPost(strUrl, postData);
                                break;
                            case BtnRequestType.POSTUTF8:
                                postResult = htmlUtil.HttpPostUTF8(strUrl, postData);
                                break;
                            case BtnRequestType.GET:
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
                        bgWorker.ReportProgress(nodeIndex,tr);
                    }
                    //bgWorker.ReportProgress(nodeIndex, temp);
                    Thread.Sleep(100);
                }
            }
            return tr;
        }

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
                    if (tv_Method.Nodes[0] != null)
                    {
                        tv_Method.TopNode = tv_Method.Nodes[0];
                        btn_Expand.Text = COLLAPSE;
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
            requestType = BtnRequestType.POST;
        }

        private void rbtn_POSTUTF8_CheckedChanged(object sender, EventArgs e)
        {
            requestType = BtnRequestType.POSTUTF8;
        }

        private void rbtn_GET_CheckedChanged(object sender, EventArgs e)
        {
            requestType = BtnRequestType.GET;
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

                reportName = string.Format("Report_{0}.csv", DateTime.Now.ToString("[MMddHH_mmssfff]"));
                if (!Directory.Exists(this.tb_LogPath.Text))
                {
                    Directory.CreateDirectory(this.tb_LogPath.Text);
                }
                if (!File.Exists(Path.Combine(this.tb_LogPath.Text, reportName)))
                {
                    File.Create(Path.Combine(this.tb_LogPath.Text, reportName)).Close();
                }
                using (StreamWriter sw = new StreamWriter(Path.Combine(this.tb_LogPath.Text, reportName), true, Encoding.UTF8))
                {
                    sw.WriteLine("编号,节点名称,测试时间,测试结果,测试请求,测试返回结果");
                    sw.Close();
                }

                this.rtb_Logs.Text = string.Empty;
                this.pbar_TestProcess.Maximum = nodesCount;
                this.processBGWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {

            }
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
                sb.AppendLine(string.Format(">>>{0}<<< 测试进度: ({1}/{2})", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), time, nodesCount));
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

        private string reportLineCreator(int time, string nodeName, bool isSucessful,string reqStr,string msg)
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                msg = msg.Replace("\"", "\"\"");
                if (msg.Contains(',') | msg.Contains('"') | msg.Contains('\r') | msg.Contains('\n'))
                {
                    msg = string.Format("\"{0}\"", msg);
                }
                //msg = msg.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(" ","");
                reqStr = reqStr.Replace("\"", "\"\"");
                if (reqStr.Contains(',') | reqStr.Contains('"') | reqStr.Contains('\r') | reqStr.Contains('\n'))
                {
                    reqStr = string.Format("\"{0}\"", reqStr);
                }
                //reqStr = reqStr.Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(" ", "");
                string sucessful = isSucessful ? "成功" : "失败";
                sb.Append(string.Format("{0},{1},{2},{3},{4},{5}", time, nodeName, DateTime.Now.ToString(), sucessful, reqStr, msg));
                return sb.ToString();
            }
            catch (Exception e)
            {
                return string.Format("Report生成出错，异常：{0}", e);
            }
        }

        private void btn_StopTest_Click(object sender, EventArgs e)
        {
            processBGWorker.WorkerSupportsCancellation = true;
            processBGWorker.CancelAsync();
        }
    }
}
