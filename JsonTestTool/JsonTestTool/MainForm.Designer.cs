namespace JsonTestTool
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsMenu_Normal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenu_Performance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenu_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenu_About = new System.Windows.Forms.ToolStripMenuItem();
            this.pl_Main = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenu_Normal,
            this.tsMenu_Performance,
            this.tsMenu_Help,
            this.tsMenu_About});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsMenu_Normal
            // 
            this.tsMenu_Normal.Name = "tsMenu_Normal";
            this.tsMenu_Normal.Size = new System.Drawing.Size(68, 21);
            this.tsMenu_Normal.Text = "常规测试";
            this.tsMenu_Normal.Click += new System.EventHandler(this.tsMenu_Normal_Click);
            // 
            // tsMenu_Performance
            // 
            this.tsMenu_Performance.Name = "tsMenu_Performance";
            this.tsMenu_Performance.Size = new System.Drawing.Size(68, 21);
            this.tsMenu_Performance.Text = "性能测试";
            this.tsMenu_Performance.Click += new System.EventHandler(this.tsMenu_Performance_Click);
            // 
            // tsMenu_Help
            // 
            this.tsMenu_Help.Name = "tsMenu_Help";
            this.tsMenu_Help.Size = new System.Drawing.Size(44, 21);
            this.tsMenu_Help.Text = "帮助";
            this.tsMenu_Help.Click += new System.EventHandler(this.tsMenu_Help_Click);
            // 
            // tsMenu_About
            // 
            this.tsMenu_About.Name = "tsMenu_About";
            this.tsMenu_About.Size = new System.Drawing.Size(44, 21);
            this.tsMenu_About.Text = "关于";
            // 
            // pl_Main
            // 
            this.pl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_Main.Location = new System.Drawing.Point(0, 28);
            this.pl_Main.Name = "pl_Main";
            this.pl_Main.Size = new System.Drawing.Size(798, 678);
            this.pl_Main.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 642);
            this.Controls.Add(this.pl_Main);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Json Test Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsMenu_Normal;
        private System.Windows.Forms.ToolStripMenuItem tsMenu_Performance;
        private System.Windows.Forms.ToolStripMenuItem tsMenu_Help;
        private System.Windows.Forms.ToolStripMenuItem tsMenu_About;
        private System.Windows.Forms.Panel pl_Main;
    }
}

