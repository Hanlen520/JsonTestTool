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

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                highLightMenuStrip(menuStripType.Normal);
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
                MessageBox.Show(string.Format("程序加载出现问题：", ex.Message));
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Yes：关闭。No：取消", "是否关闭本程序？", MessageBoxButtons.YesNo);
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

        private void tsMenu_Normal_Click(object sender, EventArgs e)
        {
            try
            {
                highLightMenuStrip(menuStripType.Normal);
                pl_Main.Controls.Clear();
                FrmTestSystem fts = new FrmTestSystem();
                fts.FormBorderStyle = FormBorderStyle.None;
                fts.Dock = System.Windows.Forms.DockStyle.Fill;
                fts.TopLevel = false;
                pl_Main.Controls.Add(fts);
                fts.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("未能正常加载常规测试模块。{0}", ex.Message));
            }
        }

        private void tsMenu_Performance_Click(object sender, EventArgs e)
        {
            try
            {
                highLightMenuStrip(menuStripType.Performance);
                pl_Main.Controls.Clear();
                FrmPerformentTest fpts = new FrmPerformentTest();
                fpts.FormBorderStyle = FormBorderStyle.None;
                fpts.Dock = System.Windows.Forms.DockStyle.Fill;
                fpts.TopLevel = false;
                pl_Main.Controls.Add(fpts);
                fpts.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("未能正常加载性能测试模块。{0}", ex.Message));
            }
        }

        private void tsMenu_Help_Click(object sender, EventArgs e)
        {
            try
            {
                highLightMenuStrip(menuStripType.Help);
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
                MessageBox.Show(string.Format("未能正常加载帮助页面。{0}", ex.Message));
            }
        }

        private void tsMenu_About_Click(object sender, EventArgs e)
        {
            try
            {
                highLightMenuStrip(menuStripType.About);
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
                MessageBox.Show(string.Format("未能正确加载关于页面。{0}", ex.Message));
            }
        }

        private void tsMenu_Polling_Click(object sender, EventArgs e)
        {
            try
            {
                highLightMenuStrip(menuStripType.Polling);
                this.pl_Main.Controls.Clear();
                FrmPollingTest pollingTestForm = new FrmPollingTest();
                pollingTestForm.FormBorderStyle = FormBorderStyle.None;
                pollingTestForm.Dock = System.Windows.Forms.DockStyle.Fill;
                pollingTestForm.TopLevel = false;
                this.pl_Main.Controls.Add(pollingTestForm);
                pollingTestForm.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(string.Format("未能正常加载批量测试模块。{0}", ex.Message));
            }
        }

        private void highLightMenuStrip(menuStripType mst)
        {
            foreach (ToolStripItem temp in menuStripInForm.Items)
            {
                temp.BackColor = SystemColors.Control;
            }
            switch (mst)
            {
                case menuStripType.Normal:
                    tsMenu_Normal.BackColor = Color.LightSkyBlue;
                    break;
                case menuStripType.Performance:
                    tsMenu_Performance.BackColor = Color.LightSkyBlue;
                    break;
                case menuStripType.Polling:
                    tsMenu_Polling.BackColor = Color.LightSkyBlue;
                    break;
                case menuStripType.Help:
                    tsMenu_Help.BackColor = Color.LightSkyBlue;
                    break;
                case menuStripType.About:
                    tsMenu_About.BackColor = Color.LightSkyBlue;
                    break;
                default:
                    break;
            }
        }

        private void pl_Main_ControlRemoved(object sender, ControlEventArgs e)
        {
            string temp = "";
        }
    }
}
