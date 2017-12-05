namespace JsonTestTool.Frame
{
    partial class FrmTestSystem
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestSystem));
            this.Lbl_IP = new System.Windows.Forms.Label();
            this.Lbl_Port = new System.Windows.Forms.Label();
            this.Tb_IP = new System.Windows.Forms.TextBox();
            this.Tb_Port = new System.Windows.Forms.TextBox();
            this.tv_Method = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lb_Data = new System.Windows.Forms.Label();
            this.rtb_Data = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtb_ACK = new System.Windows.Forms.RichTextBox();
            this.btn_POST = new System.Windows.Forms.Button();
            this.btn_POST8 = new System.Windows.Forms.Button();
            this.btn_GET = new System.Windows.Forms.Button();
            this.lb_RequestType = new System.Windows.Forms.Label();
            this.cb_Request = new System.Windows.Forms.ComboBox();
            this.btn_Expand = new System.Windows.Forms.Button();
            this.btn_LoadTree = new System.Windows.Forms.Button();
            this.tb_CaseFolder = new System.Windows.Forms.TextBox();
            this.lb_CaseFolder = new System.Windows.Forms.Label();
            this.btn_Choose = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // Lbl_IP
            // 
            this.Lbl_IP.AutoSize = true;
            this.Lbl_IP.Location = new System.Drawing.Point(401, 14);
            this.Lbl_IP.Name = "Lbl_IP";
            this.Lbl_IP.Size = new System.Drawing.Size(17, 12);
            this.Lbl_IP.TabIndex = 1;
            this.Lbl_IP.Text = "IP";
            // 
            // Lbl_Port
            // 
            this.Lbl_Port.AutoSize = true;
            this.Lbl_Port.Location = new System.Drawing.Point(570, 16);
            this.Lbl_Port.Name = "Lbl_Port";
            this.Lbl_Port.Size = new System.Drawing.Size(29, 12);
            this.Lbl_Port.TabIndex = 2;
            this.Lbl_Port.Text = "Port";
            // 
            // Tb_IP
            // 
            this.Tb_IP.Location = new System.Drawing.Point(403, 31);
            this.Tb_IP.Multiline = true;
            this.Tb_IP.Name = "Tb_IP";
            this.Tb_IP.Size = new System.Drawing.Size(163, 20);
            this.Tb_IP.TabIndex = 3;
            this.Tb_IP.Text = "10.10.1.77";
            this.Tb_IP.MouseEnter += new System.EventHandler(this.Tb_IP_MouseEnter);
            // 
            // Tb_Port
            // 
            this.Tb_Port.Location = new System.Drawing.Point(570, 31);
            this.Tb_Port.Multiline = true;
            this.Tb_Port.Name = "Tb_Port";
            this.Tb_Port.Size = new System.Drawing.Size(43, 20);
            this.Tb_Port.TabIndex = 4;
            this.Tb_Port.Text = "9905";
            // 
            // tv_Method
            // 
            this.tv_Method.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tv_Method.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv_Method.FullRowSelect = true;
            this.tv_Method.ImageKey = "folder.png";
            this.tv_Method.ImageList = this.imageList1;
            this.tv_Method.Location = new System.Drawing.Point(13, 91);
            this.tv_Method.Name = "tv_Method";
            this.tv_Method.SelectedImageIndex = 0;
            this.tv_Method.Size = new System.Drawing.Size(250, 447);
            this.tv_Method.TabIndex = 8;
            this.tv_Method.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tv_Method_AfterCollapse);
            this.tv_Method.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv_Method_AfterExpand);
            this.tv_Method.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_Method_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "folder_heart.png");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // lb_Data
            // 
            this.lb_Data.AutoSize = true;
            this.lb_Data.Location = new System.Drawing.Point(269, 76);
            this.lb_Data.Name = "lb_Data";
            this.lb_Data.Size = new System.Drawing.Size(41, 12);
            this.lb_Data.TabIndex = 9;
            this.lb_Data.Text = "数据：";
            // 
            // rtb_Data
            // 
            this.rtb_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Data.Location = new System.Drawing.Point(271, 91);
            this.rtb_Data.Name = "rtb_Data";
            this.rtb_Data.Size = new System.Drawing.Size(470, 160);
            this.rtb_Data.TabIndex = 10;
            this.rtb_Data.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "应答：";
            // 
            // rtb_ACK
            // 
            this.rtb_ACK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_ACK.Location = new System.Drawing.Point(271, 278);
            this.rtb_ACK.Name = "rtb_ACK";
            this.rtb_ACK.Size = new System.Drawing.Size(470, 260);
            this.rtb_ACK.TabIndex = 12;
            this.rtb_ACK.Text = "";
            // 
            // btn_POST
            // 
            this.btn_POST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_POST.Location = new System.Drawing.Point(402, 56);
            this.btn_POST.Name = "btn_POST";
            this.btn_POST.Size = new System.Drawing.Size(100, 23);
            this.btn_POST.TabIndex = 13;
            this.btn_POST.Text = "POST";
            this.btn_POST.UseVisualStyleBackColor = true;
            // 
            // btn_POST8
            // 
            this.btn_POST8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_POST8.Location = new System.Drawing.Point(513, 56);
            this.btn_POST8.Name = "btn_POST8";
            this.btn_POST8.Size = new System.Drawing.Size(100, 23);
            this.btn_POST8.TabIndex = 13;
            this.btn_POST8.Text = "POST(utf8)";
            this.btn_POST8.UseVisualStyleBackColor = true;
            // 
            // btn_GET
            // 
            this.btn_GET.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GET.Location = new System.Drawing.Point(619, 56);
            this.btn_GET.Name = "btn_GET";
            this.btn_GET.Size = new System.Drawing.Size(100, 23);
            this.btn_GET.TabIndex = 13;
            this.btn_GET.Text = "GET";
            this.btn_GET.UseVisualStyleBackColor = true;
            // 
            // lb_RequestType
            // 
            this.lb_RequestType.AutoSize = true;
            this.lb_RequestType.Location = new System.Drawing.Point(617, 15);
            this.lb_RequestType.Name = "lb_RequestType";
            this.lb_RequestType.Size = new System.Drawing.Size(53, 12);
            this.lb_RequestType.TabIndex = 14;
            this.lb_RequestType.Text = "请求类型";
            // 
            // cb_Request
            // 
            this.cb_Request.FormattingEnabled = true;
            this.cb_Request.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_Request.Items.AddRange(new object[] {
            "api/hedajwreq",
            "api/hedacmdreq",
            "api/sysinfo",
            "xml/upload"});
            this.cb_Request.Location = new System.Drawing.Point(625, 31);
            this.cb_Request.Name = "cb_Request";
            this.cb_Request.Size = new System.Drawing.Size(116, 20);
            this.cb_Request.TabIndex = 15;
            this.cb_Request.Text = "api/hedajwreq";
            // 
            // btn_Expand
            // 
            this.btn_Expand.Location = new System.Drawing.Point(13, 56);
            this.btn_Expand.Name = "btn_Expand";
            this.btn_Expand.Size = new System.Drawing.Size(75, 23);
            this.btn_Expand.TabIndex = 17;
            this.btn_Expand.Text = "收缩节点";
            this.btn_Expand.UseVisualStyleBackColor = true;
            this.btn_Expand.Click += new System.EventHandler(this.btn_Expand_Click);
            this.btn_Expand.MouseEnter += new System.EventHandler(this.btn_Expand_MouseEnter);
            // 
            // btn_LoadTree
            // 
            this.btn_LoadTree.Location = new System.Drawing.Point(169, 56);
            this.btn_LoadTree.Name = "btn_LoadTree";
            this.btn_LoadTree.Size = new System.Drawing.Size(71, 23);
            this.btn_LoadTree.TabIndex = 16;
            this.btn_LoadTree.Text = "加载";
            this.btn_LoadTree.UseVisualStyleBackColor = true;
            this.btn_LoadTree.Click += new System.EventHandler(this.btn_LoadTree_Click);
            // 
            // tb_CaseFolder
            // 
            this.tb_CaseFolder.Location = new System.Drawing.Point(12, 31);
            this.tb_CaseFolder.Multiline = true;
            this.tb_CaseFolder.Name = "tb_CaseFolder";
            this.tb_CaseFolder.Size = new System.Drawing.Size(385, 20);
            this.tb_CaseFolder.TabIndex = 3;
            this.tb_CaseFolder.MouseEnter += new System.EventHandler(this.Tb_IP_MouseEnter);
            // 
            // lb_CaseFolder
            // 
            this.lb_CaseFolder.AutoSize = true;
            this.lb_CaseFolder.Location = new System.Drawing.Point(11, 14);
            this.lb_CaseFolder.Name = "lb_CaseFolder";
            this.lb_CaseFolder.Size = new System.Drawing.Size(89, 12);
            this.lb_CaseFolder.TabIndex = 1;
            this.lb_CaseFolder.Text = "测试用例目录：";
            // 
            // btn_Choose
            // 
            this.btn_Choose.Location = new System.Drawing.Point(94, 56);
            this.btn_Choose.Name = "btn_Choose";
            this.btn_Choose.Size = new System.Drawing.Size(69, 23);
            this.btn_Choose.TabIndex = 16;
            this.btn_Choose.Text = "浏览";
            this.btn_Choose.UseVisualStyleBackColor = true;
            this.btn_Choose.Click += new System.EventHandler(this.btn_Choose_Click);
            this.btn_Choose.MouseEnter += new System.EventHandler(this.btb_SaveNodesToXml_MouseEnter);
            // 
            // FrmTestSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.btn_Expand);
            this.Controls.Add(this.btn_Choose);
            this.Controls.Add(this.btn_LoadTree);
            this.Controls.Add(this.cb_Request);
            this.Controls.Add(this.lb_RequestType);
            this.Controls.Add(this.btn_GET);
            this.Controls.Add(this.btn_POST8);
            this.Controls.Add(this.btn_POST);
            this.Controls.Add(this.rtb_ACK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_Data);
            this.Controls.Add(this.lb_Data);
            this.Controls.Add(this.tv_Method);
            this.Controls.Add(this.tb_CaseFolder);
            this.Controls.Add(this.Tb_Port);
            this.Controls.Add(this.Tb_IP);
            this.Controls.Add(this.Lbl_Port);
            this.Controls.Add(this.lb_CaseFolder);
            this.Controls.Add(this.Lbl_IP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTestSystem";
            this.Text = "Json Test Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl_IP;
        private System.Windows.Forms.Label Lbl_Port;
        private System.Windows.Forms.TextBox Tb_IP;
        private System.Windows.Forms.TextBox Tb_Port;
        private System.Windows.Forms.TreeView tv_Method;
        private System.Windows.Forms.Label lb_Data;
        private System.Windows.Forms.RichTextBox rtb_Data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtb_ACK;
        private System.Windows.Forms.Button btn_POST;
        private System.Windows.Forms.Button btn_POST8;
        private System.Windows.Forms.Button btn_GET;
        private System.Windows.Forms.Label lb_RequestType;
        private System.Windows.Forms.ComboBox cb_Request;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_Expand;
        private System.Windows.Forms.Button btn_LoadTree;
        private System.Windows.Forms.TextBox tb_CaseFolder;
        private System.Windows.Forms.Label lb_CaseFolder;
        private System.Windows.Forms.Button btn_Choose;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

