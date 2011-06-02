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

            if (_taskHost.Properties[Keys.FTP_LOCAL_PATH_SOURCE_TYPE].GetValue(_taskHost) != null)
            {
                if (_taskHost.Properties[Keys.FTP_LOCAL_PATH_SOURCE_TYPE].GetValue(_taskHost).ToString() == Keys.TRUE)
                {
                    LoadLocalFileConnections();
                }
                else
                {
                    LoadLocalVariables();
                }
            }

            FillConnectionInfoPanel();
            FillDetailsPanel();
        }
        #endregion

        #region Events

        private void btOK_Click(object sender, EventArgs e)
        {
            //Save the values
            _taskHost.Properties[Keys.FTP_SERVER].SetValue(_taskHost, cmbServer.Text);
            _taskHost.Properties[Keys.FTP_USER].SetValue(_taskHost, cmbUser.Text);
            _taskHost.Properties[Keys.FTP_PASSWORD].SetValue(_taskHost, cmbPassword.Text);

            _taskHost.Properties[Keys.FTP_ACTION_LIST].SetValue(_taskHost, cmbAction.SelectedItem);
            _taskHost.Properties[Keys.FTP_LOCAL_PATH].SetValue(_taskHost, cmbLocal.Text);
            _taskHost.Properties[Keys.FTP_LOCAL_PATH_SOURCE_TYPE].SetValue(_taskHost, optFileConnection.Checked);
            _taskHost.Properties[Keys.FTP_REMOTE_PATH].SetValue(_taskHost, cmbRemote.Text);
            _taskHost.Properties[Keys.FTP_FILES_LIST].SetValue(_taskHost, cmbFilesList.SelectedItem);

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

        private List<string> LoadVariables(string parameterInfo)
        {
            return _variables.Cast<Variable>().Where(variable => Type.GetTypeCode(Type.GetType(parameterInfo)) == variable.DataType).Select(variable => string.Format("@[{0}::{1}]", variable.Namespace, variable.Name)).ToList();
        }

        private void LoadLocalVariables()
        {
            cmbLocal.Items.Clear();
            cmbLocal.Items.AddRange(LoadVariables("System.String").ToArray());
        }

        private void LoadRemoteVariables()
        {
            cmbRemote.Items.Clear();
            cmbRemote.Items.AddRange(LoadVariables("System.String").ToArray());
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
                foreach (var variable in _variables.Cast<Variable>().Where(variable => variable.Namespace == @"User").Where(variable => variable.DataType == TypeCode.String))
                {
                    cmbServer.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                    cmbUser.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                    cmbPassword.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                }

                cmbServer.SelectedIndex = (_taskHost.Properties[Keys.FTP_SERVER].GetValue(_taskHost) == null)
                                            ? -1
                                            : cmbServer.FindString(_taskHost.Properties[Keys.FTP_SERVER].GetValue(_taskHost).ToString());
                cmbUser.SelectedIndex = (_taskHost.Properties[Keys.FTP_SERVER].GetValue(_taskHost) == null)
                                            ? -1
                                            : cmbUser.FindString(_taskHost.Properties[Keys.FTP_USER].GetValue(_taskHost).ToString());
                cmbPassword.SelectedIndex = (_taskHost.Properties[Keys.FTP_SERVER].GetValue(_taskHost) == null)
                                            ? -1
                                            : cmbPassword.FindString(_taskHost.Properties[Keys.FTP_PASSWORD].GetValue(_taskHost).ToString());
            }
            catch (Exception exception)
            {
                //go go go
            }
        }

        private void FillDetailsPanel()
        {
            try
            {
                cmbAction.Items.AddRange(Communication.ActionTask.ToArray());
                if (_taskHost.Properties[Keys.FTP_ACTION_LIST].GetValue(_taskHost) != null)
                    cmbAction.SelectedIndex = cmbAction.FindString(_taskHost.Properties[Keys.FTP_ACTION_LIST].GetValue(_taskHost).ToString());


                LoadRemoteVariables();

                foreach (var variable in _variables.Cast<Variable>().Where(variable => variable.Namespace == @"User").Where(variable => variable.DataType == TypeCode.Object))
                {
                    cmbFilesList.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                }

                cmbFilesList.SelectedIndex = (_taskHost.Properties[Keys.FTP_FILES_LIST].GetValue(_taskHost) == null)
                                            ? -1
                                            : cmbFilesList.FindString(_taskHost.Properties[Keys.FTP_FILES_LIST].GetValue(_taskHost).ToString());

                cmbLocal.SelectedIndex = (_taskHost.Properties[Keys.FTP_LOCAL_PATH].GetValue(_taskHost) == null)
                                             ? -1
                                             : cmbLocal.FindString(_taskHost.Properties[Keys.FTP_LOCAL_PATH].GetValue(_taskHost).ToString());

                cmbRemote.SelectedIndex = (_taskHost.Properties[Keys.FTP_REMOTE_PATH].GetValue(_taskHost) == null)
                                             ? -1
                                             : cmbRemote.FindString(_taskHost.Properties[Keys.FTP_REMOTE_PATH].GetValue(_taskHost).ToString());
            }
            catch
            {
                //go go go
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        private void frmEditProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
