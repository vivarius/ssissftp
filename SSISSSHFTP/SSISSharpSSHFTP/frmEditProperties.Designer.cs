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
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbPassword = new System.Windows.Forms.ComboBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilesList = new System.Windows.Forms.ComboBox();
            this.btDestinationFile = new System.Windows.Forms.Button();
            this.lbDestinationFile = new System.Windows.Forms.Label();
            this.btSourceFile = new System.Windows.Forms.Button();
            this.lbSourceFile = new System.Windows.Forms.Label();
            this.lbAction = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.optFileVariable = new System.Windows.Forms.RadioButton();
            this.optFileConnection = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(244, 191);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 26);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(325, 191);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 26);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // txtInfo
            // 
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Location = new System.Drawing.Point(4, 194);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(145, 13);
            this.txtInfo.TabIndex = 6;
            this.txtInfo.Text = "http://ssissftp.codeplex.com";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(394, 172);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbPassword);
            this.tabPage1.Controls.Add(this.cmbUser);
            this.tabPage1.Controls.Add(this.cmbServer);
            this.tabPage1.Controls.Add(this.lbPassword);
            this.tabPage1.Controls.Add(this.lbUser);
            this.tabPage1.Controls.Add(this.lbServer);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbPassword
            // 
            this.cmbPassword.FormattingEnabled = true;
            this.cmbPassword.Location = new System.Drawing.Point(82, 66);
            this.cmbPassword.Name = "cmbPassword";
            this.cmbPassword.Size = new System.Drawing.Size(298, 21);
            this.cmbPassword.TabIndex = 17;
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(82, 39);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(298, 21);
            this.cmbUser.TabIndex = 16;
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(82, 12);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(298, 21);
            this.cmbServer.TabIndex = 15;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(6, 69);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 14;
            this.lbPassword.Text = "Password";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(6, 42);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(29, 13);
            this.lbUser.TabIndex = 13;
            this.lbUser.Text = "User";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(6, 15);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(61, 13);
            this.lbServer.TabIndex = 12;
            this.lbServer.Text = "FTP Server";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.optFileVariable);
            this.tabPage2.Controls.Add(this.optFileConnection);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cmbFilesList);
            this.tabPage2.Controls.Add(this.btDestinationFile);
            this.tabPage2.Controls.Add(this.lbDestinationFile);
            this.tabPage2.Controls.Add(this.btSourceFile);
            this.tabPage2.Controls.Add(this.lbSourceFile);
            this.tabPage2.Controls.Add(this.lbAction);
            this.tabPage2.Controls.Add(this.cmbAction);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 143);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Action";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Returned files list ";
            // 
            // cmbFilesList
            // 
            this.cmbFilesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilesList.FormattingEnabled = true;
            this.cmbFilesList.Location = new System.Drawing.Point(98, 108);
            this.cmbFilesList.Name = "cmbFilesList";
            this.cmbFilesList.Size = new System.Drawing.Size(282, 21);
            this.cmbFilesList.TabIndex = 37;
            // 
            // btDestinationFile
            // 
            this.btDestinationFile.Location = new System.Drawing.Point(351, 81);
            this.btDestinationFile.Name = "btDestinationFile";
            this.btDestinationFile.Size = new System.Drawing.Size(29, 21);
            this.btDestinationFile.TabIndex = 36;
            this.btDestinationFile.Text = "f(x)";
            this.btDestinationFile.UseVisualStyleBackColor = true;
            // 
            // lbDestinationFile
            // 
            this.lbDestinationFile.AutoSize = true;
            this.lbDestinationFile.Location = new System.Drawing.Point(6, 85);
            this.lbDestinationFile.Name = "lbDestinationFile";
            this.lbDestinationFile.Size = new System.Drawing.Size(68, 13);
            this.lbDestinationFile.TabIndex = 34;
            this.lbDestinationFile.Text = "Remote path";
            // 
            // btSourceFile
            // 
            this.btSourceFile.Location = new System.Drawing.Point(351, 32);
            this.btSourceFile.Name = "btSourceFile";
            this.btSourceFile.Size = new System.Drawing.Size(29, 21);
            this.btSourceFile.TabIndex = 33;
            this.btSourceFile.Text = "f(x)";
            this.btSourceFile.UseVisualStyleBackColor = true;
            this.btSourceFile.Click += new System.EventHandler(this.btSourceFile_Click);
            // 
            // lbSourceFile
            // 
            this.lbSourceFile.AutoSize = true;
            this.lbSourceFile.Location = new System.Drawing.Point(6, 35);
            this.lbSourceFile.Name = "lbSourceFile";
            this.lbSourceFile.Size = new System.Drawing.Size(58, 13);
            this.lbSourceFile.TabIndex = 31;
            this.lbSourceFile.Text = "Local Path";
            // 
            // lbAction
            // 
            this.lbAction.AutoSize = true;
            this.lbAction.Location = new System.Drawing.Point(6, 9);
            this.lbAction.Name = "lbAction";
            this.lbAction.Size = new System.Drawing.Size(37, 13);
            this.lbAction.TabIndex = 30;
            this.lbAction.Text = "Action";
            // 
            // cmbAction
            // 
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(98, 6);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(282, 21);
            this.cmbAction.TabIndex = 29;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(98, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(247, 21);
            this.comboBox1.TabIndex = 39;
            // 
            // optFileVariable
            // 
            this.optFileVariable.AutoSize = true;
            this.optFileVariable.Location = new System.Drawing.Point(219, 58);
            this.optFileVariable.Name = "optFileVariable";
            this.optFileVariable.Size = new System.Drawing.Size(128, 17);
            this.optFileVariable.TabIndex = 47;
            this.optFileVariable.Text = "Variable / Expression ";
            this.optFileVariable.UseVisualStyleBackColor = true;
            // 
            // optFileConnection
            // 
            this.optFileConnection.AutoSize = true;
            this.optFileConnection.Checked = true;
            this.optFileConnection.Location = new System.Drawing.Point(98, 58);
            this.optFileConnection.Name = "optFileConnection";
            this.optFileConnection.Size = new System.Drawing.Size(98, 17);
            this.optFileConnection.TabIndex = 46;
            this.optFileConnection.TabStop = true;
            this.optFileConnection.Text = "File Connection";
            this.optFileConnection.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(98, 81);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(247, 21);
            this.comboBox2.TabIndex = 48;
            // 
            // frmEditProperties
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(402, 223);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit SFTP Properties";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbPassword;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Button btDestinationFile;
        private System.Windows.Forms.Label lbDestinationFile;
        private System.Windows.Forms.Button btSourceFile;
        private System.Windows.Forms.Label lbSourceFile;
        private System.Windows.Forms.Label lbAction;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.ComboBox cmbFilesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton optFileVariable;
        private System.Windows.Forms.RadioButton optFileConnection;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}