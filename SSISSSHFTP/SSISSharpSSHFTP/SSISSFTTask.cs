using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using DTSExecResult = Microsoft.SqlServer.Dts.Runtime.DTSExecResult;
using DTSProductLevel = Microsoft.SqlServer.Dts.Runtime.DTSProductLevel;
using VariableDispenser = Microsoft.SqlServer.Dts.Runtime.VariableDispenser;

namespace SSISSFTPTask100.SSIS
{
    [DtsTask(
        DisplayName = "SFTP Task",
        UITypeName = "SSISSFTPTask100.SSISSFTTaskUIInterface" +
        ",SSISSFTPTask100," +
        "Version=1.0.0.42," +
        "Culture=Neutral," +
        "PublicKeyToken=4598105d4a713364",
        IconResource = "SSISSFTPTask100.sftp.ico",
        TaskContact = "cosmin.vlasiu@gmail.com",
        RequiredProductLevel = DTSProductLevel.Standard
        )]
    public class SSISSFTTask : Task, IDTSComponentPersist
    {
        #region Constructor
        public SSISSFTTask()
        {

        }

        #endregion

        #region Public Properties

        #region Connector
        [Category("Connection"), Description("SFTP Server")]
        public string SFTPServer { get; set; }
        [Category("Connection"), Description("SFTP Username")]
        public string SFTPUser { get; set; }
        [Category("Connection"), Description("SFTP Password")]
        public string SFTPPassword { get; set; }

        #endregion

        #region Action

        [Category("File Transfer"), Description("Action list"), ReadOnly(true)]
        public string TaskAction { get; set; }

        [Category("File Transfer"), Description("Local File")]
        public string LocalPath { get; set; }

        [Category("File Transfer"), Description("Remote File")]
        public string RemotePath { get; set; }

        [Category("File Transfer"), Description("Get File List From an Remote Path // Object type variable")]
        public string FilesList { get; set; }
        #endregion

        #endregion

        #region Private Properties

        Variables _vars = null;

        #endregion

        #region Validate

        /// <summary>
        /// Validate local properties
        /// </summary>
        public override DTSExecResult Validate(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log)
        {
            bool isBaseValid = true;

            if (base.Validate(connections, variableDispenser, componentEvents, log) != DTSExecResult.Success)
            {
                componentEvents.FireError(0, "SSISSFTTask", "Base validation failed", "", 0);
                isBaseValid = false;
            }

            #region Check connection
            if (string.IsNullOrEmpty(SFTPServer))
            {
                componentEvents.FireError(0, "SSISSFTTask", "FTP Server is required.", "", 0);
                isBaseValid = false;
            }

            if (string.IsNullOrEmpty(SFTPUser))
            {
                componentEvents.FireError(0, "SSISSFTTask", "FTP User is required.", "", 0);
                isBaseValid = false;
            }

            if (string.IsNullOrEmpty(SFTPPassword))
            {
                componentEvents.FireError(0, "SSISSFTTask", "FTP User is required.", "", 0);
                isBaseValid = false;
            }

            if (string.IsNullOrEmpty(SFTPPassword))
            {
                componentEvents.FireError(0, "SSISSFTTask", "FTP Password is required.", "", 0);
                isBaseValid = false;
            }

            #endregion

            #region TaskAction Check
            if (string.IsNullOrEmpty(TaskAction))
            {
                componentEvents.FireError(0, "SSISSFTTask", "No action choosed.", "", 0);
                isBaseValid = false;
            }

            if (TaskAction == Communication.ActionTask[0] || TaskAction == Communication.ActionTask[1])
            {
                if (string.IsNullOrEmpty(LocalPath))
                {
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please choose a source file or source folder for action {0}.", TaskAction), "", 0);
                    isBaseValid = false;
                }

                if (string.IsNullOrEmpty(RemotePath))
                {
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please chosse a destination file or destination folder for action {0}.", TaskAction), "", 0);
                    isBaseValid = false;
                }
            }

            if (TaskAction == Communication.ActionTask[2])
            {
                if (string.IsNullOrEmpty(RemotePath))
                {
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please choose a remote folder for action {0}.", TaskAction), "", 0);
                    isBaseValid = false;
                }
            }

            if (TaskAction == Communication.ActionTask[3])
            {
                if (string.IsNullOrEmpty(LocalPath))
                {
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please choose a local folder for action {0}.", TaskAction), "", 0);
                    isBaseValid = false;
                }
            }

            if (TaskAction == Communication.ActionTask[4])
            {
                if (string.IsNullOrEmpty(LocalPath))
                {
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please choose a remote folder for action {0}.", TaskAction), "", 0);
                    isBaseValid = false;
                }
            }

            if (TaskAction == Communication.ActionTask[5])
            {
                if (string.IsNullOrEmpty(LocalPath))
                {
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please choose a local folder for action {0}.", TaskAction), "", 0);
                    isBaseValid = false;
                }
            }

            if (TaskAction == Communication.ActionTask[6])
            {
                if (string.IsNullOrEmpty(RemotePath))
                {
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please choose a remote file for action {0}.", TaskAction), "", 0);
                    isBaseValid = false;
                }
            }

            if (TaskAction == Communication.ActionTask[7])
            {
                if (string.IsNullOrEmpty(LocalPath))
                {
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please choose a local file for action {0}.", TaskAction), "", 0);
                    isBaseValid = false;
                }
            }

            if (TaskAction == Communication.ActionTask[8])
            {
                if (string.IsNullOrEmpty(FilesList))
                {
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please specify an Object Variable for action {0}.", TaskAction), "", 0);
                    isBaseValid = false;
                }
            }

            #endregion

            return isBaseValid ? DTSExecResult.Success : DTSExecResult.Failure;
        }

