namespace SSISSFTPTask100
{
    partial class frmEditProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditProperties));
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkSleep = new System.Windows.Forms.CheckBox();
            this.linkLabelCodeplex = new System.Windows.Forms.LinkLabel();
            this.cmbRemote = new System.Windows.Forms.ComboBox();
            this.optFileVariable = new System.Windows.Forms.RadioButton();
            this.optFileConnection = new System.Windows.Forms.RadioButton();
            this.cmbLocal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilesList = new System.Windows.Forms.ComboBox();
            this.btDestinationFile = new System.Windows.Forms.Button();
            this.lbDestinationFile = new System.Windows.Forms.Label();
            this.btSourceFile = new System.Windows.Forms.Button();
            this.lbSourceFile = new System.Windows.Forms.Label();
            this.lbAction = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.optionEncryptionKey = new System.Windows.Forms.RadioButton();
            this.optionEncryptionPassword = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPassword = new System.Windows.Forms.ComboBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.groupBoxEncryption = new System.Windows.Forms.GroupBox();
            this.cmbPassPhrase = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.optPrivateKeyFileVariable = new System.Windows.Forms.RadioButton();
            this.optPrivateKeyFileConnection = new System.Windows.Forms.RadioButton();
            this.cmbKeyFile = new System.Windows.Forms.ComboBox();
            this.btKeyFileExpression = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.groupBoxConnection.SuspendLayout();
            this.groupBoxEncryption.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(299, 425);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(59, 26);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(364, 425);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(59, 26);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // chkSleep
            // 
            this.chkSleep.AutoSize = true;
            this.chkSleep.Location = new System.Drawing.Point(101, 385);
            this.chkSleep.Name = "chkSleep";
            this.chkSleep.Size = new System.Drawing.Size(123, 17);
            this.chkSleep.TabIndex = 62;
            this.chkSleep.Text = "Sleep on disconnect";
            this.chkSleep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chkSleep, "To avoid overload connections. Give it the time to disconnect completely.");
            this.chkSleep.UseVisualStyleBackColor = true;
            this.chkSleep.Click += new System.EventHandler(this.chkSleep_Click);
            // 
            // linkLabelCodeplex
            // 
            this.linkLabelCodeplex.AutoSize = true;
            this.linkLabelCodeplex.Location = new System.Drawing.Point(7, 438);
            this.linkLabelCodeplex.Name = "linkLabelCodeplex";
            this.linkLabelCodeplex.Size = new System.Drawing.Size(141, 13);
            this.linkLabelCodeplex.TabIndex = 10;
            this.linkLabelCodeplex.TabStop = true;
            this.linkLabelCodeplex.Text = "http://ssissftp.codeplex.com";
            this.linkLabelCodeplex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCodeplex_LinkClicked);
            // 
            // cmbRemote
            // 
            this.cmbRemote.FormattingEnabled = true;
            this.cmbRemote.Location = new System.Drawing.Point(101, 330);
            this.cmbRemote.Name = "cmbRemote";
            this.cmbRemote.Size = new System.Drawing.Size(262, 21);
            this.cmbRemote.TabIndex = 60;
            // 
            // optFileVariable
            // 
            this.optFileVariable.AutoSize = true;
            this.optFileVariable.Location = new System.Drawing.Point(212, 310);
            this.optFileVariable.Name = "optFileVariable";
            this.optFileVariable.Size = new System.Drawing.Size(93, 17);
            this.optFileVariable.TabIndex = 59;
            this.optFileVariable.Text = "Variables / f(x)";
            this.optFileVariable.UseVisualStyleBackColor = true;
            this.optFileVariable.Click += new System.EventHandler(this.optFileVariable_Click);
            // 
            // optFileConnection
            // 
            this.optFileConnection.AutoSize = true;
            this.optFileConnection.Checked = true;
            this.optFileConnection.Location = new System.Drawing.Point(101, 311);
            this.optFileConnection.Name = "optFileConnection";
            this.optFileConnection.Size = new System.Drawing.Size(98, 17);
            this.optFileConnection.TabIndex = 58;
            this.optFileConnection.TabStop = true;
            this.optFileConnection.Text = "File Connection";
            this.optFileConnection.UseVisualStyleBackColor = true;
            this.optFileConnection.Click += new System.EventHandler(this.optFileConnection_Click);
            // 
            // cmbLocal
            // 
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Location = new System.Drawing.Point(101, 283);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(262, 21);
            this.cmbLocal.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Returned files list ";
            this.label1.Visible = false;
            // 
            // cmbFilesList
            // 
            this.cmbFilesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilesList.FormattingEnabled = true;
            this.cmbFilesList.Location = new System.Drawing.Point(101, 358);
            this.cmbFilesList.Name = "cmbFilesList";
            this.cmbFilesList.Size = new System.Drawing.Size(319, 21);
            this.cmbFilesList.TabIndex = 55;
            this.cmbFilesList.Visible = false;
            // 
            // btDestinationFile
            // 
            this.btDestinationFile.Location = new System.Drawing.Point(380, 330);
            this.btDestinationFile.Name = "btDestinationFile";
            this.btDestinationFile.Size = new System.Drawing.Size(40, 21);
            this.btDestinationFile.TabIndex = 54;
            this.btDestinationFile.Text = "f(x)";
            this.btDestinationFile.UseVisualStyleBackColor = true;
            this.btDestinationFile.Click += new System.EventHandler(this.btDestinationFile_Click);
            // 
            // lbDestinationFile
            // 
            this.lbDestinationFile.AutoSize = true;
            this.lbDestinationFile.Location = new System.Drawing.Point(7, 335);
            this.lbDestinationFile.Name = "lbDestinationFile";
            this.lbDestinationFile.Size = new System.Drawing.Size(68, 13);
            this.lbDestinationFile.TabIndex = 53;
            this.lbDestinationFile.Text = "Remote path";
            // 
            // btSourceFile
            // 
            this.btSourceFile.Location = new System.Drawing.Point(380, 282);
            this.btSourceFile.Name = "btSourceFile";
            this.btSourceFile.Size = new System.Drawing.Size(40, 21);
            this.btSourceFile.TabIndex = 52;
            this.btSourceFile.Text = "f(x)";
            this.btSourceFile.UseVisualStyleBackColor = true;
            this.btSourceFile.Click += new System.EventHandler(this.btSourceFile_Click);
            // 
            // lbSourceFile
            // 
            this.lbSourceFile.AutoSize = true;
            this.lbSourceFile.Location = new System.Drawing.Point(7, 283);
            this.lbSourceFile.Name = "lbSourceFile";
            this.lbSourceFile.Size = new System.Drawing.Size(58, 13);
            this.lbSourceFile.TabIndex = 51;
            this.lbSourceFile.Text = "Local Path";
            // 
            // lbAction
            // 
            this.lbAction.AutoSize = true;
            this.lbAction.Location = new System.Drawing.Point(7, 259);
            this.lbAction.Name = "lbAction";
            this.lbAction.Size = new System.Drawing.Size(37, 13);
            this.lbAction.TabIndex = 50;
            this.lbAction.Text = "Action";
            // 
            // cmbAction
            // 
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(101, 256);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(319, 21);
            this.cmbAction.TabIndex = 49;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(311, 311);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(112, 17);
            this.chkOverwrite.TabIndex = 61;
            this.chkOverwrite.Text = "Overwrite local file";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Sleep for";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Enabled = false;
            this.numericUpDown.Location = new System.Drawing.Point(322, 382);
            this.numericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown.TabIndex = 65;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "seconds";
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.optionEncryptionKey);
            this.groupBoxConnection.Controls.Add(this.optionEncryptionPassword);
            this.groupBoxConnection.Controls.Add(this.label5);
            this.groupBoxConnection.Controls.Add(this.cmbPassword);
            this.groupBoxConnection.Controls.Add(this.cmbUser);
            this.groupBoxConnection.Controls.Add(this.cmbServer);
            this.groupBoxConnection.Controls.Add(this.lbPassword);
            this.groupBoxConnection.Controls.Add(this.lbUser);
            this.groupBoxConnection.Controls.Add(this.lbServer);
            this.groupBoxConnection.Location = new System.Drawing.Point(10, 3);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(411, 132);
            this.groupBoxConnection.TabIndex = 72;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";
            // 
            // optionEncryptionKey
            // 
            this.optionEncryptionKey.AutoSize = true;
            this.optionEncryptionKey.Location = new System.Drawing.Point(169, 46);
            this.optionEncryptionKey.Name = "optionEncryptionKey";
            this.optionEncryptionKey.Size = new System.Drawing.Size(43, 17);
            this.optionEncryptionKey.TabIndex = 85;
            this.optionEncryptionKey.Text = "Key";
            this.optionEncryptionKey.UseVisualStyleBackColor = true;
            this.optionEncryptionKey.Click += new System.EventHandler(this.optionEncryptionKey_Click);
            // 
            // optionEncryptionPassword
            // 
            this.optionEncryptionPassword.AutoSize = true;
            this.optionEncryptionPassword.Checked = true;
            this.optionEncryptionPassword.Location = new System.Drawing.Point(92, 46);
            this.optionEncryptionPassword.Name = "optionEncryptionPassword";
            this.optionEncryptionPassword.Size = new System.Drawing.Size(71, 17);
            this.optionEncryptionPassword.TabIndex = 84;
            this.optionEncryptionPassword.TabStop = true;
            this.optionEncryptionPassword.Text = "Password";
            this.optionEncryptionPassword.UseVisualStyleBackColor = true;
            this.optionEncryptionPassword.Click += new System.EventHandler(this.optionEncryptionPassword_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "Encryption type:";
            // 
            // cmbPassword
            // 
            this.cmbPassword.FormattingEnabled = true;
            this.cmbPassword.Location = new System.Drawing.Point(92, 96);
            this.cmbPassword.Name = "cmbPassword";
            this.cmbPassword.Size = new System.Drawing.Size(309, 21);
            this.cmbPassword.TabIndex = 77;
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(92, 69);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(309, 21);
            this.cmbUser.TabIndex = 76;
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(92, 19);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(309, 21);
            this.cmbServer.TabIndex = 75;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(6, 100);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(56, 13);
            this.lbPassword.TabIndex = 74;
            this.lbPassword.Text = "Password:";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(6, 74);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(32, 13);
            this.lbUser.TabIndex = 73;
            this.lbUser.Text = "User:";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(6, 22);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(71, 13);
            this.lbServer.TabIndex = 72;
            this.lbServer.Text = "SFTP Server:";
            // 
            // groupBoxEncryption
            // 
            this.groupBoxEncryption.Controls.Add(this.cmbPassPhrase);
            this.groupBoxEncryption.Controls.Add(this.label6);
            this.groupBoxEncryption.Controls.Add(this.optPrivateKeyFileVariable);
            this.groupBoxEncryption.Controls.Add(this.optPrivateKeyFileConnection);
            this.groupBoxEncryption.Controls.Add(this.cmbKeyFile);
            this.groupBoxEncryption.Controls.Add(this.btKeyFileExpression);
            this.groupBoxEncryption.Controls.Add(this.label4);
            this.groupBoxEncryption.Location = new System.Drawing.Point(10, 141);
            this.groupBoxEncryption.Name = "groupBoxEncryption";
            this.groupBoxEncryption.Size = new System.Drawing.Size(411, 102);
            this.groupBoxEncryption.TabIndex = 73;
            this.groupBoxEncryption.TabStop = false;
            this.groupBoxEncryption.Text = "Encryption details";
            // 
            // cmbPassPhrase
            // 
            this.cmbPassPhrase.FormattingEnabled = true;
            this.cmbPassPhrase.Location = new System.Drawing.Point(92, 68);
            this.cmbPassPhrase.Name = "cmbPassPhrase";
            this.cmbPassPhrase.Size = new System.Drawing.Size(309, 21);
            this.cmbPassPhrase.TabIndex = 94;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 93;
            this.label6.Text = "Pass phrase:";
            // 
            // optPrivateKeyFileVariable
            // 
            this.optPrivateKeyFileVariable.AutoSize = true;
            this.optPrivateKeyFileVariable.Location = new System.Drawing.Point(196, 46);
            this.optPrivateKeyFileVariable.Name = "optPrivateKeyFileVariable";
            this.optPrivateKeyFileVariable.Size = new System.Drawing.Size(93, 17);
            this.optPrivateKeyFileVariable.TabIndex = 92;
            this.optPrivateKeyFileVariable.Text = "Variables / f(x)";
            this.optPrivateKeyFileVariable.UseVisualStyleBackColor = true;
            this.optPrivateKeyFileVariable.Click += new System.EventHandler(this.optPrivateKeyFileVariable_Click_1);
            // 
            // optPrivateKeyFileConnection
            // 
            this.optPrivateKeyFileConnection.AutoSize = true;
            this.optPrivateKeyFileConnection.Checked = true;
            this.optPrivateKeyFileConnection.Location = new System.Drawing.Point(92, 46);
            this.optPrivateKeyFileConnection.Name = "optPrivateKeyFileConnection";
            this.optPrivateKeyFileConnection.Size = new System.Drawing.Size(98, 17);
            this.optPrivateKeyFileConnection.TabIndex = 91;
            this.optPrivateKeyFileConnection.TabStop = true;
            this.optPrivateKeyFileConnection.Text = "File Connection";
            this.optPrivateKeyFileConnection.UseVisualStyleBackColor = true;
            this.optPrivateKeyFileConnection.Click += new System.EventHandler(this.optPrivateKeyFileConnection_Click_1);
            // 
            // cmbKeyFile
            // 
            this.cmbKeyFile.FormattingEnabled = true;
            this.cmbKeyFile.Location = new System.Drawing.Point(92, 19);
            this.cmbKeyFile.Name = "cmbKeyFile";
            this.cmbKeyFile.Size = new System.Drawing.Size(261, 21);
            this.cmbKeyFile.TabIndex = 90;
            // 
            // btKeyFileExpression
            // 
            this.btKeyFileExpression.Location = new System.Drawing.Point(359, 19);
            this.btKeyFileExpression.Name = "btKeyFileExpression";
            this.btKeyFileExpression.Size = new System.Drawing.Size(42, 21);
            this.btKeyFileExpression.TabIndex = 89;
            this.btKeyFileExpression.Text = "f(x)";
            this.btKeyFileExpression.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Private key file:";
            // 
            // frmEditProperties
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(430, 461);
            this.Controls.Add(this.groupBoxEncryption);
            this.Controls.Add(this.groupBoxConnection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkSleep);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.cmbRemote);
            this.Controls.Add(this.optFileVariable);
            this.Controls.Add(this.optFileConnection);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFilesList);
            this.Controls.Add(this.btDestinationFile);
            this.Controls.Add(this.lbDestinationFile);
            this.Controls.Add(this.btSourceFile);
            this.Controls.Add(this.lbSourceFile);
            this.Controls.Add(this.lbAction);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.linkLabelCodeplex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFTP Task Properties";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.groupBoxEncryption.ResumeLayout(false);
            this.groupBoxEncryption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabelCodeplex;
        private System.Windows.Forms.ComboBox cmbRemote;
        private System.Windows.Forms.RadioButton optFileVariable;
        private System.Windows.Forms.RadioButton optFileConnection;
        private System.Windows.Forms.ComboBox cmbLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilesList;
        private System.Windows.Forms.Button btDestinationFile;
        private System.Windows.Forms.Label lbDestinationFile;
        private System.Windows.Forms.Button btSourceFile;
        private System.Windows.Forms.Label lbSourceFile;
        private System.Windows.Forms.Label lbAction;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.CheckBox chkSleep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPassword;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.RadioButton optionEncryptionKey;
        private System.Windows.Forms.RadioButton optionEncryptionPassword;
        private System.Windows.Forms.GroupBox groupBoxEncryption;
        private System.Windows.Forms.ComboBox cmbPassPhrase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton optPrivateKeyFileVariable;
        private System.Windows.Forms.RadioButton optPrivateKeyFileConnection;
        private System.Windows.Forms.ComboBox cmbKeyFile;
        private System.Windows.Forms.Button btKeyFileExpression;
        private System.Windows.Forms.Label label4;
    }
}