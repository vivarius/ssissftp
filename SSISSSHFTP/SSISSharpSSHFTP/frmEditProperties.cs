using System;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
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
        private Connections _connections;

        #endregion

        #region .ctor
        public frmEditProperties(TaskHost taskHost, Connections connections)
        {
            InitializeComponent();

            _taskHost = taskHost;
            _connections = connections;

            if (taskHost == null)
            {
                throw new ArgumentNullException("taskHost");
            }

            FillConnectionInfoPanel();
            FillDetailsPanel();
        }
        #endregion

        #region Events
        void btOK_Click(object sender, EventArgs e)
        {
            //Save the values
            _taskHost.Properties[NamedStringMembers.FTP_SERVER].SetValue(_taskHost, cmbServer.Text);
            _taskHost.Properties[NamedStringMembers.FTP_USER].SetValue(_taskHost, cmbUser.Text);
            _taskHost.Properties[NamedStringMembers.FTP_PASSWORD].SetValue(_taskHost, cmbPassword.Text);

            _taskHost.Properties[NamedStringMembers.FTP_ACTION_LIST].SetValue(_taskHost, cmbAction.SelectedItem);
            _taskHost.Properties[NamedStringMembers.FTP_LOCAL_PATH].SetValue(_taskHost, txSourceFile.Text);
            _taskHost.Properties[NamedStringMembers.FTP_REMOTE_PATH].SetValue(_taskHost, txDestinationFile.Text);
            _taskHost.Properties[NamedStringMembers.FTP_FILES_LIST].SetValue(_taskHost, cmbFilesList.SelectedItem);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btSourceFile_Click(object sender, EventArgs e)
        {
            using (ExpressionBuilder expressionBuilder = ExpressionBuilder.Instantiate(_taskHost.Variables, _taskHost.VariableDispenser, typeof(string), txSourceFile.Text))
            {
                if (expressionBuilder.ShowDialog() == DialogResult.OK)
                {
                    txSourceFile.Text = expressionBuilder.Expression;
                }
            }
        }

        private void btDestinationFile_Click(object sender, EventArgs e)
        {
            using (ExpressionBuilder expressionBuilder = ExpressionBuilder.Instantiate(_taskHost.Variables, _taskHost.VariableDispenser, typeof(string), txDestinationFile.Text))
            {
                if (expressionBuilder.ShowDialog() == DialogResult.OK)
                {
                    txDestinationFile.Text = expressionBuilder.Expression;
                }
            }
        }

        #endregion

        #region Methods
       

        private void FillConnectionInfoPanel()
        {
            try
            {
                foreach (var variable in _taskHost.Variables.Cast<Variable>().Where(variable => variable.Namespace == @"User").Where(variable => variable.DataType == TypeCode.String))
                {
                    cmbServer.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                    cmbUser.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                    cmbPassword.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                }

                cmbServer.SelectedIndex = (_taskHost.Properties[NamedStringMembers.FTP_SERVER].GetValue(_taskHost) == null)
                                            ? -1
                                            : cmbServer.FindString(_taskHost.Properties[NamedStringMembers.FTP_SERVER].GetValue(_taskHost).ToString());
                cmbUser.SelectedIndex = (_taskHost.Properties[NamedStringMembers.FTP_SERVER].GetValue(_taskHost) == null)
                                            ? -1
                                            : cmbUser.FindString(_taskHost.Properties[NamedStringMembers.FTP_USER].GetValue(_taskHost).ToString());
                cmbPassword.SelectedIndex = (_taskHost.Properties[NamedStringMembers.FTP_SERVER].GetValue(_taskHost) == null)
                                            ? -1
                                            : cmbPassword.FindString(_taskHost.Properties[NamedStringMembers.FTP_PASSWORD].GetValue(_taskHost).ToString());
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
                cmbAction.SelectedIndex = cmbAction.FindString(_taskHost.Properties[NamedStringMembers.FTP_ACTION_LIST].GetValue(_taskHost).ToString());


                foreach (var variable in _taskHost.Variables.Cast<Variable>().Where(variable => variable.Namespace == @"User").Where(variable => variable.DataType == TypeCode.Object))
                {
                    cmbFilesList.Items.Add(string.Format("@[{0}::{1}]", variable.Namespace, variable.Name));
                }

                cmbFilesList.SelectedIndex = (_taskHost.Properties[NamedStringMembers.FTP_FILES_LIST].GetValue(_taskHost) == null)
                                            ? -1
                                            : cmbFilesList.FindString(_taskHost.Properties[NamedStringMembers.FTP_FILES_LIST].GetValue(_taskHost).ToString());

                txSourceFile.Text = (_taskHost.Properties[NamedStringMembers.FTP_LOCAL_PATH].GetValue(_taskHost) == null)
                                             ? string.Empty
                                             : _taskHost.Properties[NamedStringMembers.FTP_LOCAL_PATH].GetValue(_taskHost).ToString();

                txDestinationFile.Text = (_taskHost.Properties[NamedStringMembers.FTP_REMOTE_PATH].GetValue(_taskHost) == null)
                                             ? string.Empty
                                             : _taskHost.Properties[NamedStringMembers.FTP_REMOTE_PATH].GetValue(_taskHost).ToString();
            }
            catch (Exception exception)
            {
                //go go go
            }
        }
        #endregion

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
