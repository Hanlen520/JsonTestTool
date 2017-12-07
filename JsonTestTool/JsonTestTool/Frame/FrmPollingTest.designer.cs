namespace JsonTestTool.Frame
{
    partial class FrmPollingTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPollingTest));
            this.Lbl_IP = new System.Windows.Forms.Label();
            this.Lbl_Port = new System.Windows.Forms.Label();
            this.Tb_IP = new System.Windows.Forms.TextBox();
            this.Tb_Port = new System.Windows.Forms.TextBox();
            this.tv_Method = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rtb_Data = new System.Windows.Forms.RichTextBox();
            this.rtb_Logs = new System.Windows.Forms.RichTextBox();
            this.lb_RequestType = new System.Windows.Forms.Label();
            this.cb_Request = new System.Windows.Forms.ComboBox();
            this.btn_Expand = new System.Windows.Forms.Button();
            this.btn_LoadTree = new System.Windows.Forms.Button();
            this.tb_CaseFolder = new System.Windows.Forms.TextBox();
            this.lb_CaseFolder = new System.Windows.Forms.Label();
            this.btn_Choose = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gb_TargeServerInfo = new System.Windows.Forms.GroupBox();
            this.gb_CaseManager = new System.Windows.Forms.GroupBox();
            this.gb_LogControl = new System.Windows.Forms.GroupBox();
            this.btn_LogPathOpen = new System.Windows.Forms.Button();
            this.btn_LogPathChoose = new System.Windows.Forms.Button();
            this.lb_LogPath = new System.Windows.Forms.Label();
            this.tb_LogPath = new System.Windows.Forms.TextBox();
            this.gb_TestManager = new System.Windows.Forms.GroupBox();
            this.pbar_TestProcess = new System.Windows.Forms.ProgressBar();
            this.btn_StopTest = new System.Windows.Forms.Button();
            this.btn_BeginTest = new System.Windows.Forms.Button();
            this.lb_Process = new System.Windows.Forms.Label();
            this.gb_RequestType = new System.Windows.Forms.GroupBox();
            this.rbtn_GET = new System.Windows.Forms.RadioButton();
            this.rbtn_POSTUTF8 = new System.Windows.Forms.RadioButton();
            this.rbtn_POST = new System.Windows.Forms.RadioButton();
            this.gb_Log = new System.Windows.Forms.GroupBox();
            this.gb_Data = new System.Windows.Forms.GroupBox();
            this.gb_Tree = new System.Windows.Forms.GroupBox();
            this.gb_TargeServerInfo.SuspendLayout();
            this.gb_CaseManager.SuspendLayout();
            this.gb_LogControl.SuspendLayout();
            this.gb_TestManager.SuspendLayout();
            this.gb_RequestType.SuspendLayout();
            this.gb_Log.SuspendLayout();
            this.gb_Data.SuspendLayout();
            this.gb_Tree.SuspendLayout();
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
            this.Lbl_Port.Location = new System.Drawing.Point(91, 17);
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
            this.tv_Method.Location = new System.Drawing.Point(8, 20);
            this.tv_Method.Name = "tv_Method";
            this.tv_Method.SelectedImageIndex = 0;
            this.tv_Method.Size = new System.Drawing.Size(230, 148);
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
            this.rtb_Data.Location = new System.Drawing.Point(8, 20);
            this.rtb_Data.Name = "rtb_Data";
            this.rtb_Data.Size = new System.Drawing.Size(230, 154);
            this.rtb_Data.TabIndex = 10;
            this.rtb_Data.Text = "";
            this.rtb_Data.TextChanged += new System.EventHandler(this.rtb_Data_TextChanged);
            // 
            // rtb_Logs
            // 
            this.rtb_Logs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Logs.Location = new System.Drawing.Point(6, 20);
            this.rtb_Logs.Name = "rtb_Logs";
            this.rtb_Logs.Size = new System.Drawing.Size(464, 334);
            this.rtb_Logs.TabIndex = 12;
            this.rtb_Logs.Text = "";
            // 
            // lb_RequestType
            // 
            this.lb_RequestType.AutoSize = true;
            this.lb_RequestType.Location = new System.Drawing.Point(139, 17);
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
            this.tb_CaseFolder.Size = new System.Drawing.Size(232, 20);
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
            // gb_TargeServerInfo
            // 
            this.gb_TargeServerInfo.Controls.Add(this.Lbl_IP);
            this.gb_TargeServerInfo.Controls.Add(this.Tb_IP);
            this.gb_TargeServerInfo.Controls.Add(this.Lbl_Port);
            this.gb_TargeServerInfo.Controls.Add(this.Tb_Port);
            this.gb_TargeServerInfo.Controls.Add(this.cb_Request);
            this.gb_TargeServerInfo.Controls.Add(this.lb_RequestType);
            this.gb_TargeServerInfo.Location = new System.Drawing.Point(12, 12);
            this.gb_TargeServerInfo.Name = "gb_TargeServerInfo";
            this.gb_TargeServerInfo.Size = new System.Drawing.Size(244, 59);
            this.gb_TargeServerInfo.TabIndex = 18;
            this.gb_TargeServerInfo.TabStop = false;
            this.gb_TargeServerInfo.Text = "测试服务器信息";
            // 
            // gb_CaseManager
            // 
            this.gb_CaseManager.Controls.Add(this.btn_Expand);
            this.gb_CaseManager.Controls.Add(this.btn_Choose);
            this.gb_CaseManager.Controls.Add(this.btn_LoadTree);
            this.gb_CaseManager.Controls.Add(this.lb_CaseFolder);
            this.gb_CaseManager.Controls.Add(this.tb_CaseFolder);
            this.gb_CaseManager.Location = new System.Drawing.Point(12, 77);
            this.gb_CaseManager.Name = "gb_CaseManager";
            this.gb_CaseManager.Size = new System.Drawing.Size(244, 95);
            this.gb_CaseManager.TabIndex = 19;
            this.gb_CaseManager.TabStop = false;
            this.gb_CaseManager.Text = "测试用例管理";
            // 
            // gb_LogControl
            // 
            this.gb_LogControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_LogControl.Controls.Add(this.btn_LogPathOpen);
            this.gb_LogControl.Controls.Add(this.btn_LogPathChoose);
            this.gb_LogControl.Controls.Add(this.lb_LogPath);
            this.gb_LogControl.Controls.Add(this.tb_LogPath);
            this.gb_LogControl.Location = new System.Drawing.Point(262, 12);
            this.gb_LogControl.Name = "gb_LogControl";
            this.gb_LogControl.Size = new System.Drawing.Size(476, 59);
            this.gb_LogControl.TabIndex = 20;
            this.gb_LogControl.TabStop = false;
            this.gb_LogControl.Text = "报表管理";
            // 
            // btn_LogPathOpen
            // 
            this.btn_LogPathOpen.Location = new System.Drawing.Point(79, 21);
            this.btn_LogPathOpen.Name = "btn_LogPathOpen";
            this.btn_LogPathOpen.Size = new System.Drawing.Size(73, 32);
            this.btn_LogPathOpen.TabIndex = 10;
            this.btn_LogPathOpen.Text = "打开目录";
            this.btn_LogPathOpen.UseVisualStyleBackColor = true;
            this.btn_LogPathOpen.Click += new System.EventHandler(this.btn_LogPathOpen_Click);
            // 
            // btn_LogPathChoose
            // 
            this.btn_LogPathChoose.Location = new System.Drawing.Point(0, 21);
            this.btn_LogPathChoose.Name = "btn_LogPathChoose";
            this.btn_LogPathChoose.Size = new System.Drawing.Size(73, 32);
            this.btn_LogPathChoose.TabIndex = 0;
            this.btn_LogPathChoose.Text = "修改目录";
            this.btn_LogPathChoose.UseVisualStyleBackColor = true;
            this.btn_LogPathChoose.Click += new System.EventHandler(this.btn_LogPathChoose_Click);
            // 
            // lb_LogPath
            // 
            this.lb_LogPath.AutoSize = true;
            this.lb_LogPath.Location = new System.Drawing.Point(158, 18);
            this.lb_LogPath.Name = "lb_LogPath";
            this.lb_LogPath.Size = new System.Drawing.Size(89, 12);
            this.lb_LogPath.TabIndex = 9;
            this.lb_LogPath.Text = "报表存放位置：";
            // 
            // tb_LogPath
            // 
            this.tb_LogPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_LogPath.Location = new System.Drawing.Point(158, 33);
            this.tb_LogPath.Multiline = true;
            this.tb_LogPath.Name = "tb_LogPath";
            this.tb_LogPath.Size = new System.Drawing.Size(312, 20);
            this.tb_LogPath.TabIndex = 3;
            this.tb_LogPath.MouseEnter += new System.EventHandler(this.Tb_IP_MouseEnter);
            // 
            // gb_TestManager
            // 
            this.gb_TestManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_TestManager.Controls.Add(this.pbar_TestProcess);
            this.gb_TestManager.Controls.Add(this.btn_StopTest);
            this.gb_TestManager.Controls.Add(this.btn_BeginTest);
            this.gb_TestManager.Controls.Add(this.lb_Process);
            this.gb_TestManager.Location = new System.Drawing.Point(356, 77);
            this.gb_TestManager.Name = "gb_TestManager";
            this.gb_TestManager.Size = new System.Drawing.Size(382, 95);
            this.gb_TestManager.TabIndex = 21;
            this.gb_TestManager.TabStop = false;
            this.gb_TestManager.Text = "测试管理";
            // 
            // pbar_TestProcess
            // 
            this.pbar_TestProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbar_TestProcess.Location = new System.Drawing.Point(85, 36);
            this.pbar_TestProcess.Name = "pbar_TestProcess";
            this.pbar_TestProcess.Size = new System.Drawing.Size(291, 53);
            this.pbar_TestProcess.TabIndex = 12;
            // 
            // btn_StopTest
            // 
            this.btn_StopTest.Location = new System.Drawing.Point(6, 57);
            this.btn_StopTest.Name = "btn_StopTest";
            this.btn_StopTest.Size = new System.Drawing.Size(73, 32);
            this.btn_StopTest.TabIndex = 0;
            this.btn_StopTest.Text = "停止测试";
            this.btn_StopTest.UseVisualStyleBackColor = true;
            this.btn_StopTest.Click += new System.EventHandler(this.btn_StopTest_Click);
            // 
            // btn_BeginTest
            // 
            this.btn_BeginTest.Location = new System.Drawing.Point(6, 19);
            this.btn_BeginTest.Name = "btn_BeginTest";
            this.btn_BeginTest.Size = new System.Drawing.Size(73, 32);
            this.btn_BeginTest.TabIndex = 0;
            this.btn_BeginTest.Text = "开始测试";
            this.btn_BeginTest.UseVisualStyleBackColor = true;
            this.btn_BeginTest.Click += new System.EventHandler(this.btn_BeginTest_Click);
            // 
            // lb_Process
            // 
            this.lb_Process.AutoSize = true;
            this.lb_Process.Location = new System.Drawing.Point(85, 19);
            this.lb_Process.Name = "lb_Process";
            this.lb_Process.Size = new System.Drawing.Size(65, 12);
            this.lb_Process.TabIndex = 11;
            this.lb_Process.Text = "测试进度：";
            // 
            // gb_RequestType
            // 
            this.gb_RequestType.Controls.Add(this.rbtn_GET);
            this.gb_RequestType.Controls.Add(this.rbtn_POSTUTF8);
            this.gb_RequestType.Controls.Add(this.rbtn_POST);
            this.gb_RequestType.Location = new System.Drawing.Point(262, 77);
            this.gb_RequestType.Name = "gb_RequestType";
            this.gb_RequestType.Size = new System.Drawing.Size(88, 95);
            this.gb_RequestType.TabIndex = 21;
            this.gb_RequestType.TabStop = false;
            this.gb_RequestType.Text = "请求格式";
            // 
            // rbtn_GET
            // 
            this.rbtn_GET.AutoSize = true;
            this.rbtn_GET.Location = new System.Drawing.Point(6, 73);
            this.rbtn_GET.Name = "rbtn_GET";
            this.rbtn_GET.Size = new System.Drawing.Size(41, 16);
            this.rbtn_GET.TabIndex = 0;
            this.rbtn_GET.Text = "GET";
            this.rbtn_GET.UseVisualStyleBackColor = true;
            this.rbtn_GET.CheckedChanged += new System.EventHandler(this.rbtn_GET_CheckedChanged);
            // 
            // rbtn_POSTUTF8
            // 
            this.rbtn_POSTUTF8.AutoSize = true;
            this.rbtn_POSTUTF8.Location = new System.Drawing.Point(6, 51);
            this.rbtn_POSTUTF8.Name = "rbtn_POSTUTF8";
            this.rbtn_POSTUTF8.Size = new System.Drawing.Size(77, 16);
            this.rbtn_POSTUTF8.TabIndex = 0;
            this.rbtn_POSTUTF8.Text = "POST-UTF8";
            this.rbtn_POSTUTF8.UseVisualStyleBackColor = true;
            this.rbtn_POSTUTF8.CheckedChanged += new System.EventHandler(this.rbtn_POSTUTF8_CheckedChanged);
            // 
            // rbtn_POST
            // 
            this.rbtn_POST.AutoSize = true;
            this.rbtn_POST.Checked = true;
            this.rbtn_POST.Location = new System.Drawing.Point(6, 29);
            this.rbtn_POST.Name = "rbtn_POST";
            this.rbtn_POST.Size = new System.Drawing.Size(47, 16);
            this.rbtn_POST.TabIndex = 0;
            this.rbtn_POST.TabStop = true;
            this.rbtn_POST.Text = "POST";
            this.rbtn_POST.UseVisualStyleBackColor = true;
            this.rbtn_POST.CheckedChanged += new System.EventHandler(this.rbtn_POST_CheckedChanged);
            // 
            // gb_Log
            // 
            this.gb_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Log.Controls.Add(this.rtb_Logs);
            this.gb_Log.Location = new System.Drawing.Point(262, 178);
            this.gb_Log.Name = "gb_Log";
            this.gb_Log.Size = new System.Drawing.Size(476, 360);
            this.gb_Log.TabIndex = 22;
            this.gb_Log.TabStop = false;
            this.gb_Log.Text = "测试日志：";
            // 
            // gb_Data
            // 
            this.gb_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_Data.Controls.Add(this.rtb_Data);
            this.gb_Data.Location = new System.Drawing.Point(12, 358);
            this.gb_Data.Name = "gb_Data";
            this.gb_Data.Size = new System.Drawing.Size(244, 180);
            this.gb_Data.TabIndex = 23;
            this.gb_Data.TabStop = false;
            this.gb_Data.Text = "请求数据：";
            // 
            // gb_Tree
            // 
            this.gb_Tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_Tree.Controls.Add(this.tv_Method);
            this.gb_Tree.Location = new System.Drawing.Point(12, 178);
            this.gb_Tree.Name = "gb_Tree";
            this.gb_Tree.Size = new System.Drawing.Size(244, 174);
            this.gb_Tree.TabIndex = 24;
            this.gb_Tree.TabStop = false;
            this.gb_Tree.Text = "批量测试请求列表：";
            // 
            // FrmPollingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.gb_Tree);
            this.Controls.Add(this.gb_Data);
            this.Controls.Add(this.gb_Log);
            this.Controls.Add(this.gb_RequestType);
            this.Controls.Add(this.gb_TestManager);
            this.Controls.Add(this.gb_LogControl);
            this.Controls.Add(this.gb_CaseManager);
            this.Controls.Add(this.gb_TargeServerInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPollingTest";
            this.Text = "Json Test Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_TargeServerInfo.ResumeLayout(false);
            this.gb_TargeServerInfo.PerformLayout();
            this.gb_CaseManager.ResumeLayout(false);
            this.gb_CaseManager.PerformLayout();
            this.gb_LogControl.ResumeLayout(false);
            this.gb_LogControl.PerformLayout();
            this.gb_TestManager.ResumeLayout(false);
            this.gb_TestManager.PerformLayout();
            this.gb_RequestType.ResumeLayout(false);
            this.gb_RequestType.PerformLayout();
            this.gb_Log.ResumeLayout(false);
            this.gb_Data.ResumeLayout(false);
            this.gb_Tree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Lbl_IP;
        private System.Windows.Forms.Label Lbl_Port;
        private System.Windows.Forms.TextBox Tb_IP;
        private System.Windows.Forms.TextBox Tb_Port;
        private System.Windows.Forms.TreeView tv_Method;
        private System.Windows.Forms.RichTextBox rtb_Data;
        private System.Windows.Forms.RichTextBox rtb_Logs;
        private System.Windows.Forms.Label lb_RequestType;
        private System.Windows.Forms.ComboBox cb_Request;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_Expand;
        private System.Windows.Forms.Button btn_LoadTree;
        private System.Windows.Forms.TextBox tb_CaseFolder;
        private System.Windows.Forms.Label lb_CaseFolder;
        private System.Windows.Forms.Button btn_Choose;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox gb_TargeServerInfo;
        private System.Windows.Forms.GroupBox gb_CaseManager;
        private System.Windows.Forms.GroupBox gb_LogControl;
        private System.Windows.Forms.Button btn_LogPathChoose;
        private System.Windows.Forms.Label lb_LogPath;
        private System.Windows.Forms.TextBox tb_LogPath;
        private System.Windows.Forms.GroupBox gb_TestManager;
        private System.Windows.Forms.GroupBox gb_RequestType;
        private System.Windows.Forms.RadioButton rbtn_GET;
        private System.Windows.Forms.RadioButton rbtn_POSTUTF8;
        private System.Windows.Forms.RadioButton rbtn_POST;
        private System.Windows.Forms.Button btn_StopTest;
        private System.Windows.Forms.Button btn_BeginTest;
        private System.Windows.Forms.Label lb_Process;
        private System.Windows.Forms.ProgressBar pbar_TestProcess;
        private System.Windows.Forms.Button btn_LogPathOpen;
        private System.Windows.Forms.GroupBox gb_Log;
        private System.Windows.Forms.GroupBox gb_Data;
        private System.Windows.Forms.GroupBox gb_Tree;
    }
}

