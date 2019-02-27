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
    public partial class frmConfig : Form
    {

        private string product = "";



        public frmConfig()
        {
            InitializeComponent();
        }

        private void saveSettings()
        {

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Phat NJ", true);

            if (product.Length == 4)
            {
                key.SetValue(product + " File 1", txtFile1.Text);
                key.SetValue(product + " File 2", txtFile2.Text);
                key.SetValue(product + " File 3", txtFile3.Text);
                key.SetValue(product + " Video Dump", txtVideoDump.Text);
                key.SetValue(product + " VerByte", int.Parse(txtVerByte.Text, System.Globalization.NumberStyles.HexNumber), RegistryValueKind.DWord);
                key.SetValue("Connect Delay", int.Parse(txtConnectDelay.Text), RegistryValueKind.DWord);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            saveSettings();

            product = comboBox1.Text;


            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Phat NJ");

            txtFile1.Text = (string)key.GetValue(product + " File 1", "");
            txtFile2.Text = (string)key.GetValue(product + " File 2", "");
            txtFile3.Text = (string)key.GetValue(product + " File 3", "");
            txtVideoDump.Text = (string)key.GetValue(product + " Video Dump", "");
            txtVerByte.Text = ((int)key.GetValue(product + " VerByte", 0)).ToString("X");

            if ((comboBox1.Text == "STAR") || (comboBox1.Text == "SEXP") || (comboBox1.Text == "W2BN"))
            {
                label5.Visible = true;
                txtVideoDump.Visible = true;
                btnVideoDump.Visible = true;
            }
            else
            {
                label5.Visible = false;
                txtVideoDump.Visible = false;
                btnVideoDump.Visible = false;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            product = comboBox1.Text;
            saveSettings();
            this.Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            txtConnectDelay.Text = Registry.CurrentUser.OpenSubKey("Software\\Phat NJ").GetValue("Connect Delay", 300).ToString();
            comboBox1.Text = "D2DV";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to close the configuration without saving the settings?", "Close without saving?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                this.Close();
        }

        private void btnFile1_Click(object sender, EventArgs e)
        {

            if (txtFile1.TextLength > 0)
            {
                fileDialog.InitialDirectory = Path.GetDirectoryName(txtFile1.Text);
                fileDialog.FileName = Path.GetFileName(txtFile1.Text);
            }

            if (fileDialog.ShowDialog() == DialogResult.OK)
                txtFile1.Text = fileDialog.FileName;

        }

        private void btnFile2_Click(object sender, EventArgs e)
        {

            if (txtFile2.TextLength > 0)
            {
                fileDialog.InitialDirectory = Path.GetDirectoryName(txtFile2.Text);
                fileDialog.FileName = Path.GetFileName(txtFile2.Text);
            }

            if (fileDialog.ShowDialog() == DialogResult.OK)
                txtFile2.Text = fileDialog.FileName;

        }

        private void btnFile3_Click(object sender, EventArgs e)
        {

            if (txtFile3.TextLength > 0)
            {
                fileDialog.InitialDirectory = Path.GetDirectoryName(txtFile3.Text);
                fileDialog.FileName = Path.GetFileName(txtFile3.Text);
            }

            if (fileDialog.ShowDialog() == DialogResult.OK)
                txtFile3.Text = fileDialog.FileName;

        }

        private void btnVideoDump_Click(object sender, EventArgs e)
        {

            if (txtVideoDump.TextLength > 0)
            {
                fileDialog.InitialDirectory = Path.GetDirectoryName(txtVideoDump.Text);
                fileDialog.FileName = Path.GetFileName(txtVideoDump.Text);
            }

            if (fileDialog.ShowDialog() == DialogResult.OK)
                txtVideoDump.Text = fileDialog.FileName;

        }
 
    }
}
