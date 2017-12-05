﻿namespace JsonTestTool.Frame
{
    partial class FrmPerformentTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPerformentTest));
            this.Lbl_IP = new System.Windows.Forms.Label();
            this.Lbl_Port = new System.Windows.Forms.Label();
            this.Tb_IP = new System.Windows.Forms.TextBox();
            this.Tb_Port = new System.Windows.Forms.TextBox();
            this.tv_Method = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lb_RequestType = new System.Windows.Forms.Label();
            this.cb_Request = new System.Windows.Forms.ComboBox();
            this.lb_Data = new System.Windows.Forms.Label();
            this.rtb_Data = new System.Windows.Forms.RichTextBox();
            this.lb_ACK = new System.Windows.Forms.Label();
            this.rtb_ACK = new System.Windows.Forms.RichTextBox();
            this.lb_TestCount = new System.Windows.Forms.Label();
            this.nud_Count = new System.Windows.Forms.NumericUpDown();
            this.lb_TreeView = new System.Windows.Forms.Label();
            this.gb_TargetServer = new System.Windows.Forms.GroupBox();
            this.btn_LogPathChoose = new System.Windows.Forms.Button();
            this.tb_LogPath = new System.Windows.Forms.TextBox();
            this.lb_LogPath = new System.Windows.Forms.Label();
            this.pbar_TestProcess = new System.Windows.Forms.ProgressBar();
            this.lb_Process = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.gb_RequestType = new System.Windows.Forms.GroupBox();
            this.rb_GET = new System.Windows.Forms.RadioButton();
            this.rb_POST_UTF8 = new System.Windows.Forms.RadioButton();
            this.rb_POST = new System.Windows.Forms.RadioButton();
            this.btn_Begin = new System.Windows.Forms.Button();
            this.lb_Interval = new System.Windows.Forms.Label();
            this.gb_LogControl = new System.Windows.Forms.GroupBox();
            this.gb_TestRequirements = new System.Windows.Forms.GroupBox();
            this.tb_TestInterval = new System.Windows.Forms.TextBox();
            this.gb_TestManage = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Count)).BeginInit();
            this.gb_TargetServer.SuspendLayout();
            this.gb_RequestType.SuspendLayout();
            this.gb_LogControl.SuspendLayout();
            this.gb_TestRequirements.SuspendLayout();
            this.gb_TestManage.SuspendLayout();
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
            this.Lbl_Port.Location = new System.Drawing.Point(107, 17);
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
            this.Tb_IP.Size = new System.Drawing.Size(87, 20);
            this.Tb_IP.TabIndex = 3;
            this.Tb_IP.Text = "10.10.1.77";
            this.Tb_IP.MouseEnter += new System.EventHandler(this.Tb_IP_MouseEnter);
            // 
            // Tb_Port
            // 
            this.Tb_Port.Location = new System.Drawing.Point(107, 34);
            this.Tb_Port.Multiline = true;
            this.Tb_Port.Name = "Tb_Port";
            this.Tb_Port.Size = new System.Drawing.Size(43, 20);
            this.Tb_Port.TabIndex = 4;
            this.Tb_Port.Text = "9905";
            // 
            // tv_Method
            // 
            this.tv_Method.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv_Method.FullRowSelect = true;
            this.tv_Method.ImageKey = "folder.png";
            this.tv_Method.ImageList = this.imageList1;
            this.tv_Method.Location = new System.Drawing.Point(12, 186);
            this.tv_Method.Name = "tv_Method";
            this.tv_Method.SelectedImageIndex = 0;
            this.tv_Method.Size = new System.Drawing.Size(177, 197);
            this.tv_Method.TabIndex = 8;
            this.tv_Method.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tv_Method_AfterCollapse);
            this.tv_Method.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv_Method_AfterExpand);
            this.tv_Method.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_Method_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_heart.png");
            // 
            // lb_RequestType
            // 
            this.lb_RequestType.AutoSize = true;
            this.lb_RequestType.Location = new System.Drawing.Point(155, 17);
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
            this.cb_Request.Location = new System.Drawing.Point(157, 33);
            this.cb_Request.Name = "cb_Request";
            this.cb_Request.Size = new System.Drawing.Size(116, 20);
            this.cb_Request.TabIndex = 15;
            this.cb_Request.Text = "api/hedajwreq";
            // 
            // lb_Data
            // 
            this.lb_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_Data.AutoSize = true;
            this.lb_Data.Location = new System.Drawing.Point(18, 402);
            this.lb_Data.Name = "lb_Data";
            this.lb_Data.Size = new System.Drawing.Size(89, 12);
            this.lb_Data.TabIndex = 9;
            this.lb_Data.Text = "Json请求数据：";
            // 
            // rtb_Data
            // 
            this.rtb_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtb_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_Data.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_Data.Location = new System.Drawing.Point(12, 417);
            this.rtb_Data.Name = "rtb_Data";
            this.rtb_Data.Size = new System.Drawing.Size(177, 121);
            this.rtb_Data.TabIndex = 10;
            this.rtb_Data.Text = "";
            this.rtb_Data.TextChanged += new System.EventHandler(this.rtb_Data_TextChanged);
            // 
            // lb_ACK
            // 
            this.lb_ACK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ACK.AutoSize = true;
            this.lb_ACK.Location = new System.Drawing.Point(212, 165);
            this.lb_ACK.Name = "lb_ACK";
            this.lb_ACK.Size = new System.Drawing.Size(65, 12);
            this.lb_ACK.TabIndex = 11;
            this.lb_ACK.Text = "测试日志：";
            // 
            // rtb_ACK
            // 
            this.rtb_ACK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_ACK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_ACK.Location = new System.Drawing.Point(209, 186);
            this.rtb_ACK.Name = "rtb_ACK";
            this.rtb_ACK.Size = new System.Drawing.Size(529, 352);
            this.rtb_ACK.TabIndex = 12;
            this.rtb_ACK.Text = "";
            // 
            // lb_TestCount
            // 
            this.lb_TestCount.AutoSize = true;
            this.lb_TestCount.Location = new System.Drawing.Point(16, 22);
            this.lb_TestCount.Name = "lb_TestCount";
            this.lb_TestCount.Size = new System.Drawing.Size(65, 12);
            this.lb_TestCount.TabIndex = 16;
            this.lb_TestCount.Text = "测试次数：";
            // 
            // nud_Count
            // 
            this.nud_Count.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nud_Count.Location = new System.Drawing.Point(87, 20);
            this.nud_Count.Name = "nud_Count";
            this.nud_Count.Size = new System.Drawing.Size(61, 21);
            this.nud_Count.TabIndex = 17;
            this.nud_Count.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lb_TreeView
            // 
            this.lb_TreeView.AutoSize = true;
            this.lb_TreeView.Location = new System.Drawing.Point(18, 165);
            this.lb_TreeView.Name = "lb_TreeView";
            this.lb_TreeView.Size = new System.Drawing.Size(113, 12);
            this.lb_TreeView.TabIndex = 9;
            this.lb_TreeView.Text = "性能测试请求列表：";
            // 
            // gb_TargetServer
            // 
            this.gb_TargetServer.Controls.Add(this.Lbl_IP);
            this.gb_TargetServer.Controls.Add(this.Lbl_Port);
            this.gb_TargetServer.Controls.Add(this.Tb_IP);
            this.gb_TargetServer.Controls.Add(this.cb_Request);
            this.gb_TargetServer.Controls.Add(this.Tb_Port);
            this.gb_TargetServer.Controls.Add(this.lb_RequestType);
            this.gb_TargetServer.Location = new System.Drawing.Point(12, 13);
            this.gb_TargetServer.Name = "gb_TargetServer";
            this.gb_TargetServer.Size = new System.Drawing.Size(284, 66);
            this.gb_TargetServer.TabIndex = 18;
            this.gb_TargetServer.TabStop = false;
            this.gb_TargetServer.Text = "测试服务器信息";
            // 
            // btn_LogPathChoose
            // 
            this.btn_LogPathChoose.Location = new System.Drawing.Point(6, 24);
            this.btn_LogPathChoose.Name = "btn_LogPathChoose";
            this.btn_LogPathChoose.Size = new System.Drawing.Size(73, 32);
            this.btn_LogPathChoose.TabIndex = 19;
            this.btn_LogPathChoose.Text = "修改目录";
            this.btn_LogPathChoose.UseVisualStyleBackColor = true;
            this.btn_LogPathChoose.Click += new System.EventHandler(this.btn_LogPathChoose_Click);
            // 
            // tb_LogPath
            // 
            this.tb_LogPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_LogPath.Location = new System.Drawing.Point(88, 32);
            this.tb_LogPath.Name = "tb_LogPath";
            this.tb_LogPath.Size = new System.Drawing.Size(327, 21);
            this.tb_LogPath.TabIndex = 20;
            this.tb_LogPath.Text = "C:\\";
            // 
            // lb_LogPath
            // 
            this.lb_LogPath.AutoSize = true;
            this.lb_LogPath.Location = new System.Drawing.Point(86, 17);
            this.lb_LogPath.Name = "lb_LogPath";
            this.lb_LogPath.Size = new System.Drawing.Size(89, 12);
            this.lb_LogPath.TabIndex = 16;
            this.lb_LogPath.Text = "日志存放位置：";
            // 
            // pbar_TestProcess
            // 
            this.pbar_TestProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbar_TestProcess.Location = new System.Drawing.Point(164, 34);
            this.pbar_TestProcess.Name = "pbar_TestProcess";
            this.pbar_TestProcess.Size = new System.Drawing.Size(246, 32);
            this.pbar_TestProcess.TabIndex = 21;
            // 
            // lb_Process
            // 
            this.lb_Process.AutoSize = true;
            this.lb_Process.BackColor = System.Drawing.SystemColors.Control;
            this.lb_Process.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_Process.Location = new System.Drawing.Point(162, 20);
            this.lb_Process.Name = "lb_Process";
            this.lb_Process.Size = new System.Drawing.Size(77, 12);
            this.lb_Process.TabIndex = 9;
            this.lb_Process.Text = "测试进度:(/)";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(85, 34);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(73, 32);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "停止测试";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // gb_RequestType
            // 
            this.gb_RequestType.Controls.Add(this.rb_GET);
            this.gb_RequestType.Controls.Add(this.rb_POST_UTF8);
            this.gb_RequestType.Controls.Add(this.rb_POST);
            this.gb_RequestType.Location = new System.Drawing.Point(181, 85);
            this.gb_RequestType.Name = "gb_RequestType";
            this.gb_RequestType.Size = new System.Drawing.Size(115, 72);
            this.gb_RequestType.TabIndex = 22;
            this.gb_RequestType.TabStop = false;
            this.gb_RequestType.Text = "请求格式";
            // 
            // rb_GET
            // 
            this.rb_GET.AutoSize = true;
            this.rb_GET.Location = new System.Drawing.Point(13, 52);
            this.rb_GET.Name = "rb_GET";
            this.rb_GET.Size = new System.Drawing.Size(41, 16);
            this.rb_GET.TabIndex = 0;
            this.rb_GET.Text = "GET";
            this.rb_GET.UseVisualStyleBackColor = true;
            this.rb_GET.CheckedChanged += new System.EventHandler(this.rb_GET_CheckedChanged);
            // 
            // rb_POST_UTF8
            // 
            this.rb_POST_UTF8.AutoSize = true;
            this.rb_POST_UTF8.Location = new System.Drawing.Point(13, 34);
            this.rb_POST_UTF8.Name = "rb_POST_UTF8";
            this.rb_POST_UTF8.Size = new System.Drawing.Size(83, 16);
            this.rb_POST_UTF8.TabIndex = 0;
            this.rb_POST_UTF8.Text = "POST(UTF8)";
            this.rb_POST_UTF8.UseVisualStyleBackColor = true;
            this.rb_POST_UTF8.CheckedChanged += new System.EventHandler(this.rb_POST_UTF8_CheckedChanged);
            // 
            // rb_POST
            // 
            this.rb_POST.AutoSize = true;
            this.rb_POST.Checked = true;
            this.rb_POST.Location = new System.Drawing.Point(13, 17);
            this.rb_POST.Name = "rb_POST";
            this.rb_POST.Size = new System.Drawing.Size(47, 16);
            this.rb_POST.TabIndex = 0;
            this.rb_POST.TabStop = true;
            this.rb_POST.Text = "POST";
            this.rb_POST.UseVisualStyleBackColor = true;
            this.rb_POST.CheckedChanged += new System.EventHandler(this.rb_POST_CheckedChanged);
            // 
            // btn_Begin
            // 
            this.btn_Begin.Location = new System.Drawing.Point(6, 34);
            this.btn_Begin.Name = "btn_Begin";
            this.btn_Begin.Size = new System.Drawing.Size(73, 32);
            this.btn_Begin.TabIndex = 13;
            this.btn_Begin.Text = "开始测试";
            this.btn_Begin.UseVisualStyleBackColor = true;
            this.btn_Begin.Click += new System.EventHandler(this.btn_Begin_Click);
            // 
            // lb_Interval
            // 
            this.lb_Interval.AutoSize = true;
            this.lb_Interval.Location = new System.Drawing.Point(16, 50);
            this.lb_Interval.Name = "lb_Interval";
            this.lb_Interval.Size = new System.Drawing.Size(77, 12);
            this.lb_Interval.TabIndex = 16;
            this.lb_Interval.Text = "间隔(毫秒)：";
            // 
            // gb_LogControl
            // 
            this.gb_LogControl.Controls.Add(this.lb_LogPath);
            this.gb_LogControl.Controls.Add(this.tb_LogPath);
            this.gb_LogControl.Controls.Add(this.btn_LogPathChoose);
            this.gb_LogControl.Location = new System.Drawing.Point(317, 13);
            this.gb_LogControl.Name = "gb_LogControl";
            this.gb_LogControl.Size = new System.Drawing.Size(421, 66);
            this.gb_LogControl.TabIndex = 23;
            this.gb_LogControl.TabStop = false;
            this.gb_LogControl.Text = "日志管理";
            // 
            // gb_TestRequirements
            // 
            this.gb_TestRequirements.Controls.Add(this.tb_TestInterval);
            this.gb_TestRequirements.Controls.Add(this.lb_TestCount);
            this.gb_TestRequirements.Controls.Add(this.nud_Count);
            this.gb_TestRequirements.Controls.Add(this.lb_Interval);
            this.gb_TestRequirements.Location = new System.Drawing.Point(12, 85);
            this.gb_TestRequirements.Name = "gb_TestRequirements";
            this.gb_TestRequirements.Size = new System.Drawing.Size(163, 72);
            this.gb_TestRequirements.TabIndex = 24;
            this.gb_TestRequirements.TabStop = false;
            this.gb_TestRequirements.Text = "测试要求";
            // 
            // tb_TestInterval
            // 
            this.tb_TestInterval.Location = new System.Drawing.Point(87, 47);
            this.tb_TestInterval.Name = "tb_TestInterval";
            this.tb_TestInterval.Size = new System.Drawing.Size(61, 21);
            this.tb_TestInterval.TabIndex = 18;
            this.tb_TestInterval.Text = "100";
            // 
            // gb_TestManage
            // 
            this.gb_TestManage.Controls.Add(this.btn_Begin);
            this.gb_TestManage.Controls.Add(this.btn_Cancel);
            this.gb_TestManage.Controls.Add(this.lb_Process);
            this.gb_TestManage.Controls.Add(this.pbar_TestProcess);
            this.gb_TestManage.Location = new System.Drawing.Point(317, 85);
            this.gb_TestManage.Name = "gb_TestManage";
            this.gb_TestManage.Size = new System.Drawing.Size(416, 72);
            this.gb_TestManage.TabIndex = 25;
            this.gb_TestManage.TabStop = false;
            this.gb_TestManage.Text = "测试控制";
            // 
            // FrmPerformentTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.gb_TestManage);
            this.Controls.Add(this.gb_TestRequirements);
            this.Controls.Add(this.gb_LogControl);
            this.Controls.Add(this.gb_RequestType);
            this.Controls.Add(this.gb_TargetServer);
            this.Controls.Add(this.rtb_ACK);
            this.Controls.Add(this.lb_ACK);
            this.Controls.Add(this.rtb_Data);
            this.Controls.Add(this.lb_TreeView);
            this.Controls.Add(this.lb_Data);
            this.Controls.Add(this.tv_Method);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPerformentTest";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Count)).EndInit();
            this.gb_TargetServer.ResumeLayout(false);
            this.gb_TargetServer.PerformLayout();
            this.gb_RequestType.ResumeLayout(false);
            this.gb_RequestType.PerformLayout();
            this.gb_LogControl.ResumeLayout(false);
            this.gb_LogControl.PerformLayout();
            this.gb_TestRequirements.ResumeLayout(false);
            this.gb_TestRequirements.PerformLayout();
            this.gb_TestManage.ResumeLayout(false);
            this.gb_TestManage.PerformLayout();
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
        private System.Windows.Forms.Label lb_ACK;
        private System.Windows.Forms.RichTextBox rtb_ACK;
        private System.Windows.Forms.Label lb_RequestType;
        private System.Windows.Forms.ComboBox cb_Request;
        private System.Windows.Forms.Label lb_TestCount;
        private System.Windows.Forms.NumericUpDown nud_Count;
        private System.Windows.Forms.Label lb_TreeView;
        private System.Windows.Forms.GroupBox gb_TargetServer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_LogPathChoose;
        private System.Windows.Forms.TextBox tb_LogPath;
        private System.Windows.Forms.Label lb_LogPath;
        private System.Windows.Forms.ProgressBar pbar_TestProcess;
        private System.Windows.Forms.Label lb_Process;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox gb_RequestType;
        private System.Windows.Forms.RadioButton rb_GET;
        private System.Windows.Forms.RadioButton rb_POST_UTF8;
        private System.Windows.Forms.RadioButton rb_POST;
        private System.Windows.Forms.Button btn_Begin;
        private System.Windows.Forms.Label lb_Interval;
        private System.Windows.Forms.GroupBox gb_LogControl;
        private System.Windows.Forms.GroupBox gb_TestRequirements;
        private System.Windows.Forms.GroupBox gb_TestManage;
        private System.Windows.Forms.TextBox tb_TestInterval;
    }
}