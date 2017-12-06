using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Util;
using System.Threading;
using JsonTestClient.Util;
using System.IO;

namespace JsonTestTool.Frame
{
    public partial class FrmPerformentTest : Form
    {
        HttpUtil htmlUtil = new HttpUtil();
        XmlDocument doc = new XmlDocument();
        private BackgroundWorker processBGWorker = new BackgroundWorker();
        private BtnRequestType requestType = BtnRequestType.POST;
        private string logName = string.Empty;
        private delegate string GetUrlOrData();
        private delegate int GetInterval();
        private enum BtnRequestType
        {
            POST,
            POSTUTF8,
            GET,
        }

        public FrmPerformentTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                //默认为不可操作，需要先选择请求文本之后，才可用
                EnableRequestButton(false);
                string caseUrl = Path.Combine(Application.StartupPath,"Logs");
                //显示Cases目录
                this.tb_LogPath.Text = caseUrl;

                //不能省略，默认加载之后为了确保必选项选中，界面会有控件灰显逻辑，
                //这部分在首次加载时不能灰显
                this.tv_Method.Enabled = true;
                this.gb_TargetServer.Enabled = true;
                this.gb_RequestType.Enabled = true;
                this.gb_TestRequirements.Enabled = true;
                //后台更新进程
                processBGWorker.DoWork += ProcessBGWorker_DoWork;
                processBGWorker.WorkerReportsProgress = true;
                processBGWorker.ProgressChanged += ProcessBGWorker_ProgressChanged;
                processBGWorker.RunWorkerCompleted += ProcessBGWorker_RunWorkerCompleted;
                //加载目录树
                this.tv_Method.ExpandAll();
                doc.Load("PerformanceTreeXml.xml");
                //doc.Load(Properties.Resources.TreeXml); 
                RecursionTreeControl(doc.DocumentElement, tv_Method.Nodes);//将加载完成的XML文件显示在TreeView控件
                tv_Method.ExpandAll();
                if (tv_Method.Nodes[0] != null)
                {
                    tv_Method.TopNode = tv_Method.Nodes[0];
                }
            }
            catch (Exception ex)
            {
                this.rtb_Data.Text = ex.ToString();
            }
        }

        private void ProcessBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                MessageBox.Show("Cancel.");
            }
            else
            {
                //避免取消操作后，出现两个MessageBox
                MessageBox.Show("Done.");

            }
            //测试结束后，把LogName置为空。
            logName = string.Empty;
            EnableRequestButton(true);
        }

        private void ProcessBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbar_TestProcess.Value = e.ProgressPercentage;
            string message = string.Empty;
            if (e.UserState!=null)
            {
                message = e.UserState.ToString();
            }
            this.rtb_ACK.Text += message;
            this.lb_Process.Text = string.Format("测试进度:({0}/{1})", e.ProgressPercentage, this.pbar_TestProcess.Maximum);
            if (File.Exists(Path.Combine(this.tb_LogPath.Text, logName)))
            {
                using (StreamWriter writer = File.AppendText(Path.Combine(this.tb_LogPath.Text, logName)))
                {
                    writer.WriteAsync(message);
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        private void ProcessBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            string temp = string.Empty;
            int endNumber = 0;
            try
            {
                //耗时
                if (e.Argument != null)
                {
                    Dictionary<decimal, BtnRequestType> tempDic = (Dictionary<decimal, BtnRequestType>)e.Argument;
                    if (tempDic.Count > 0)
                    {
                        decimal key = tempDic.Keys.First<decimal>();
                        BtnRequestType type = tempDic[key];
                        endNumber = Convert.ToInt32(key);
                    }
                }
                for (int i = 1; i <= endNumber; i++)
                {
                    if (bgWorker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    try
                    {
                        string strUrl = GetUrlFromForm();
                        string postdata = GetDataFromForm();
                        int interval = GetIntervalFromForm();
                        switch (requestType)
                        {
                            case BtnRequestType.POST:
                                temp = htmlUtil.HttpPost(strUrl, postdata);
                                break;
                            case BtnRequestType.POSTUTF8:
                                temp = htmlUtil.HttpPostUTF8(strUrl, postdata);
                                break;
                            case BtnRequestType.GET:
                                temp = htmlUtil.HttpGet(strUrl, postdata);
                                break;
                            default:
                                break;
                        }
                        bgWorker.ReportProgress(i, logStringCreator(i,temp));
                        Thread.Sleep(interval);
                    }
                    catch (System.Exception ex)
                    {
                        bgWorker.ReportProgress(i, ex.ToString());
                    }
                }
                temp = "Completed！！！";
                bgWorker.ReportProgress(endNumber,temp);
                e.Result = "";
            }
            catch (System.Exception ex)
            {
                bgWorker.ReportProgress(0,ex.ToString());
            }
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
            if (e.Node.Nodes.Count == 0)
            {
                updateDateToRTB(e.Node.Name);
            }
            else
            {
                this.rtb_Data.Text = string.Format("请选择【{0}】的子节点获取请求Json模板。", e.Node.Text);
            }
        }

        private void Tb_IP_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTipMouseEnter(sender, "测试服务器的IP地址");
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

        private void updateDateToRTB(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (Enum.IsDefined(typeof(JsonMethodType),type))
                {
                    this.rtb_Data.Text = htmlUtil.JsonStringCreator(type);
                }
            }
        }

        /// <summary>
        /// RecursionTreeControl:表示将XML文件的内容显示在TreeView控件中
        /// </summary>
        /// <param name="xmlNode">将要加载的XML文件中的节点元素</param>
        /// <param name="nodes">将要加载的XML文件中的节点集合</param>
        private void RecursionTreeControl(XmlNode xmlNode, TreeNodeCollection nodes)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)//循环遍历当前元素的子元素集合
            {
                TreeNode new_child = new TreeNode();//定义一个TreeNode节点对象
                new_child.Name = node.Attributes["Name"].Value;
                new_child.Text = node.Attributes["Text"].Value;
                nodes.Add(new_child);//向当前TreeNodeCollection集合中添加当前节点
                RecursionTreeControl(node, new_child.Nodes);//调用本方法进行递归
            }
        }

        private void btn_LogPathChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.SelectedPath = this.tb_LogPath.Text;
            path.ShowDialog();
            this.tb_LogPath.Text = path.SelectedPath;
        }

        private void rtb_Data_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtBox = sender as RichTextBox;
            if(!string.IsNullOrEmpty(rtBox.Text))
            {
                EnableRequestButton(true);
            }
            else
            {
                EnableRequestButton(false);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            processBGWorker.WorkerSupportsCancellation = true;
            processBGWorker.CancelAsync();
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            //
            EnableRequestButton(false);
            logName = string.Format("Log({0}).txt",DateTime.Now.ToString("[MM-dd-HH]#[mm-ss-fff]"));
            if (!Directory.Exists(this.tb_LogPath.Text))
            {
                Directory.CreateDirectory(this.tb_LogPath.Text);
            }
            if (!File.Exists(Path.Combine(this.tb_LogPath.Text,logName)))
            {
                File.Create(Path.Combine(this.tb_LogPath.Text,logName)).Close();
            }
            try
            {
                this.rtb_ACK.Text = string.Empty;
                this.pbar_TestProcess.Maximum = Convert.ToInt32(this.nud_Count.Value);
                Dictionary<decimal, BtnRequestType> ee = new Dictionary<decimal, BtnRequestType>();
                switch (requestType)
                {
                    case BtnRequestType.POST:
                        ee.Add(this.nud_Count.Value, BtnRequestType.POST);
                        break;
                    case BtnRequestType.POSTUTF8:
                        ee.Add(this.nud_Count.Value, BtnRequestType.POSTUTF8);
                        break;
                    case BtnRequestType.GET:
                        ee.Add(this.nud_Count.Value, BtnRequestType.GET);
                        break;
                    default:
                        break;
                }
                this.processBGWorker.RunWorkerAsync(ee);                       
            }
            catch (System.Exception ex)
            {
                updateDateToRTB(ex.Message);
            }
        }

        private void rb_POST_CheckedChanged(object sender, EventArgs e)
        {
            requestType = BtnRequestType.POST;
        }

        private void rb_POST_UTF8_CheckedChanged(object sender, EventArgs e)
        {
            requestType = BtnRequestType.POSTUTF8;
        }

        private void rb_GET_CheckedChanged(object sender, EventArgs e)
        {
            requestType = BtnRequestType.GET;
        }

        private string GetUrlFromForm()
        {
            string temp = string.Empty;
            if (this.InvokeRequired)
            {
                GetUrlOrData setpos = new GetUrlOrData(GetUrlFromForm);
                return this.Invoke(setpos).ToString();
            }
            else
            {
                return this.GetUrlString();
            }
        }

        private string GetDataFromForm()
        {
            string temp = string.Empty;
            if (this.InvokeRequired)
            {
                GetUrlOrData setpos = new GetUrlOrData(GetDataFromForm);
                return this.Invoke(setpos).ToString();
            }
            else
            {
                return this.rtb_Data.Text;
            }
        }

        private int GetIntervalFromForm()
        {
            if (this.InvokeRequired)
            {
                GetInterval setpos = new GetInterval(GetIntervalFromForm);
                return Convert.ToInt32(this.Invoke(setpos));
            }
            else
            {
                return Convert.ToInt32(this.tb_TestInterval.Text);
            }
        }

        private void EnableRequestButton(bool isEnable)
        {
            if (isEnable)
            {
                this.gb_TargetServer.Enabled = true;
                this.gb_RequestType.Enabled = true;
                this.gb_TestRequirements.Enabled = true;
                this.btn_Begin.Enabled = true;
                this.btn_Cancel.Enabled = false;
                this.tv_Method.Enabled = true;
            }
            else
            {
                this.gb_TargetServer.Enabled = false;
                this.gb_RequestType.Enabled = false;
                this.gb_TestRequirements.Enabled = false;
                this.btn_Begin.Enabled = false;
                this.btn_Cancel.Enabled = true;
                this.tv_Method.Enabled = false;
            }
        }

        private string logStringCreator(int time, string msg)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format(">>>{0}<<< 测试进度:({1}/{2})", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), time, this.pbar_TestProcess.Maximum));
                sb.AppendLine(string.Format("请求路径为：{0}", GetUrlFromForm()));
                sb.AppendLine(string.Format("测试间隔为：{0}", GetIntervalFromForm()));
                sb.AppendLine(string.Format("Json请求为：{0}", requestType.ToString()));
                sb.AppendLine(string.Format("返回结果：{0}", msg));
                return sb.ToString();
            }
            catch (Exception e)
            {
                return string.Format("日志生成出错。异常为{0}",e);
            }
        }

        private string GetUrlString()
        {
            string strUrl = string.Empty;
            try
            {
                Uri uri = new Uri(new Uri("http://" + this.Tb_IP.Text + ":" + this.Tb_Port.Text + "/"), this.cb_Request.SelectedItem.ToString());
                strUrl = uri.OriginalString;
            }
            catch
            {
                throw;
            }
            return strUrl;
        }
    }
}
