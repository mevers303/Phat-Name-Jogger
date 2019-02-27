using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace NameJogger
{
    public partial class frmMain : Form
    {

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private Dictionary<string, botJogger> bots = new Dictionary<string, botJogger>();
        private bool consoleVisible = false;
        private Size oldSize;

        public frmMain()
        {
            ShowWindow(FindWindow(null, Console.Title), 0);
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            botJogger.form = this;

            if (Registry.CurrentUser.OpenSubKey("Software\\Phat NJ") == null)
                Registry.CurrentUser.CreateSubKey("Software\\Phat NJ");
            if (Registry.CurrentUser.OpenSubKey("Software\\Phat NJ\\Profiles") == null)
                Registry.CurrentUser.CreateSubKey("Software\\Phat NJ\\Profiles");
            if (Registry.CurrentUser.OpenSubKey("Software\\Phat NJ\\List Indexes") == null)
                Registry.CurrentUser.CreateSubKey("Software\\Phat NJ\\List Indexes");

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Phat NJ");
            string[] subKeys = key.OpenSubKey("Profiles").GetSubKeyNames();

            foreach (string subKey in subKeys)
                addBot(subKey);

            
            this.Focus();
            toolStripMenuItem1.PerformClick();

        }

        public void addBot(string name)
        {

            ListViewItem item = listView1.Items.Add(name);
            item.SubItems.Add("");
            item.SubItems.Add("Loading bot...");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.Tag = new botJogger(name, item);

        }

        public void updateBot(string name)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text == name)
                {
                    string status = item.SubItems[2].Text;
                    Color c = item.ForeColor;

                    botJogger bot = (botJogger)item.Tag;
                    bot.loadConfig();
                    bot.setStatus(status, c);
                    break;
                }
            }
        }

        private void addBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBot form = new frmBot(this);
            form.Show(this);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
            else
                listView1.Size = new Size(this.Size.Width - 16, this.Size.Height - 62);
        }

        private void editSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                {
                    frmBot form = new frmBot(this);
                    form.loadPresets(item.Text);
                    form.Show(this);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Focus();
            SendKeys.Send("^{+}");
            Application.DoEvents();
            int width = 0;
            foreach (ColumnHeader column in listView1.Columns)
                width += column.Width;
            this.Size = new Size(width + 20, this.Size.Height);
        }

        private void connectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                botJogger bot = (botJogger)item.Tag;
                if (!bot.connected)
                    bot.jogNext();
            }
        }

        private void disconnectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                botJogger bot = (botJogger)item.Tag;
                bot.close();
                bot.setStatus("Disconnected!", Color.Red);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                {
                    botJogger bot = (botJogger)item.Tag;
                    bot.close();
                    item.Remove();
                    Registry.CurrentUser.DeleteSubKeyTree("Software\\Phat NJ\\Profiles\\" + bot.name);
                }
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                {
                    botJogger bot = (botJogger)item.Tag;
                    if (!bot.connected)
                        bot.jogNext();
                }
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                {
                    botJogger bot = (botJogger)item.Tag;
                    bot.close();
                }
            }
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfig form = new frmConfig();
            form.Show(this);
        }

        private void openNameListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected)
                {
                    botJogger bot = (botJogger)item.Tag;
                    System.Diagnostics.Process.Start(bot.nameList);
                }
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((ModifierKeys == Keys.Control) && (e.KeyChar == 4)))
            {
                int cmd = consoleVisible ? 0 : 1;
                ShowWindow(FindWindow(null, Console.Title), cmd);
                consoleVisible = !consoleVisible;
            }
        }

        private void listView1_Resize(object sender, EventArgs e)
        {

            

            oldSize = listView1.Size;

        }

        private void statusUpdater_Tick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
                ((botJogger)item.Tag).refreshWaitTime();
        }

    }
}
