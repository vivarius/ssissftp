using System;
using System.Collections.Generic;
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
        "Version=1.1.0.71," +
        "Culture=Neutral," +
        "PublicKeyToken=4598105d4a713364",
        IconResource = "SSISSFTPTask100.sftp.ico",
        TaskContact = "cosmin.vlasiu@gmail.com",
        RequiredProductLevel = DTSProductLevel.None
        )]
    public class SSISSFTTask : Task, IDTSComponentPersist
    {
        #region Constructor
        public SSISSFTTask()
        {
            _vars = null;
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

        [Category("File Transfer"), Description("Source from File Connector or from Variable/Expression")]
        public string LocalPathIsConnectionFileType { get; set; }

        [Category("File Transfer"), Description("Remote File")]
        public string RemotePath { get; set; }

        [Category("File Transfer"), Description("Get File List From an Remote Path // Object type variable")]
        public string FilesList { get; set; }

        [Category("File Transfer"), Description("Overwrite local file (for the GetFile action)")]
        public string OverwriteLocalPath { get; set; }


        #endregion

        #endregion

        #region Private Properties

        Variables _vars;

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
                if (string.IsNullOrEmpty(RemotePath))
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
                    componentEvents.FireError(0, "SSISSFTTask", string.Format("Please choose a remote path for action {0}.", TaskAction), "", 0);
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

            GetNeededVariables(variableDispenser);

            try
            {
                if (!string.IsNullOrEmpty(LocalPath))
                {
                    LocalPath = LocalPathIsConnectionFileType == Keys.TRUE
                                    ? connections[LocalPath].ConnectionString
                                    : EvaluateExpression(LocalPath, variableDispenser).ToString();
                }

                componentEvents.FireInformation(0, "SSISSFTTask", "START SFTP Task", string.Empty, 0, ref refire);
                componentEvents.FireInformation(0, "SSISSFTTask", string.Format("SFTP Server: \"{0}\", User \"{1}\"", EvaluateExpression(SFTPServer, variableDispenser), EvaluateExpression(SFTPUser, variableDispenser)), string.Empty, 0, ref refire);

                if (TaskAction == Communication.ActionTask[0]) //SEND FILE
                {
                    if (Communication.SendFileBySFtp(EvaluateExpression(SFTPServer, variableDispenser).ToString(),
                                                     EvaluateExpression(SFTPUser, variableDispenser).ToString(),
                                                     EvaluateExpression(SFTPPassword, variableDispenser).ToString(),
                                                     ResolveLocalPath(LocalPath),
                                                     ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())))
                    {
                        componentEvents.FireInformation(0, "SSISSFTTask", string.Format("The file {0} has been copied to {1}", ResolveLocalPath(LocalPath), ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0, ref refire);
                    }
                    else
                    {
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The file {0} has not been copied to {1}", ResolveLocalPath(LocalPath), ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[1]) //GET FILE
                {

                    if (Communication.GetFileBySFtp(EvaluateExpression(SFTPServer, variableDispenser).ToString(),
                                                    EvaluateExpression(SFTPUser, variableDispenser).ToString(),
                                                    EvaluateExpression(SFTPPassword, variableDispenser).ToString(),
                                                    ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString()),
                                                    ResolveLocalPath(LocalPath),
                                                    (OverwriteLocalPath == Keys.TRUE) ? true : false))
                    {
                        componentEvents.FireInformation(0, "SSISSFTTask", string.Format("The file {0} has been copied", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0, ref refire);
                    }
                    else
                    {
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The file {0} has not been copied", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
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
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The folder {0} has not been created", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[3]) // CREATE LOCAL DIR
                {
                    try
                    {
                        if (LocalPath != null)
                        {
                            DirectoryInfo directoryInfo = Directory.CreateDirectory(LocalPath);
                            componentEvents.FireInformation(0, "SSISSFTTask",
                                                            directoryInfo.Exists
                                                                ? string.Format("The folder {0} has been created", ResolveLocalPath(LocalPath))
                                                                : string.Format("The folder {0} has not been created", ResolveLocalPath(LocalPath)),
                                                            string.Empty, 0, ref refire);
                        }
                    }
                    catch (Exception exception)
                    {
                        componentEvents.FireError(0, "SSISSFTTask",
                                                        string.Format("The folder {0} has not been created. Exception detail {1} - {2}", ResolveLocalPath(LocalPath), exception.Message, exception.Source),
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
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The remote folder {0} has not been created", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[5]) //REMOVE LOCAL FOLDER
                {
                    try
                    {
                        if (LocalPath != null)
                        {
                            Directory.Delete(LocalPath);
                            componentEvents.FireInformation(0, "SSISSFTTask",
                                                            string.Format("The local folder {0} has been removed", ResolveLocalPath(LocalPath)),
                                                            string.Empty, 0, ref refire);
                        }
                    }
                    catch (Exception exception)
                    {
                        componentEvents.FireError(0, "SSISSFTTask",
                                                        string.Format("The local folder {0} has not been removed. Exception detail {1} - {2}", ResolveLocalPath(LocalPath), exception.Message, exception.Source),
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
                        componentEvents.FireError(0, "SSISSFTTask", string.Format("The remote file {0} has not been deleted", ResolveRemotePath(EvaluateExpression(RemotePath, variableDispenser).ToString())), string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[7]) //DELETE LOCAL FILE
                {
                    try
                    {
                        File.Delete(ResolveLocalPath(LocalPath));
                        componentEvents.FireInformation(0, "SSISSFTTask", string.Format("The local file {0} has been deleted", ResolveLocalPath(LocalPath)), string.Empty, 0, ref refire);
                    }
                    catch (Exception exception)
                    {
                        componentEvents.FireError(0, "SSISSFTTask",
                            string.Format("The local file {0} has not been deleted. Exception detail {1} - {2}", ResolveLocalPath(LocalPath), exception.Message, exception.Source),
                            string.Empty, 0);
                    }
                }

                if (TaskAction == Communication.ActionTask[8])
                {
                    var retValue = Communication.GetFileListFromSFtp(EvaluateExpression(SFTPServer, variableDispenser).ToString(),
                                                                     EvaluateExpression(SFTPUser, variableDispenser).ToString(),
                                                                     EvaluateExpression(SFTPPassword, variableDispenser).ToString(),
                                                                     ResolveRemotePathEx(EvaluateExpression(RemotePath, variableDispenser).ToString()));

                    componentEvents.FireInformation(0, "SSISSFTTask", retValue.Count + " file(s) founded:", string.Empty, 0, ref refire);
                    foreach (var file in retValue)
                    {
                        componentEvents.FireInformation(0, "SSISSFTTask", file, string.Empty, 0, ref refire);
                    }

                    _vars[GetVariableFromNamespaceContext(FilesList)].Value = retValue;

                    componentEvents.FireInformation(0, "SSISSFTTask", GetVariableFromNamespaceContext(FilesList) + " has obtained the list of files", string.Empty, 0, ref refire);
                }

                componentEvents.FireInformation(0, "SSISSFTTask", "SFTP Task ended succesfully", string.Empty, 0, ref refire);
            }
            catch (Exception ex)
            {
                componentEvents.FireError(0, "SSISSFTTask", string.Format("Problem & Source : {0} - {1} - {2}", ex.Message, ex.Source, ex.StackTrace), "", 0);
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
            catch (Exception) // for hardcoded values
            {
                variableObject = mappedParam;
            }

            return variableObject;
        }

        /// <summary>
        /// Determines whether [is variable in lock for read or write] [the specified lock for read].
        /// </summary>
        /// <param name="lockForReadWrite"></param>
        /// <param name="variable">The variable.</param>
        /// <returns>
        /// 	<c>true</c> if [is variable in lock for read or write] [the specified lock for read]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsVariableInLockForReadOrWrite(List<string> lockForReadWrite, string variable)
        {
            bool retVal = lockForReadWrite.Contains(variable);

            if (!retVal)
            {
                lockForReadWrite.Add(variable);
            }

            return retVal;
        }

        /// <summary>
        /// Gets the needed variables.
        /// </summary>
        /// <param name="variableDispenser">The variable dispenser.</param>
        private void GetNeededVariables(VariableDispenser variableDispenser)
        {

            var lockForReadWrite = new List<string>();

            {
                var mappedParams = SFTPServer.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string t in mappedParams)
                {
                    try
                    {
                        string param = t.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("[", string.Empty).Replace("]", string.Empty).Replace("@", string.Empty);
                        if (!IsVariableInLockForReadOrWrite(lockForReadWrite, param))
                            variableDispenser.LockForRead(param);
                    }
                    catch
                    {
                        //We will continue...
                    }
                }
            }

            {
                var mappedParams = SFTPUser.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string t in mappedParams)
                {
                    try
                    {
                        string param = t.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("[", string.Empty).Replace("]", string.Empty).Replace("@", string.Empty);
                        if (!IsVariableInLockForReadOrWrite(lockForReadWrite, param))
                            variableDispenser.LockForRead(param);
                    }
                    catch
                    {
                        //We will continue...
                    }
                }
            }

            {
                var mappedParams = SFTPPassword.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string t in mappedParams)
                {
                    try
                    {
                        string param = t.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("[", string.Empty).Replace("]", string.Empty).Replace("@", string.Empty);
                        if (!IsVariableInLockForReadOrWrite(lockForReadWrite, param))
                            variableDispenser.LockForRead(param);
                    }
                    catch
                    {
                        //We will continue...
                    }
                }
            }

            {
                var mappedParams = LocalPath.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string t in mappedParams)
                {
                    try
                    {
                        string param = t.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("[", string.Empty).Replace("]", string.Empty).Replace("@", string.Empty);
                        if (!IsVariableInLockForReadOrWrite(lockForReadWrite, param))
                            variableDispenser.LockForRead(param);
                    }
                    catch
                    {
                        //We will continue...
                    }
                }
            }

            {
                var mappedParams = RemotePath.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string t in mappedParams)
                {
                    try
                    {
                        string param = t.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("[", string.Empty).Replace("]", string.Empty).Replace("@", string.Empty);
                        if (!IsVariableInLockForReadOrWrite(lockForReadWrite, param))
                            variableDispenser.LockForRead(param);
                    }
                    catch
                    {
                        //We will continue...
                    }
                }
            }

            {
                var mappedParams = FilesList.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string t in mappedParams)
                {
                    try
                    {
                        string param = t.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("[", string.Empty).Replace("]", string.Empty).Replace("@", string.Empty);
                        if (!IsVariableInLockForReadOrWrite(lockForReadWrite, param))
                            variableDispenser.LockOneForWrite(param, ref _vars);
                    }
                    catch
                    {
                        //We will continue...
                    }
                }
            }

            //variableDispenser.GetVariables(ref _vars);
        }

        private static string GetVariableFromNamespaceContext(string ssisVariable)
        {
            return ssisVariable.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("[", string.Empty).Replace("]", string.Empty).Replace("@", string.Empty);
        }

        private static string ResolveRemotePath(string path)
        {
            var stringBuilder = new StringBuilder();

            const string slash = "/";
            if (!path.StartsWith(slash))
                stringBuilder.Append(slash);

            stringBuilder.Append(path.Replace(@"\", slash));

            return stringBuilder.ToString().Trim();
        }

        private static string ResolveRemotePathEx(string path)
        {
            const string slash = "/";
            string retVal;
            if (path.Length > 0)
            {
                var stringBuilder = new StringBuilder();

                if (!path.StartsWith(slash))
                    stringBuilder.Append(slash);

                stringBuilder.Append(path);

                if (!path.EndsWith(slash))
                    stringBuilder.Append(slash);

                retVal = stringBuilder.ToString().Trim();
            }
            else
            {
                retVal = slash;
            }
            return retVal;
        }

        private static string ResolveLocalPath(string path)
        {
            //StringBuilder stringBuilder = new StringBuilder();

            //const string slash = "/";

            //stringBuilder.Append(Path);

            //if (!Path.EndsWith(slash))
            //    stringBuilder.Append(slash);

            //return stringBuilder.ToString();
            return path.Trim();
        }

        #endregion

        #region Implementation of IDTSComponentPersist

        void IDTSComponentPersist.SaveToXML(XmlDocument doc, IDTSInfoEvents infoEvents)
        {
            XmlElement taskElement = doc.CreateElement(string.Empty, "SSISSFTPTask", string.Empty);

            XmlAttribute sftpServer = doc.CreateAttribute(string.Empty, Keys.FTP_SERVER, string.Empty);
            sftpServer.Value = SFTPServer;

            XmlAttribute sftpUser = doc.CreateAttribute(string.Empty, Keys.FTP_USER, string.Empty);
            sftpUser.Value = SFTPUser;

            XmlAttribute sftpPassword = doc.CreateAttribute(string.Empty, Keys.FTP_PASSWORD, string.Empty);
            sftpPassword.Value = SFTPPassword;

            XmlAttribute sftpSourceFile = doc.CreateAttribute(string.Empty, Keys.FTP_LOCAL_PATH, string.Empty);
            sftpSourceFile.Value = LocalPath;

            XmlAttribute sftpSourceFileType = doc.CreateAttribute(string.Empty, Keys.FTP_LOCAL_PATH_SOURCE_TYPE, string.Empty);
            sftpSourceFileType.Value = LocalPathIsConnectionFileType;

            XmlAttribute sftpDestinationFile = doc.CreateAttribute(string.Empty, Keys.FTP_REMOTE_PATH, string.Empty);
            sftpDestinationFile.Value = RemotePath;

            XmlAttribute sftpActionLists = doc.CreateAttribute(string.Empty, Keys.FTP_ACTION_LIST, string.Empty);
            sftpActionLists.Value = TaskAction;

            XmlAttribute sftpFileLists = doc.CreateAttribute(string.Empty, Keys.FTP_FILES_LIST, string.Empty);
            sftpFileLists.Value = FilesList;

            XmlAttribute overWriteLocalPath = doc.CreateAttribute(string.Empty, Keys.FTP_LOCAL_PATH_OVERWRITE, string.Empty);
            overWriteLocalPath.Value = OverwriteLocalPath;

            taskElement.Attributes.Append(sftpServer);
            taskElement.Attributes.Append(sftpUser);
            taskElement.Attributes.Append(sftpPassword);

            taskElement.Attributes.Append(sftpSourceFile);
            taskElement.Attributes.Append(sftpSourceFileType);
            taskElement.Attributes.Append(overWriteLocalPath);
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
                SFTPServer = node.Attributes.GetNamedItem(Keys.FTP_SERVER).Value;
                SFTPUser = node.Attributes.GetNamedItem(Keys.FTP_USER).Value;
                SFTPPassword = node.Attributes.GetNamedItem(Keys.FTP_PASSWORD).Value;
                TaskAction = node.Attributes.GetNamedItem(Keys.FTP_ACTION_LIST).Value;
                LocalPath = node.Attributes.GetNamedItem(Keys.FTP_LOCAL_PATH).Value;
                LocalPathIsConnectionFileType = node.Attributes.GetNamedItem(Keys.FTP_LOCAL_PATH_SOURCE_TYPE).Value;
                OverwriteLocalPath = node.Attributes.GetNamedItem(Keys.FTP_LOCAL_PATH_OVERWRITE).Value;
                RemotePath = node.Attributes.GetNamedItem(Keys.FTP_REMOTE_PATH).Value;
                FilesList = node.Attributes.GetNamedItem(Keys.FTP_FILES_LIST).Value;
            }
            catch (Exception)
            {

            }
        }

        #endregion
    }
}
