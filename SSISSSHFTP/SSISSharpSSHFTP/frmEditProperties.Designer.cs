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
            this.linkLabelCodeplex = new System.Windows.Forms.LinkLabel();
            this.cmbPassword = new System.Windows.Forms.ComboBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbServer = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(298, 209);
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
            this.btCancel.Location = new System.Drawing.Point(363, 209);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(59, 26);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // linkLabelCodeplex
            // 
            this.linkLabelCodeplex.AutoSize = true;
            this.linkLabelCodeplex.Location = new System.Drawing.Point(8, 222);
            this.linkLabelCodeplex.Name = "linkLabelCodeplex";
            this.linkLabelCodeplex.Size = new System.Drawing.Size(141, 13);
            this.linkLabelCodeplex.TabIndex = 10;
            this.linkLabelCodeplex.TabStop = true;
            this.linkLabelCodeplex.Text = "http://ssissftp.codeplex.com";
            this.linkLabelCodeplex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCodeplex_LinkClicked);
            // 
            // cmbPassword
            // 
            this.cmbPassword.FormattingEnabled = true;
            this.cmbPassword.Location = new System.Drawing.Point(112, 66);
            this.cmbPassword.Name = "cmbPassword";
            this.cmbPassword.Size = new System.Drawing.Size(309, 21);
            this.cmbPassword.TabIndex = 23;
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(112, 39);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(309, 21);
            this.cmbUser.TabIndex = 22;
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(112, 12);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(309, 21);
            this.cmbServer.TabIndex = 21;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(8, 69);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 20;
            this.lbPassword.Text = "Password";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(8, 42);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(29, 13);
            this.lbUser.TabIndex = 19;
            this.lbUser.Text = "User";
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(8, 15);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(61, 13);
            this.lbServer.TabIndex = 18;
            this.lbServer.Text = "FTP Server";
            // 
            // cmbRemote
            // 
            this.cmbRemote.FormattingEnabled = true;
            this.cmbRemote.Location = new System.Drawing.Point(112, 171);
            this.cmbRemote.Name = "cmbRemote";
            this.cmbRemote.Size = new System.Drawing.Size(262, 21);
            this.cmbRemote.TabIndex = 60;
            // 
            // optFileVariable
            // 
            this.optFileVariable.AutoSize = true;
            this.optFileVariable.Location = new System.Drawing.Point(213, 150);
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
            this.optFileConnection.Location = new System.Drawing.Point(109, 150);
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
            this.cmbLocal.Location = new System.Drawing.Point(112, 123);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(262, 21);
            this.cmbLocal.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 201);
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
            this.cmbFilesList.Location = new System.Drawing.Point(112, 198);
            this.cmbFilesList.Name = "cmbFilesList";
            this.cmbFilesList.Size = new System.Drawing.Size(309, 21);
            this.cmbFilesList.TabIndex = 55;
            this.cmbFilesList.Visible = false;
            // 
            // btDestinationFile
            // 
            this.btDestinationFile.Location = new System.Drawing.Point(381, 170);
            this.btDestinationFile.Name = "btDestinationFile";
            this.btDestinationFile.Size = new System.Drawing.Size(41, 21);
            this.btDestinationFile.TabIndex = 54;
            this.btDestinationFile.Text = "f(x)";
            this.btDestinationFile.UseVisualStyleBackColor = true;
            this.btDestinationFile.Click += new System.EventHandler(this.btDestinationFile_Click);
            // 
            // lbDestinationFile
            // 
            this.lbDestinationFile.AutoSize = true;
            this.lbDestinationFile.Location = new System.Drawing.Point(8, 175);
            this.lbDestinationFile.Name = "lbDestinationFile";
            this.lbDestinationFile.Size = new System.Drawing.Size(68, 13);
            this.lbDestinationFile.TabIndex = 53;
            this.lbDestinationFile.Text = "Remote path";
            // 
            // btSourceFile
            // 
            this.btSourceFile.Location = new System.Drawing.Point(381, 122);
            this.btSourceFile.Name = "btSourceFile";
            this.btSourceFile.Size = new System.Drawing.Size(41, 21);
            this.btSourceFile.TabIndex = 52;
            this.btSourceFile.Text = "f(x)";
            this.btSourceFile.UseVisualStyleBackColor = true;
            this.btSourceFile.Click += new System.EventHandler(this.btSourceFile_Click);
            // 
            // lbSourceFile
            // 
            this.lbSourceFile.AutoSize = true;
            this.lbSourceFile.Location = new System.Drawing.Point(8, 123);
            this.lbSourceFile.Name = "lbSourceFile";
            this.lbSourceFile.Size = new System.Drawing.Size(58, 13);
            this.lbSourceFile.TabIndex = 51;
            this.lbSourceFile.Text = "Local Path";
            // 
            // lbAction
            // 
            this.lbAction.AutoSize = true;
            this.lbAction.Location = new System.Drawing.Point(8, 99);
            this.lbAction.Name = "lbAction";
            this.lbAction.Size = new System.Drawing.Size(37, 13);
            this.lbAction.TabIndex = 50;
            this.lbAction.Text = "Action";
            // 
            // cmbAction
            // 
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(112, 96);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(309, 21);
            this.cmbAction.TabIndex = 49;
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(312, 151);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(112, 17);
            this.chkOverwrite.TabIndex = 61;
            this.chkOverwrite.Text = "Overwrite local file";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // frmEditProperties
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(433, 244);
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
            this.Controls.Add(this.cmbPassword);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.cmbServer);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.linkLabelCodeplex);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit SFTP Properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabelCodeplex;
        private System.Windows.Forms.ComboBox cmbPassword;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbServer;
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
    }
}