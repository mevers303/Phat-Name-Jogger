using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace NameJogger
{
    public partial class frmBot : Form
    {
        private frmMain mainForm;
        public frmBot(frmMain form)
        {
            mainForm = form;
            InitializeComponent();
        }
        public void loadPresets(string name)
        {

            txtName.Text = name;
            this.Text = "Phat NJ - Edit Settings (" + name + ")";

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Phat NJ\\Profiles\\" + txtName.Text, true);
            if (key == null)
                return;

            txtCDKey.Text = (string)key.GetValue("CD Key", "");
            txtCDKey2.Text = (string)key.GetValue("Expansion CD Key", "");
            txtDelay.Text =  key.GetValue("Delay", 300).ToString();
            txtHome.Text = (string)key.GetValue("Home", "");
            txtNameList.Text = (string)key.GetValue("Name List", "");
            txtPassword.Text = (string)key.GetValue("Password", "");
            txtProduct.Text = (string)key.GetValue("Product", "");
            txtServer.Text = (string)key.GetValue("Server", "");

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            bool newBot = false;

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Phat NJ\\Profiles\\" + txtName.Text, true);
            if (key == null)
            {
                newBot = true;
                key = Registry.CurrentUser.CreateSubKey("Software\\Phat NJ\\Profiles\\" + txtName.Text, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            key.SetValue("CD Key", txtCDKey.Text);
            key.SetValue("Expansion CD Key", txtCDKey2.Text);
            key.SetValue("Delay", txtDelay.Text, RegistryValueKind.DWord);
            key.SetValue("Home", txtHome.Text);
            key.SetValue("Name List", txtNameList.Text);
            key.SetValue("Password", txtPassword.Text);
            key.SetValue("Product", txtProduct.Text);
            key.SetValue("Server", txtServer.Text);

            if (newBot)
                mainForm.addBot(txtName.Text);
            else
                mainForm.updateBot(txtName.Text);

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNameList.TextLength > 0)
            {
                fileDialog.InitialDirectory = Path.GetDirectoryName(txtNameList.Text);
                fileDialog.FileName = Path.GetFileName(txtNameList.Text);
            }

            if (fileDialog.ShowDialog() == DialogResult.OK)
                txtNameList.Text = fileDialog.FileName;
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if ((txtProduct.Text == "D2XP") || (txtProduct.Text == "W3XP"))
            {
                label9.Visible = true;
                txtCDKey2.Visible = true;
            }
            else
            {
                label9.Visible = false;
                txtCDKey2.Visible = false;
            }
        }
    }
}
