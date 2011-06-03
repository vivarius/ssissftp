using System;
using System.Collections.Generic;
using SSISSFTPTask100.SSIS;
using System.Linq;
using System.Windows.Forms;
using Microsoft.DataTransformationServices.Controls;
using Microsoft.SqlServer.Dts.Runtime;
using TaskHost = Microsoft.SqlServer.Dts.Runtime.TaskHost;
using Variable = Microsoft.SqlServer.Dts.Runtime.Variable;

namespace SSISSFTPTask100
{
    public partial class frmEditProperties : Form
    {
        #region Private Properties
        private readonly TaskHost _taskHost;
        private readonly Connections _connections;
        private readonly Variables _variables;
        #endregion

        #region .ctor
        public frmEditProperties(TaskHost taskHost, Connections connections)
        {
            InitializeComponent();

            _taskHost = taskHost;
            _connections = connections;
            _variables = taskHost.Variables;

            if (taskHost == null)
            {
                throw new ArgumentNullException("taskHost");
            }

            FillConnectionInfoPanel();
            FillDetailsPanel();
        }
        #endregion

        #region Events

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            //Save the values
            _taskHost.Properties[Keys.FTP_SERVER].SetValue(_taskHost, cmbServer.Text);
            _taskHost.Properties[Keys.FTP_USER].SetValue(_taskHost, cmbUser.Text);
            _taskHost.Properties[Keys.FTP_PASSWORD].SetValue(_taskHost, cmbPassword.Text);

            _taskHost.Properties[Keys.FTP_ACTION_LIST].SetValue(_taskHost, cmbAction.SelectedItem);

            _taskHost.Properties[Keys.FTP_LOCAL_PATH].SetValue(_taskHost, cmbLocal.Text);
            _taskHost.Properties[Keys.FTP_LOCAL_PATH_SOURCE_TYPE].SetValue(_taskHost, optFileConnection.Checked ? Keys.TRUE : Keys.FALSE);
            _taskHost.Properties[Keys.FTP_LOCAL_PATH_OVERWRITE].SetValue(_taskHost, chkOverwrite.Checked ? Keys.TRUE : Keys.FALSE);

            _taskHost.Properties[Keys.FTP_REMOTE_PATH].SetValue(_taskHost, cmbRemote.Text);

            _taskHost.Properties[Keys.FTP_FILES_LIST].SetValue(_taskHost, cmbFilesList.SelectedItem ?? string.Empty);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btSourceFile_Click(object sender, EventArgs e)
        {
            using (ExpressionBuilder expressionBuilder = ExpressionBuilder.Instantiate(_variables, _taskHost.VariableDispenser, typeof(string), cmbLocal.Text))
            {
                if (expressionBuilder.ShowDialog() == DialogResult.OK)
                {
                    cmbLocal.Text = expressionBuilder.Expression;
                }
            }
        }

        private void btDestinationFile_Click(object sender, EventArgs e)
        {
            using (ExpressionBuilder expressionBuilder = ExpressionBuilder.Instantiate(_variables, _taskHost.VariableDispenser, typeof(string), cmbRemote.Text))
            {
                if (expressionBuilder.ShowDialog() == DialogResult.OK)
                {
                    cmbRemote.Text = expressionBuilder.Expression;
                }
            }
        }

        private void optFileConnection_Click(object sender, EventArgs e)
        {
            if (optFileConnection.Checked)
            {
                btSourceFile.Enabled = false;
                LoadLocalFileConnections();
            }
            else
            {
                btSourceFile.Enabled = true;
                LoadLocalVariables();
            }
        }

        private void optFileVariable_Click(object sender, EventArgs e)
        {
            if (optFileConnection.Checked)
            {
                btSourceFile.Enabled = false;
                LoadLocalFileConnections();
            }
            else
            {
                btSourceFile.Enabled = true;
                LoadLocalVariables();
            }
        }

