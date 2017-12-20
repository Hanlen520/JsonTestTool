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
using System.Drawing;

namespace JsonTestTool.Frame
{
    public partial class FrmTestSystem : Form
    {
        const string EXPAND = "展开节点";
        const string COLLAPSE = "收缩节点";
        HttpUtil htmlUtil = new HttpUtil();
        XmlDocument doc = new XmlDocument();

        public FrmTestSystem()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                //默认加载程序平级目录Cases下的所有子目录和xml文件
                string caseUrl = Path.Combine(Application.StartupPath, "cases");
                //显示Cases目录
                this.tb_CaseFolder.Text = caseUrl;
                //遍历并添加TreeView节点
                LoadFilesAndDirectoriesToTree(caseUrl, tv_Method.Nodes);
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

        /// <summary>
        /// 遍历指定目录，获取所有下级文件夹和XML文件
        /// </summary>
        /// <param name="path">指定目录全路径</param>
        /// <param name="treeNodeCollection">TreeView节点集合</param>
        private void LoadFilesAndDirectoriesToTree(string path, TreeNodeCollection treeNodeCollection)
        {
            //1.先根据路径获取所有的子文件和子文件夹
            var files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".xml"));
            string[] dirs = Directory.GetDirectories(path);
            //2.把所有的子文件与子目录加到TreeView上。
            foreach (string item in files)
            {
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
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));
                //由于目录，可能下面还存在子目录，所以这时要对每个目录再次进行获取子目录与子文件的操作
                LoadFilesAndDirectoriesToTree(item, node.Nodes);
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
                    //设置首个节点为焦点
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

        private void btn_Choose_Click(object sender, EventArgs e)
        {
            try
            {
                //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.DesktopDirectory;
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
                this.rtb_ACK.Text = "展开Folder失败。";
                this.rtb_ACK.Text += ex.ToString();
            }

        }

        private void btn_LoadTree_Click(object sender, EventArgs e)
        {
            this.tv_Method.Nodes.Clear();
            this.btn_Expand.Text = EXPAND;
            try
            {
                LoadFilesAndDirectoriesToTree(this.tb_CaseFolder.Text, this.tv_Method.Nodes);
            }
            catch (Exception es)
            {
                this.rtb_Data.Text = es.Message;
            }
        }

        private void btn_POST_Click(object sender, EventArgs e)
        {
            this.ParentForm.TopMost = true;
            string url = GetUrlString();
            try
            {
                string temp = htmlUtil.HttpPost(url, this.rtb_Data.Text);
                this.rtb_ACK.Text = temp;
            }
            catch (Exception ex)
            {
                this.rtb_ACK.Text = ex.Message;
            }
            finally
            {
                //必须执行一次Update再截图，否则截图中无RichTextBox的文本内容
                this.rtb_ACK.Update();
                this.ParentForm.TopMost = false;
                if (this.cb_GetScreenshots.Checked)
                {
                    GetScreenshots();
                }
            }
        }

        private void btn_POST8_Click(object sender, EventArgs e)
        {
            string url = GetUrlString();
            this.ParentForm.TopMost = true;
            try
            {
                string temp = htmlUtil.HttpPostUTF8(url, this.rtb_Data.Text);
                this.rtb_ACK.Text = temp;
            }
            catch (Exception ex)
            {
                this.rtb_ACK.Text = ex.Message;
            }
            finally
            {
                //必须执行一次Update再截图，否则截图中无RichTextBox的文本内容
                this.rtb_ACK.Update();
                this.ParentForm.TopMost = false;
                if (this.cb_GetScreenshots.Checked)
                {
                    GetScreenshots();
                }
            }
        }

        private void btn_GET_Click(object sender, EventArgs e)
        {
            string url = GetUrlString();
            this.ParentForm.TopMost = true; 
            try
            {
                string temp = htmlUtil.HttpGet(url, this.rtb_Data.Text);
                this.rtb_ACK.Text = temp;
            }
            catch (Exception ex)
            {
                this.rtb_ACK.Text = ex.Message;
            }
            finally
            {
                //必须执行一次Update再截图，否则截图中无RichTextBox的文本内容
                this.rtb_ACK.Update();
                this.ParentForm.TopMost = false;
                if (this.cb_GetScreenshots.Checked)
                {
                    GetScreenshots();
                }
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.rtb_ACK.Text = "请选择一个测试节点。";
            this.rtb_Data.Text = string.Empty;
            this.cb_GetScreenshots.Checked = false;
        }

        private void GetScreenshots()
        {
            try
            {
                this.Parent.Show();
                Bitmap bitmap = new Bitmap(this.Parent.Width, this.Parent.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    this.Parent.Show();
                    g.CopyFromScreen(this.Parent.PointToScreen(Point.Empty), Point.Empty, Parent.Size);
                }
                bitmap.Save(Path.Combine(Application.StartupPath, string.Format("普通测试Screenshots{0}.jpg", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"))));
            }
            catch
            {

            }
        }
    }
}
