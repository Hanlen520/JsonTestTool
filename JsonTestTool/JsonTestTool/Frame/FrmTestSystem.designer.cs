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
            this.rtb_Data = new System.Windows.Forms.RichTextBox();
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
            this.gb_TargeServerInfomation = new System.Windows.Forms.GroupBox();
            this.gb_CaseManager = new System.Windows.Forms.GroupBox();
            this.gb_TestManager = new System.Windows.Forms.GroupBox();
            this.cb_GetScreenshots = new System.Windows.Forms.CheckBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.gb_Data = new System.Windows.Forms.GroupBox();
            this.gb_ACK = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gb_TargeServerInfomation.SuspendLayout();
            this.gb_CaseManager.SuspendLayout();
            this.gb_TestManager.SuspendLayout();
            this.gb_Data.SuspendLayout();
            this.gb_ACK.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_IP
            // 
            this.Lbl_IP.AutoSize = true;
            this.Lbl_IP.Location = new System.Drawing.Point(6, 17);
            this.Lbl_IP.Name = "Lbl_IP";
            this.Lbl_IP.Size = new System.Drawing.Size(29, 12);
            this.Lbl_IP.TabIndex = 1;
            this.Lbl_IP.Text = "IP：";
            // 
            // Lbl_Port
            // 
            this.Lbl_Port.AutoSize = true;
            this.Lbl_Port.Location = new System.Drawing.Point(90, 17);
            this.Lbl_Port.Name = "Lbl_Port";
            this.Lbl_Port.Size = new System.Drawing.Size(41, 12);
            this.Lbl_Port.TabIndex = 2;
            this.Lbl_Port.Text = "Port：";
            // 
            // Tb_IP
            // 
            this.Tb_IP.Location = new System.Drawing.Point(6, 32);
            this.Tb_IP.Multiline = true;
            this.Tb_IP.Name = "Tb_IP";
            this.Tb_IP.Size = new System.Drawing.Size(80, 20);
            this.Tb_IP.TabIndex = 3;
            this.Tb_IP.Text = "10.10.1.77";
            this.Tb_IP.MouseEnter += new System.EventHandler(this.Tb_IP_MouseEnter);
            // 
            // Tb_Port
            // 
            this.Tb_Port.Location = new System.Drawing.Point(92, 32);
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
            this.tv_Method.Location = new System.Drawing.Point(6, 96);
            this.tv_Method.Name = "tv_Method";
            this.tv_Method.SelectedImageIndex = 0;
            this.tv_Method.Size = new System.Drawing.Size(232, 369);
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
            // rtb_Data
            // 
            this.rtb_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Data.Location = new System.Drawing.Point(6, 17);
            this.rtb_Data.Name = "rtb_Data";
            this.rtb_Data.Size = new System.Drawing.Size(465, 134);
            this.rtb_Data.TabIndex = 10;
            this.rtb_Data.Text = "请选择一个测试节点。";
            // 
            // rtb_ACK
            // 
            this.rtb_ACK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_ACK.BackColor = System.Drawing.SystemColors.Window;
            this.rtb_ACK.Location = new System.Drawing.Point(6, 20);
            this.rtb_ACK.Name = "rtb_ACK";
            this.rtb_ACK.Size = new System.Drawing.Size(465, 270);
            this.rtb_ACK.TabIndex = 12;
            this.rtb_ACK.Text = "";
            // 
            // btn_POST
            // 
            this.btn_POST.Location = new System.Drawing.Point(13, 20);
            this.btn_POST.Name = "btn_POST";
            this.btn_POST.Size = new System.Drawing.Size(73, 32);
            this.btn_POST.TabIndex = 13;
            this.btn_POST.Text = "POST";
            this.btn_POST.UseVisualStyleBackColor = true;
            this.btn_POST.Click += new System.EventHandler(this.btn_POST_Click);
            // 
            // btn_POST8
            // 
            this.btn_POST8.Location = new System.Drawing.Point(92, 20);
            this.btn_POST8.Name = "btn_POST8";
            this.btn_POST8.Size = new System.Drawing.Size(73, 32);
            this.btn_POST8.TabIndex = 13;
            this.btn_POST8.Text = "POST(UTF8)";
            this.btn_POST8.UseVisualStyleBackColor = true;
            this.btn_POST8.Click += new System.EventHandler(this.btn_POST8_Click);
            // 
            // btn_GET
            // 
            this.btn_GET.Location = new System.Drawing.Point(171, 20);
            this.btn_GET.Name = "btn_GET";
            this.btn_GET.Size = new System.Drawing.Size(73, 32);
            this.btn_GET.TabIndex = 13;
            this.btn_GET.Text = "GET";
            this.btn_GET.UseVisualStyleBackColor = true;
            this.btn_GET.Click += new System.EventHandler(this.btn_GET_Click);
            // 
            // lb_RequestType
            // 
            this.lb_RequestType.AutoSize = true;
            this.lb_RequestType.Location = new System.Drawing.Point(138, 17);
            this.lb_RequestType.Name = "lb_RequestType";
            this.lb_RequestType.Size = new System.Drawing.Size(65, 12);
            this.lb_RequestType.TabIndex = 14;
            this.lb_RequestType.Text = "请求类型：";
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
            this.cb_Request.Location = new System.Drawing.Point(140, 32);
            this.cb_Request.Name = "cb_Request";
            this.cb_Request.Size = new System.Drawing.Size(98, 20);
            this.cb_Request.TabIndex = 15;
            this.cb_Request.Text = "api/hedajwreq";
            // 
            // btn_Expand
            // 
            this.btn_Expand.Location = new System.Drawing.Point(6, 58);
            this.btn_Expand.Name = "btn_Expand";
            this.btn_Expand.Size = new System.Drawing.Size(73, 32);
            this.btn_Expand.TabIndex = 17;
            this.btn_Expand.Text = "收缩节点";
            this.btn_Expand.UseVisualStyleBackColor = true;
            this.btn_Expand.Click += new System.EventHandler(this.btn_Expand_Click);
            this.btn_Expand.MouseEnter += new System.EventHandler(this.btn_Expand_MouseEnter);
            // 
            // btn_LoadTree
            // 
            this.btn_LoadTree.Location = new System.Drawing.Point(164, 58);
            this.btn_LoadTree.Name = "btn_LoadTree";
            this.btn_LoadTree.Size = new System.Drawing.Size(73, 32);
            this.btn_LoadTree.TabIndex = 16;
            this.btn_LoadTree.Text = "加载";
            this.btn_LoadTree.UseVisualStyleBackColor = true;
            this.btn_LoadTree.Click += new System.EventHandler(this.btn_LoadTree_Click);
            // 
            // tb_CaseFolder
            // 
            this.tb_CaseFolder.Location = new System.Drawing.Point(6, 32);
            this.tb_CaseFolder.Multiline = true;
            this.tb_CaseFolder.Name = "tb_CaseFolder";
            this.tb_CaseFolder.Size = new System.Drawing.Size(233, 20);
            this.tb_CaseFolder.TabIndex = 3;
            this.tb_CaseFolder.MouseEnter += new System.EventHandler(this.Tb_IP_MouseEnter);
            // 
            // lb_CaseFolder
            // 
            this.lb_CaseFolder.AutoSize = true;
            this.lb_CaseFolder.Location = new System.Drawing.Point(6, 17);
            this.lb_CaseFolder.Name = "lb_CaseFolder";
            this.lb_CaseFolder.Size = new System.Drawing.Size(41, 12);
            this.lb_CaseFolder.TabIndex = 1;
            this.lb_CaseFolder.Text = "目录：";
            // 
            // btn_Choose
            // 
            this.btn_Choose.Location = new System.Drawing.Point(85, 58);
            this.btn_Choose.Name = "btn_Choose";
            this.btn_Choose.Size = new System.Drawing.Size(73, 32);
            this.btn_Choose.TabIndex = 16;
            this.btn_Choose.Text = "浏览";
            this.btn_Choose.UseVisualStyleBackColor = true;
            this.btn_Choose.Click += new System.EventHandler(this.btn_Choose_Click);
            this.btn_Choose.MouseEnter += new System.EventHandler(this.btb_SaveNodesToXml_MouseEnter);
            // 
            // gb_TargeServerInfomation
            // 
            this.gb_TargeServerInfomation.Controls.Add(this.Lbl_IP);
            this.gb_TargeServerInfomation.Controls.Add(this.Lbl_Port);
            this.gb_TargeServerInfomation.Controls.Add(this.Tb_IP);
            this.gb_TargeServerInfomation.Controls.Add(this.Tb_Port);
            this.gb_TargeServerInfomation.Controls.Add(this.cb_Request);
            this.gb_TargeServerInfomation.Controls.Add(this.lb_RequestType);
            this.gb_TargeServerInfomation.Location = new System.Drawing.Point(12, 9);
            this.gb_TargeServerInfomation.Name = "gb_TargeServerInfomation";
            this.gb_TargeServerInfomation.Size = new System.Drawing.Size(244, 62);
            this.gb_TargeServerInfomation.TabIndex = 18;
            this.gb_TargeServerInfomation.TabStop = false;
            this.gb_TargeServerInfomation.Text = "测试服务器信息";
            // 
            // gb_CaseManager
            // 
            this.gb_CaseManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_CaseManager.Controls.Add(this.tv_Method);
            this.gb_CaseManager.Controls.Add(this.lb_CaseFolder);
            this.gb_CaseManager.Controls.Add(this.tb_CaseFolder);
            this.gb_CaseManager.Controls.Add(this.btn_Expand);
            this.gb_CaseManager.Controls.Add(this.btn_LoadTree);
            this.gb_CaseManager.Controls.Add(this.btn_Choose);
            this.gb_CaseManager.Location = new System.Drawing.Point(12, 67);
            this.gb_CaseManager.Name = "gb_CaseManager";
            this.gb_CaseManager.Size = new System.Drawing.Size(244, 471);
            this.gb_CaseManager.TabIndex = 19;
            this.gb_CaseManager.TabStop = false;
            this.gb_CaseManager.Text = "测试用例管理";
            // 
            // gb_TestManager
            // 
            this.gb_TestManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_TestManager.Controls.Add(this.btn_Clear);
            this.gb_TestManager.Controls.Add(this.btn_POST);
            this.gb_TestManager.Controls.Add(this.btn_POST8);
            this.gb_TestManager.Controls.Add(this.btn_GET);
            this.gb_TestManager.Location = new System.Drawing.Point(262, 172);
            this.gb_TestManager.Name = "gb_TestManager";
            this.gb_TestManager.Size = new System.Drawing.Size(330, 64);
            this.gb_TestManager.TabIndex = 20;
            this.gb_TestManager.TabStop = false;
            this.gb_TestManager.Text = "测试管理";
            // 
            // cb_GetScreenshots
            // 
            this.cb_GetScreenshots.AutoSize = true;
            this.cb_GetScreenshots.Location = new System.Drawing.Point(6, 20);
            this.cb_GetScreenshots.Name = "cb_GetScreenshots";
            this.cb_GetScreenshots.Size = new System.Drawing.Size(132, 28);
            this.cb_GetScreenshots.TabIndex = 15;
            this.cb_GetScreenshots.Text = "测试结束是否截图？\r\n确认是请勾选。\r\n";
            this.cb_GetScreenshots.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(250, 20);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(73, 32);
            this.btn_Clear.TabIndex = 14;
            this.btn_Clear.Text = "重置";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // gb_Data
            // 
            this.gb_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Data.Controls.Add(this.rtb_Data);
            this.gb_Data.Location = new System.Drawing.Point(262, 9);
            this.gb_Data.Name = "gb_Data";
            this.gb_Data.Size = new System.Drawing.Size(477, 157);
            this.gb_Data.TabIndex = 21;
            this.gb_Data.TabStop = false;
            this.gb_Data.Text = "Json请求数据：";
            // 
            // gb_ACK
            // 
            this.gb_ACK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_ACK.Controls.Add(this.rtb_ACK);
            this.gb_ACK.Location = new System.Drawing.Point(262, 242);
            this.gb_ACK.Name = "gb_ACK";
            this.gb_ACK.Size = new System.Drawing.Size(477, 296);
            this.gb_ACK.TabIndex = 23;
            this.gb_ACK.TabStop = false;
            this.gb_ACK.Text = "返回应答：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_GetScreenshots);
            this.groupBox1.Location = new System.Drawing.Point(598, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 64);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试截图管理";
            // 
            // FrmTestSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_ACK);
            this.Controls.Add(this.gb_Data);
            this.Controls.Add(this.gb_TestManager);
            this.Controls.Add(this.gb_CaseManager);
            this.Controls.Add(this.gb_TargeServerInfomation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTestSystem";
            this.Text = "Json Test Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_TargeServerInfomation.ResumeLayout(false);
            this.gb_TargeServerInfomation.PerformLayout();
            this.gb_CaseManager.ResumeLayout(false);
            this.gb_CaseManager.PerformLayout();
            this.gb_TestManager.ResumeLayout(false);
            this.gb_Data.ResumeLayout(false);
            this.gb_ACK.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Lbl_IP;
        private System.Windows.Forms.Label Lbl_Port;
        private System.Windows.Forms.TextBox Tb_IP;
        private System.Windows.Forms.TextBox Tb_Port;
        private System.Windows.Forms.TreeView tv_Method;
        private System.Windows.Forms.RichTextBox rtb_Data;
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
        private System.Windows.Forms.GroupBox gb_TargeServerInfomation;
        private System.Windows.Forms.GroupBox gb_CaseManager;
        private System.Windows.Forms.GroupBox gb_TestManager;
        private System.Windows.Forms.GroupBox gb_Data;
        private System.Windows.Forms.GroupBox gb_ACK;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.CheckBox cb_GetScreenshots;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