        private void linkLabelCodeplex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabelCodeplex.Text);
        }

        #endregion

        #region Methods

        private List<string> LoadUserVariables(string parameterInfo)
        {
            return (from Variable var in _variables
                    where var.DataType == Type.GetTypeCode(Type.GetType(parameterInfo)) && var.Namespace.ToLower() == "user"
                    select string.Format("@[{0}::{1}]", var.Namespace, var.Name)).ToList();
        }

        private void LoadLocalVariables()
        {
            cmbLocal.Items.Clear();
            cmbLocal.Items.AddRange(LoadUserVariables("System.String").ToArray());
        }

        private void LoadRemoteVariables()
        {
            cmbRemote.Items.Clear();
            cmbRemote.Items.AddRange(LoadUserVariables("System.String").ToArray());
        }

        private void LoadLocalFileConnections()
        {
            cmbLocal.Items.Clear();

            foreach (var connection in _connections.Cast<ConnectionManager>().Where(connection => connection.CreationName == "FILE"))
            {
                cmbLocal.Items.Add(connection.Name);
            }
        }

        private void FillConnectionInfoPanel()
        {
            try
            {
                foreach (var variable in (from Variable var in _variables
                                          where var.DataType == Type.GetTypeCode(Type.GetType("System.String")) &&
                                                var.Namespace.ToLower() == "user"
                                          select var))
                {
                    cmbServer.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                    cmbUser.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                    cmbPassword.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                }

                cmbServer.SelectedIndex = GetSelectedComboBoxIndex(cmbServer, _taskHost.Properties[Keys.FTP_SERVER].GetValue(_taskHost));

                cmbUser.SelectedIndex = GetSelectedComboBoxIndex(cmbUser, _taskHost.Properties[Keys.FTP_USER].GetValue(_taskHost));

                cmbPassword.SelectedIndex = GetSelectedComboBoxIndex(cmbPassword, _taskHost.Properties[Keys.FTP_PASSWORD].GetValue(_taskHost));
            }
            catch (Exception exception)
            {

            }
        }

        private void FillDetailsPanel()
        {
            try
            {
                cmbAction.Items.AddRange(Communication.ActionTask.ToArray());

                if (_taskHost.Properties[Keys.FTP_ACTION_LIST].GetValue(_taskHost) != null)
                    cmbAction.SelectedIndex = cmbAction.FindString(_taskHost.Properties[Keys.FTP_ACTION_LIST].GetValue(_taskHost).ToString());

                if (_taskHost.Properties[Keys.FTP_LOCAL_PATH_SOURCE_TYPE].GetValue(_taskHost) != null)
                {
                    if (_taskHost.Properties[Keys.FTP_LOCAL_PATH_SOURCE_TYPE].GetValue(_taskHost).ToString() == Keys.TRUE)
                    {
                        optFileConnection.Checked = true;
                        btSourceFile.Enabled = false;
                        LoadLocalFileConnections();
                    }
                    else
                    {
                        btSourceFile.Enabled = true;
                        optFileVariable.Checked = true;
                        LoadLocalVariables();
                    }
                }
                else
                {
                    btSourceFile.Enabled = false;
                    optFileConnection.Checked = true;
                    LoadLocalFileConnections();
                }

                if (_taskHost.Properties[Keys.FTP_LOCAL_PATH_OVERWRITE].GetValue(_taskHost) != null)
                {
                    chkOverwrite.Checked = _taskHost.Properties[Keys.FTP_LOCAL_PATH_OVERWRITE].GetValue(_taskHost).ToString() == Keys.TRUE;
                }
                else
                {
                    chkOverwrite.Checked = true;
                }

                LoadRemoteVariables();

                foreach (var variable in (from Variable var in _variables
                                          where var.DataType == Type.GetTypeCode(typeof(object)) &&
                                                var.Namespace.ToLower() == "user"
                                          select var))
                {
                    cmbFilesList.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                }

                cmbFilesList.SelectedIndex = GetSelectedComboBoxIndex(cmbFilesList, _taskHost.Properties[Keys.FTP_FILES_LIST].GetValue(_taskHost));

                cmbLocal.SelectedIndex = GetSelectedComboBoxIndex(cmbLocal, _taskHost.Properties[Keys.FTP_LOCAL_PATH].GetValue(_taskHost));

                cmbRemote.SelectedIndex = GetSelectedComboBoxIndex(cmbRemote, _taskHost.Properties[Keys.FTP_REMOTE_PATH].GetValue(_taskHost));
            }
            catch
            {

            }
        }

        private static int GetSelectedComboBoxIndex(ComboBox comboBox, object value)
        {
            int retValue = -1;

            if (value == null)
                return retValue;

            if (string.IsNullOrEmpty(value.ToString()))
                return retValue;

            string strValue = value.ToString();

            if (comboBox.FindString(strValue) > -1)
            {
                retValue = comboBox.FindString(strValue);
            }
            else
            {
                comboBox.Items.Add(strValue);
                retValue = comboBox.FindString(strValue);
            }

            return retValue;
        }

        #endregion
    }
}
