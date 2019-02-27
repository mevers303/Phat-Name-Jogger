namespace NameJogger
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVerByte = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVideoDump = new System.Windows.Forms.Button();
            this.txtVideoDump = new System.Windows.Forms.TextBox();
            this.btnFile3 = new System.Windows.Forms.Button();
            this.txtFile3 = new System.Windows.Forms.TextBox();
            this.btnFile2 = new System.Windows.Forms.Button();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.btnFile1 = new System.Windows.Forms.Button();
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.txtConnectDelay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtVerByte);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnVideoDump);
            this.groupBox2.Controls.Add(this.txtVideoDump);
            this.groupBox2.Controls.Add(this.btnFile3);
            this.groupBox2.Controls.Add(this.txtFile3);
            this.groupBox2.Controls.Add(this.btnFile2);
            this.groupBox2.Controls.Add(this.txtFile2);
            this.groupBox2.Controls.Add(this.btnFile1);
            this.groupBox2.Controls.Add(this.txtFile1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 255);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hashes";
            // 
            // txtVerByte
            // 
            this.txtVerByte.Location = new System.Drawing.Point(6, 225);
            this.txtVerByte.Name = "txtVerByte";
            this.txtVerByte.Size = new System.Drawing.Size(50, 20);
            this.txtVerByte.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Verbyte:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Video Dump:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Game File 3:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Game File 2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Game Exe:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "D2DV",
            "D2XP",
            "WAR3",
            "W3XP",
            "STAR",
            "SEXP",
            "W2BN"});
            this.comboBox1.Location = new System.Drawing.Point(91, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select product:";
            // 
            // btnVideoDump
            // 
            this.btnVideoDump.Location = new System.Drawing.Point(343, 186);
            this.btnVideoDump.Name = "btnVideoDump";
            this.btnVideoDump.Size = new System.Drawing.Size(75, 20);
            this.btnVideoDump.TabIndex = 9;
            this.btnVideoDump.Text = "Browse";
            this.btnVideoDump.UseVisualStyleBackColor = true;
            this.btnVideoDump.Click += new System.EventHandler(this.btnVideoDump_Click);
            // 
            // txtVideoDump
            // 
            this.txtVideoDump.Location = new System.Drawing.Point(6, 186);
            this.txtVideoDump.Name = "txtVideoDump";
            this.txtVideoDump.Size = new System.Drawing.Size(331, 20);
            this.txtVideoDump.TabIndex = 8;
            // 
            // btnFile3
            // 
            this.btnFile3.Location = new System.Drawing.Point(343, 147);
            this.btnFile3.Name = "btnFile3";
            this.btnFile3.Size = new System.Drawing.Size(75, 20);
            this.btnFile3.TabIndex = 7;
            this.btnFile3.Text = "Browse";
            this.btnFile3.UseVisualStyleBackColor = true;
            this.btnFile3.Click += new System.EventHandler(this.btnFile3_Click);
            // 
            // txtFile3
            // 
            this.txtFile3.Location = new System.Drawing.Point(6, 147);
            this.txtFile3.Name = "txtFile3";
            this.txtFile3.Size = new System.Drawing.Size(331, 20);
            this.txtFile3.TabIndex = 6;
            // 
            // btnFile2
            // 
            this.btnFile2.Location = new System.Drawing.Point(343, 108);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(75, 20);
            this.btnFile2.TabIndex = 5;
            this.btnFile2.Text = "Browse";
            this.btnFile2.UseVisualStyleBackColor = true;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // txtFile2
            // 
            this.txtFile2.Location = new System.Drawing.Point(6, 108);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.Size = new System.Drawing.Size(331, 20);
            this.txtFile2.TabIndex = 4;
            // 
            // btnFile1
            // 
            this.btnFile1.Location = new System.Drawing.Point(343, 65);
            this.btnFile1.Name = "btnFile1";
            this.btnFile1.Size = new System.Drawing.Size(75, 20);
            this.btnFile1.TabIndex = 3;
            this.btnFile1.Text = "Browse";
            this.btnFile1.UseVisualStyleBackColor = true;
            this.btnFile1.Click += new System.EventHandler(this.btnFile1_Click);
            // 
            // txtFile1
            // 
            this.txtFile1.Location = new System.Drawing.Point(6, 65);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.Size = new System.Drawing.Size(331, 20);
            this.txtFile1.TabIndex = 2;
            // 
            // txtConnectDelay
            // 
            this.txtConnectDelay.Location = new System.Drawing.Point(18, 286);
            this.txtConnectDelay.Name = "txtConnectDelay";
            this.txtConnectDelay.Size = new System.Drawing.Size(50, 20);
            this.txtConnectDelay.TabIndex = 11;
            this.txtConnectDelay.Text = "7500";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Connect Delay (ms):";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(358, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 20);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(277, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 20);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "Hash files|*.exe;*.snp;*.dll;*.bin|All files|*.*";
            this.fileDialog.Title = "Select hashes";
            // 
            // frmConfig
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 315);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtConnectDelay);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfig";
            this.Text = "Phat Name Jogger  - Config";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.Button btnFile1;
        private System.Windows.Forms.Button btnVideoDump;
        private System.Windows.Forms.TextBox txtVideoDump;
        private System.Windows.Forms.Button btnFile3;
        private System.Windows.Forms.TextBox txtFile3;
        private System.Windows.Forms.Button btnFile2;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVerByte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConnectDelay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog fileDialog;

    }
}