        #endregion

        #region Execute

        /// <summary>
        /// This method is a run-time method executed dtsexec.exe
        /// </summary>
        /// <param name="connections"></param>
        /// <param name="variableDispenser"></param>
        /// <param name="componentEvents"></param>
        /// <param name="log"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public override DTSExecResult Execute(Connections connections, VariableDispenser variableDispenser, IDTSComponentEvents componentEvents, IDTSLogging log, object transaction)
        {
            bool refire = false;
            try
            {
                GetNeededVariables(variableDispenser, SFTPServer);
                GetNeededVariables(variableDispenser, SFTPUser);
                GetNeededVariables(variableDispenser, SFTPPassword);
                GetNeededVariables(variableDispenser, LocalPath);
                GetNeededVariables(variableDispenser, RemotePath);
                GetNeededVariables(variableDispenser, FilesList, true);

                variableDispenser.GetVariables(ref _vars);

                componentEvents.FireInformation(0, "SSISSFTTask", "START SFTP Task", string.Empty, 0, ref refire);
                componentEvents.FireInformation(0, "SSISSFTTask", string.Format("SFTP Server: \"{0}\", User \"{1}\"", EvaluateExpression(SFTPServer, variableDispenser), EvaluateExpression(SFTPUser, variableDispenser)), string.Empty, 0, ref refire);

                if (TaskAction == Communication.ActionTask[0]) //SEND FILE
                {
                    if (Communication.SendFileBySFtp(EvaluateExpression(SFTPServer, variableDispenser).ToString(),
                                                     EvaluateExpression(SFTPUser, variableDispenser).ToString(),
                                                     EvaluateExpression(SFTPPassword, variableDispenser).ToString(),
                                                     ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString()),
                                                     ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())))
                    {
                        componentEvents.FireInformation(0, "SSISSFTTask", string.Format("The file {0} has been copied to {1}", ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString()), ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0, ref refire);
                    }
                    else
                    {
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The file {0} has been copied to {1}", ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString()), ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[1]) //GET FILE
                {
                    if (Communication.GetFileBySFtp(EvaluateExpression(SFTPServer, variableDispenser).ToString(),
                                                    EvaluateExpression(SFTPUser, variableDispenser).ToString(),
                                                    EvaluateExpression(SFTPPassword, variableDispenser).ToString(),
                                                    ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString()),
                                                    ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString())))
                    {
                        componentEvents.FireInformation(0, "SSISSFTTask", string.Format("The file {0} has been copied", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0, ref refire);
                    }
                    else
                    {
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The file {0} hasn't been copied", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[2]) // CREATE REMOTE DIR
                {
                    if (Communication.CreateFolderBySFtp(EvaluateExpression(SFTPServer, variableDispenser).ToString(),
                                                         EvaluateExpression(SFTPUser, variableDispenser).ToString(),
                                                         EvaluateExpression(SFTPPassword, variableDispenser).ToString(),
                                                         ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())))
                    {
                        componentEvents.FireInformation(0, "SSISSFTTask", string.Format("The folder {0} has been created", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0, ref refire);
                    }
                    else
                    {
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The folder {0} hasn't been created", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[3]) // CREATE LOCAL DIR
                {
                    try
                    {
                        DirectoryInfo directoryInfo = Directory.CreateDirectory(LocalPath);
                        componentEvents.FireInformation(0, "SSISSFTTask",
                                                        directoryInfo.Exists
                                                            ? string.Format("The folder {0} has been created", ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString()))
                                                            : string.Format("The folder {0} hasn't been created", ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString())),
                                                        string.Empty, 0, ref refire);
                    }
                    catch (Exception exception)
                    {
                        componentEvents.FireError(0, "SSISSFTTask",
                                                        string.Format("The folder {0} hasn't been created. Exception detail {1} - {2}", ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString()), exception.Message, exception.Source),
                                                        string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[4]) //REMOVE REMOTE DIR
                {
                    if (Communication.RemoveFolderBySFtp(EvaluateExpression(SFTPServer, variableDispenser).ToString(),
                                                         EvaluateExpression(SFTPUser, variableDispenser).ToString(),
                                                         EvaluateExpression(SFTPPassword, variableDispenser).ToString(),
                                                         ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())))
                    {
                        componentEvents.FireInformation(0, "SSISSFTTask", string.Format("The remote folder {0} has been removed", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0, ref refire);
                    }
                    else
                    {
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The remote folder {0} hasn't been created", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[5]) //REMOVE LOCAL FOLDER
                {
                    try
                    {
                        Directory.Delete(LocalPath);
                        componentEvents.FireInformation(0, "SSISSFTTask",
                                                        string.Format("The local folder {0} has been removed", ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString())),
                                                        string.Empty, 0, ref refire);
                    }
                    catch (Exception exception)
                    {
                        componentEvents.FireError(0, "SSISSFTTask",
                                                        string.Format("The local folder {0} hasn't been removed. Exception detail {1} - {2}", ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString()), exception.Message, exception.Source),
                                                        string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[6]) //DELETE REMOTE FILE
                {
                    if (Communication.DeleteFileBySFtp(EvaluateExpression(SFTPServer, variableDispenser).ToString(),
                                                       EvaluateExpression(SFTPUser, variableDispenser).ToString(),
                                                       EvaluateExpression(SFTPPassword, variableDispenser).ToString(),
                                                       ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())))
                    {
                        componentEvents.FireInformation(0, "SSISSFTTask", string.Format("The remote file {0} has been deleted", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0, ref refire);
                    }
                    else
                    {
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The remote file {0} hasn't been deleted", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[7]) //DELETE LOCAL FILE
                {
                    try
                    {
                        File.Delete(ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString()));
                        componentEvents.FireInformation(0, "SSISSFTTask", string.Format("The local file {0} has been deleted", ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString())), string.Empty, 0, ref refire);
                    }
                    catch (Exception exception)
                    {
                        componentEvents.FireError(0, "SSISSFTTask",
                            string.Format("The local file {0} hasn't been deleted. Exception detail {1} - {2}", ResolveLocalPath(EvaluateExpression(LocalPath, variableDispenser).ToString()), exception.Message, exception.Source),
                            string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[8])
                {
                    //componentEvents.FireInformation(0, "SSISSFTTask", GetVariableFromNamespaceContext(FilesList) + " in action", string.Empty, 0, ref refire);

                    var retValue = Communication.GetFileListFromSFtp(EvaluateExpression(SFTPServer, variableDispenser).ToString(),
                                                                     EvaluateExpression(SFTPUser, variableDispenser).ToString(),
                                                                     EvaluateExpression(SFTPPassword, variableDispenser).ToString(),
                                                                     ResolveRemotePathEx(EvaluateExpression(RemotePath, variableDispenser).ToString()));

                    componentEvents.FireInformation(0, "SSISSFTTask", retValue.Count + " files founded", string.Empty, 0, ref refire);

                    foreach (var var in _vars)
                    {
                        componentEvents.FireInformation(0, "SSISSFTTask", var.Name, string.Empty, 0, ref refire);
                    }

                    //_vars[GetVariableFromNamespaceContext(FilesList)].Value = retValue;
                    _vars[FilesList.Replace("@[", string.Empty).Replace("]", string.Empty)].Value = retValue;

                    componentEvents.FireInformation(0, "SSISSFTTask", GetVariableFromNamespaceContext(FilesList) + " obtained the list of files", string.Empty, 0, ref refire);

                }

                componentEvents.FireInformation(0, "SSISSFTTask", "SFTP Task ended succesfully", string.Empty, 0, ref refire);
            }
            catch (Exception ex)
            {
                componentEvents.FireError(0, "SSISAssemblyTask", string.Format("Problem & Source : {0} - {1} - {2}", ex.Message, ex.Source, ex.StackTrace), "", 0);
            }
            finally
            {
                if (_vars.Locked)
                {
                    _vars.Unlock();
                }
            }

            return base.Execute(connections, variableDispenser, componentEvents, log, transaction);
        }

        #endregion

        #region Methods
        /// <summary>
        /// This method evaluate expressions like @[User::DestinationFile] + @[System::FileNumber] or any other operation created using 
        /// ExpressionBuilder
        /// </summary>
        /// <param name="mappedParam"></param>
        /// <param name="variableDispenser"></param>
        /// <returns></returns>
        private static object EvaluateExpression(string mappedParam, VariableDispenser variableDispenser)
        {
            object variableObject = null;

            try
            {
                var expressionEvaluatorClass = new ExpressionEvaluatorClass
                {
                    Expression = mappedParam
                };

                expressionEvaluatorClass.Evaluate(DtsConvert.GetExtendedInterface(variableDispenser), out variableObject, false);
            }
            catch (Exception) //maybe it's a fixed URL
            {
                variableObject = mappedParam;
            }

            return variableObject;
        }

        private void GetNeededVariables(VariableDispenser variableDispenser, string variableExpression, bool forWrite = false)
        {
            var mappedParams = variableExpression.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < mappedParams.Length - 1; index++)
            {
                try
                {
                    var param = mappedParams[index].Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    if (forWrite)
                        variableDispenser.LockForWrite(param.Substring(0, param.IndexOf(']')));
                    else
                        variableDispenser.LockForRead(param.Substring(0, param.IndexOf(']')));
                }
                catch
                {
                    //We will continue...
                }
            }
        }

        private string GetVariableFromNamespaceContext(string SSISVariables)
        {
            var param = SSISVariables.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1];
            return param.Substring(0, param.Length - 1);
        }

        private string ResolveRemotePath(string Path)
        {
            StringBuilder stringBuilder = new StringBuilder();

            const string slash = "/";
            if (!Path.StartsWith(slash))
                stringBuilder.Append(slash);

            stringBuilder.Append(Path);

            return stringBuilder.ToString().Trim();
        }

        private string ResolveRemotePathEx(string Path)
        {
            const string slash = "/";
            string retVal = string.Empty;
            if (Path.Length > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (!Path.StartsWith(slash))
                    stringBuilder.Append(slash);

                stringBuilder.Append(Path);

                if (!Path.EndsWith(slash))
                    stringBuilder.Append(slash);

                retVal = stringBuilder.ToString().Trim();
            }
            else
            {
                retVal = slash;
            }
            return retVal;
        }

        private string ResolveLocalPath(string Path)
        {
            //StringBuilder stringBuilder = new StringBuilder();

            //const string slash = "/";

            //stringBuilder.Append(Path);

            //if (!Path.EndsWith(slash))
            //    stringBuilder.Append(slash);

            //return stringBuilder.ToString();
            return Path.Trim();
        }

        #endregion

        #region Implementation of IDTSComponentPersist

        void IDTSComponentPersist.SaveToXML(XmlDocument doc, IDTSInfoEvents infoEvents)
        {
            XmlElement taskElement = doc.CreateElement(string.Empty, "SSISSFTPTask", string.Empty);

            XmlAttribute sftpServer = doc.CreateAttribute(string.Empty, NamedStringMembers.FTP_SERVER, string.Empty);
            sftpServer.Value = SFTPServer;

            XmlAttribute sftpUser = doc.CreateAttribute(string.Empty, NamedStringMembers.FTP_USER, string.Empty);
            sftpUser.Value = SFTPUser;

            XmlAttribute sftpPassword = doc.CreateAttribute(string.Empty, NamedStringMembers.FTP_PASSWORD, string.Empty);
            sftpPassword.Value = SFTPPassword;

            XmlAttribute sftpSourceFile = doc.CreateAttribute(string.Empty, NamedStringMembers.FTP_LOCAL_PATH, string.Empty);
            sftpSourceFile.Value = LocalPath;

            XmlAttribute sftpDestinationFile = doc.CreateAttribute(string.Empty, NamedStringMembers.FTP_REMOTE_PATH, string.Empty);
            sftpDestinationFile.Value = RemotePath;

            XmlAttribute sftpActionLists = doc.CreateAttribute(string.Empty, NamedStringMembers.FTP_ACTION_LIST, string.Empty);
            sftpActionLists.Value = TaskAction;

            XmlAttribute sftpFileLists = doc.CreateAttribute(string.Empty, NamedStringMembers.FTP_FILES_LIST, string.Empty);
            sftpFileLists.Value = FilesList;

            taskElement.Attributes.Append(sftpServer);
            taskElement.Attributes.Append(sftpUser);
            taskElement.Attributes.Append(sftpPassword);

            taskElement.Attributes.Append(sftpSourceFile);
            taskElement.Attributes.Append(sftpDestinationFile);
            taskElement.Attributes.Append(sftpActionLists);
            taskElement.Attributes.Append(sftpFileLists);

            doc.AppendChild(taskElement);
        }

        void IDTSComponentPersist.LoadFromXML(XmlElement node, IDTSInfoEvents infoEvents)
        {
            if (node.Name != "SSISSFTPTask")
            {
                throw new Exception("Unexpected task element when loading task.");
            }

            try
            {
                SFTPServer = node.Attributes.GetNamedItem(NamedStringMembers.FTP_SERVER).Value;
                SFTPUser = node.Attributes.GetNamedItem(NamedStringMembers.FTP_USER).Value;
                SFTPPassword = node.Attributes.GetNamedItem(NamedStringMembers.FTP_PASSWORD).Value;
                TaskAction = node.Attributes.GetNamedItem(NamedStringMembers.FTP_ACTION_LIST).Value;
                LocalPath = node.Attributes.GetNamedItem(NamedStringMembers.FTP_LOCAL_PATH).Value;
                RemotePath = node.Attributes.GetNamedItem(NamedStringMembers.FTP_REMOTE_PATH).Value;
                FilesList = node.Attributes.GetNamedItem(NamedStringMembers.FTP_FILES_LIST).Value;
            }
            catch
            {

            }
        }

        #endregion
    }
}
