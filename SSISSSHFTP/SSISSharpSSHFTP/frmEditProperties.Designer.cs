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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditProperties));
            this.lstBoxMenu = new System.Windows.Forms.ListBox();
            this.panelConnection = new System.Windows.Forms.Panel();
            this.cmbPassword = new System.Windows.Forms.ComboBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.GroupBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.panelFileHandling = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFilesList = new System.Windows.Forms.ComboBox();
            this.btDestinationFile = new System.Windows.Forms.Button();
            this.txDestinationFile = new System.Windows.Forms.TextBox();
            this.lbDestinationFile = new System.Windows.Forms.Label();
            this.btSourceFile = new System.Windows.Forms.Button();
            this.txSourceFile = new System.Windows.Forms.TextBox();
            this.lbSourceFile = new System.Windows.Forms.Label();
            this.lbAction = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.panelConnection.SuspendLayout();
            this.panelFileHandling.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxMenu
            // 
            this.lstBoxMenu.FormattingEnabled = true;
            this.lstBoxMenu.Items.AddRange(new object[] {
            "General",
            "File Transfer"});
            this.lstBoxMenu.Location = new System.Drawing.Point(2, 12);
            this.lstBoxMenu.Name = "lstBoxMenu";
            this.lstBoxMenu.Size = new System.Drawing.Size(137, 108);
            this.lstBoxMenu.TabIndex = 0;
            this.lstBoxMenu.SelectedIndexChanged += new System.EventHandler(this.lstBoxMenu_SelectedIndexChanged);
            // 
            // panelConnection
            // 
            this.panelConnection.Controls.Add(this.cmbPassword);
            this.panelConnection.Controls.Add(this.cmbUser);
            this.panelConnection.Controls.Add(this.cmbServer);
            this.panelConnection.Controls.Add(this.lbPassword);
            this.panelConnection.Controls.Add(this.lbUser);
            this.panelConnection.Controls.Add(this.lbServer);
            this.panelConnection.Location = new System.Drawing.Point(144, 12);
            this.panelConnection.Name = "panelConnection";
            this.panelConnection.Size = new System.Drawing.Size(350, 107);
            this.panelConnection.TabIndex = 1;
            // 
            // cmbPassword
            // 
            this.cmbPassword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPassword.FormattingEnabled = true;
            this.cmbPassword.Location = new System.Drawing.Point(86, 68);
            this.cmbPassword.Name = "cmbPassword";
            this.cmbPassword.Size = new System.Drawing.Size(246, 21);
            this.cmbPassword.TabIndex = 11;
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(86, 41);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(246, 21);
            this.cmbUser.TabIndex = 10;
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(86, 14);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(246, 21);
            this.cmbServer.TabIndex = 9;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(10, 71);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 2;
            this.lbPassword.Text = "Password";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(10, 44);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(29, 13);
            this.lbUser.TabIndex = 1;
            this.lbUser.Text = "User";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(10, 17);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(61, 13);
            this.lbServer.TabIndex = 0;
            this.lbServer.Text = "FTP Server";
            // 
            // line
            // 
            this.line.Location = new System.Drawing.Point(6, 118);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(477, 10);
            this.line.TabIndex = 2;
            this.line.TabStop = false;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(327, 129);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 35);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(408, 129);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 35);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // panelFileHandling
            // 
            this.panelFileHandling.Controls.Add(this.label3);
            this.panelFileHandling.Controls.Add(this.cmbFilesList);
            this.panelFileHandling.Controls.Add(this.btDestinationFile);
            this.panelFileHandling.Controls.Add(this.txDestinationFile);
            this.panelFileHandling.Controls.Add(this.lbDestinationFile);
            this.panelFileHandling.Controls.Add(this.btSourceFile);
            this.panelFileHandling.Controls.Add(this.txSourceFile);
            this.panelFileHandling.Controls.Add(this.lbSourceFile);
            this.panelFileHandling.Controls.Add(this.lbAction);
            this.panelFileHandling.Controls.Add(this.cmbAction);
            this.panelFileHandling.Location = new System.Drawing.Point(144, 12);
            this.panelFileHandling.Name = "panelFileHandling";
            this.panelFileHandling.Size = new System.Drawing.Size(350, 107);
            this.panelFileHandling.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Files list";
            this.label3.Visible = false;
            // 
            // cmbFilesList
            // 
            this.cmbFilesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilesList.FormattingEnabled = true;
            this.cmbFilesList.Location = new System.Drawing.Point(101, 114);
            this.cmbFilesList.Name = "cmbFilesList";
            this.cmbFilesList.Size = new System.Drawing.Size(238, 21);
            this.cmbFilesList.TabIndex = 34;
            this.cmbFilesList.Visible = false;
            // 
            // btDestinationFile
            // 
            this.btDestinationFile.Location = new System.Drawing.Point(309, 78);
            this.btDestinationFile.Name = "btDestinationFile";
            this.btDestinationFile.Size = new System.Drawing.Size(29, 21);
            this.btDestinationFile.TabIndex = 28;
            this.btDestinationFile.Text = "...";
            this.btDestinationFile.UseVisualStyleBackColor = true;
            this.btDestinationFile.Click += new System.EventHandler(this.btDestinationFile_Click);
            // 
            // txDestinationFile
            // 
            this.txDestinationFile.Location = new System.Drawing.Point(101, 78);
            this.txDestinationFile.Name = "txDestinationFile";
            this.txDestinationFile.ReadOnly = true;
            this.txDestinationFile.Size = new System.Drawing.Size(199, 20);
            this.txDestinationFile.TabIndex = 27;
            // 
            // lbDestinationFile
            // 
            this.lbDestinationFile.AutoSize = true;
            this.lbDestinationFile.Location = new System.Drawing.Point(9, 78);
            this.lbDestinationFile.Name = "lbDestinationFile";
            this.lbDestinationFile.Size = new System.Drawing.Size(68, 13);
            this.lbDestinationFile.TabIndex = 26;
            this.lbDestinationFile.Text = "Remote path";
            // 
            // btSourceFile
            // 
            this.btSourceFile.Location = new System.Drawing.Point(309, 52);
            this.btSourceFile.Name = "btSourceFile";
            this.btSourceFile.Size = new System.Drawing.Size(29, 21);
            this.btSourceFile.TabIndex = 22;
            this.btSourceFile.Text = "...";
            this.btSourceFile.UseVisualStyleBackColor = true;
            this.btSourceFile.Click += new System.EventHandler(this.btSourceFile_Click);
            // 
            // txSourceFile
            // 
            this.txSourceFile.Location = new System.Drawing.Point(101, 52);
            this.txSourceFile.Name = "txSourceFile";
            this.txSourceFile.ReadOnly = true;
            this.txSourceFile.Size = new System.Drawing.Size(199, 20);
            this.txSourceFile.TabIndex = 21;
            // 
            // lbSourceFile
            // 
            this.lbSourceFile.AutoSize = true;
            this.lbSourceFile.Location = new System.Drawing.Point(9, 51);
            this.lbSourceFile.Name = "lbSourceFile";
            this.lbSourceFile.Size = new System.Drawing.Size(58, 13);
            this.lbSourceFile.TabIndex = 20;
            this.lbSourceFile.Text = "Local Path";
            // 
            // lbAction
            // 
            this.lbAction.AutoSize = true;
            this.lbAction.Location = new System.Drawing.Point(9, 6);
            this.lbAction.Name = "lbAction";
            this.lbAction.Size = new System.Drawing.Size(37, 13);
            this.lbAction.TabIndex = 1;
            this.lbAction.Text = "Action";
            // 
            // cmbAction
            // 
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(101, 3);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(238, 21);
            this.cmbAction.TabIndex = 0;
            // 
            // txtInfo
            // 
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Location = new System.Drawing.Point(6, 140);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(256, 13);
            this.txtInfo.TabIndex = 6;
            this.txtInfo.Text = "http://ssis-sftp.codeplex.com";
            // 
            // frmEditProperties
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(497, 169);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.line);
            this.Controls.Add(this.lstBoxMenu);
            this.Controls.Add(this.panelFileHandling);
            this.Controls.Add(this.panelConnection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Properties";
            this.panelConnection.ResumeLayout(false);
            this.panelConnection.PerformLayout();
            this.panelFileHandling.ResumeLayout(false);
            this.panelFileHandling.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxMenu;
        private System.Windows.Forms.Panel panelConnection;
        private System.Windows.Forms.GroupBox line;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.Panel panelFileHandling;
        private System.Windows.Forms.ComboBox cmbPassword;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label lbAction;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btDestinationFile;
        private System.Windows.Forms.TextBox txDestinationFile;
        private System.Windows.Forms.Label lbDestinationFile;
        private System.Windows.Forms.Button btSourceFile;
        private System.Windows.Forms.TextBox txSourceFile;
        private System.Windows.Forms.Label lbSourceFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFilesList;
    }
}