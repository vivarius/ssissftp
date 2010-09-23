using System;
using System.Collections.Generic;
using Tamir.SharpSsh;

namespace SSISSFTPTask100.SSIS
{
    public static class Communication
    {
        public static List<string> ActionTask = new List<string>
                             {
                                  "Send File",
                                  "Get File",
                                  "Create Remote Directory",
                                  "Create Local Directory",
                                  "Remove Remote Directory",
                                  "Remove Local Directory",
                                  "Delete Remote File",
                                  "Delete Local File"//,
                                  //"Get Files List From Folder" 
                             };

        public static bool SendFileBySFtp(string url, string login, string password, string sourceFileName, string outputFileName)
        {
            bool retVal = false;

            try
            {
                Sftp sftp = new Sftp(url, login, password);
                sftp.Connect();
                sftp.Put(sourceFileName, outputFileName);
                retVal = true;
            }
            catch (Exception) { }

            return retVal;
        }

        public static bool GetFileBySFtp(string url, string login, string password, string sourceFileName, string outputFileName)
        {
            bool retVal = false;

            try
            {
                Sftp sftp = new Sftp(url, login, password);
                sftp.Connect();
                sftp.Get(sourceFileName, outputFileName);
                retVal = true;
            }
            catch (Exception) { }

            return retVal;
        }

        public static bool DeleteFileBySFtp(string url, string login, string password, string sourceFileName)
        {
            bool retVal = false;

            try
            {
                Sftp sftp = new Sftp(url, login, password);
                sftp.Connect();
                sftp.Delete(sourceFileName);
                retVal = true;
            }
            catch (Exception) { }

            return retVal;
        }

        public static bool RemoveFolderBySFtp(string url, string login, string password, string folderPath)
        {
            bool retVal = false;

            try
            {
                Sftp sftp = new Sftp(url, login, password);
                sftp.Connect();
                sftp.RemoveDir(folderPath);
                retVal = true;
            }
            catch (Exception) { }

            return retVal;
        }

        public static bool CreateFolderBySFtp(string url, string login, string password, string folderPath)
        {
            bool retVal = false;

            try
            {
                Sftp sftp = new Sftp(url, login, password);
                sftp.Connect();
                sftp.Mkdir(folderPath);
                retVal = true;
            }
            catch (Exception) { }

            return retVal;
        }

        public static List<string> GetFileListFromSFtp(string url, string login, string password, string folderPath)
        {
            List<string> retVal = new List<string>();

            try
            {
                Sftp sftp = new Sftp(url, login, password);
                sftp.Connect();
                retVal = sftp.GetFileList(folderPath);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return retVal;
        }
    }
}