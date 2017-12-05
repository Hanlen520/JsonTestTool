using JsonTestTool.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace JsonTestTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsMenu_Normal_Click(object sender, EventArgs e)
        {
            pl_Main.Controls.Clear();
            FrmTestSystem fts = new FrmTestSystem();
            fts.FormBorderStyle = FormBorderStyle.None;
            fts.Dock = System.Windows.Forms.DockStyle.Fill;
            fts.TopLevel = false;
            pl_Main.Controls.Add(fts);
            fts.Show();
        }

        private void tsMenu_Performance_Click(object sender, EventArgs e)
        {
            pl_Main.Controls.Clear();
            FrmPerformentTest fpts = new FrmPerformentTest();
            fpts.FormBorderStyle = FormBorderStyle.None;
            fpts.Dock = System.Windows.Forms.DockStyle.Fill;
            fpts.TopLevel = false;
            pl_Main.Controls.Add(fpts);
            fpts.Show();
        }

        private void tsMenu_Help_Click(object sender, EventArgs e)
        {
            try
            {
                this.pl_Main.Controls.Clear();
                HelpForm infoForm = new HelpForm();
                infoForm.FormBorderStyle = FormBorderStyle.None;
                infoForm.Dock = System.Windows.Forms.DockStyle.Fill;
                infoForm.TopLevel = false;
                this.pl_Main.Controls.Add(infoForm);
                infoForm.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Can't Open About Infomation Page.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.pl_Main.Controls.Clear();
                FrmTestSystem fts = new FrmTestSystem();
                fts.FormBorderStyle = FormBorderStyle.None;
                fts.Dock = System.Windows.Forms.DockStyle.Fill;
                fts.TopLevel = false;
                this.pl_Main.Controls.Add(fts);
                fts.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Can't Open Form Page.");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Yes：关闭。No：取消", "是否关闭本程序?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                catch (Exception ex)
                {
                    Environment.Exit(0);
                    this.Close();
                }
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void tsMenu_About_Click(object sender, EventArgs e)
        {
            try
            {
                this.pl_Main.Controls.Clear();
                InfoForm infoForm = new InfoForm();
                infoForm.FormBorderStyle = FormBorderStyle.None;
                infoForm.Dock = System.Windows.Forms.DockStyle.Fill;
                infoForm.TopLevel = false;
                this.pl_Main.Controls.Add(infoForm);
                infoForm.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Can't Open Form Page.");
            }

        }
    }
}
