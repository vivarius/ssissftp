using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tamir.SharpSsh.java.util;
using Tamir.SharpSsh.jsch;
using System.Collections;

/* 
 * Sftp.cs
 * 
 * Copyright (c) 2006 Tamir Gal, http://www.tamirgal.com, All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 *  	1. Redistributions of source code must retain the above copyright notice,
 *		this list of conditions and the following disclaimer.
 *
 *	    2. Redistributions in binary form must reproduce the above copyright 
 *		notice, this list of conditions and the following disclaimer in 
 *		the documentation and/or other materials provided with the distribution.
 *
 *	    3. The names of the authors may not be used to endorse or promote products
 *		derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHOR
 *  *OR ANY CONTRIBUTORS TO THIS SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT,
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA,
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
 * EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 **/

namespace Tamir.SharpSsh
{
    public class Sftp : SshTransferProtocolBase
    {
        private MyProgressMonitor m_monitor;
        private bool cancelled = false;

        public Sftp(string sftpHost, string user, string password)
            : base(sftpHost, user, password)
        {
            Init();
        }

        public Sftp(string sftpHost, string user)
            : base(sftpHost, user)
        {
            Init();
        }

        private void Init()
        {
            m_monitor = new MyProgressMonitor(this);
        }

        protected override string ChannelType
        {
            get { return "sftp"; }
        }

        private ChannelSftp SftpChannel
        {
            get { return (ChannelSftp)m_channel; }
        }

        public override void Cancel()
        {
            cancelled = true;
        }

        //Get

        public void Get(string fromFilePath)
        {
            Get(fromFilePath, ".");
        }

        public void Get(string[] fromFilePaths)
        {
            foreach (string t in fromFilePaths)
            {
                Get(t);
            }
        }

        public void Get(string[] fromFilePaths, string toDirPath)
        {
            foreach (string t in fromFilePaths)
            {
                Get(t, toDirPath);
            }
        }

        public override void Get(string fromFilePath, string toFilePath)
        {
            cancelled = false;
            SftpChannel.get(fromFilePath, toFilePath, m_monitor, ChannelSftp.OVERWRITE);
        }

        //Put

        public void Put(string fromFilePath)
        {
            Put(fromFilePath, ".");
        }

        public void Put(string[] fromFilePaths)
        {
            foreach (string t in fromFilePaths)
            {
                Put(t);
            }
        }

        public void Put(string[] fromFilePaths, string toDirPath)
        {
            foreach (string t in fromFilePaths)
            {
                Put(t, toDirPath);
            }
        }

        public override void Put(string fromFilePath, string toFilePath)
        {
            if (fromFilePath.Contains("*") || fromFilePath.Contains("?"))
            {
                int lastBackSlashIndex = fromFilePath.LastIndexOf('\\');

                string dir = fromFilePath.Substring(0, lastBackSlashIndex + 1);
                string pattern = fromFilePath.Substring(lastBackSlashIndex + 1, fromFilePath.Length - lastBackSlashIndex - 1);

                string[] filePaths = Directory.GetFiles(dir, pattern);

                foreach (var filePath in filePaths)
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    SftpChannel.put(filePath,
                                    (toFilePath[toFilePath.Length - 1] == '\\')
                                        ? toFilePath + fileInfo.Name
                                        : toFilePath + '\\' + fileInfo.Name,
                                    m_monitor,
                                    ChannelSftp.OVERWRITE);
                }
            }
            else
                SftpChannel.put(fromFilePath, toFilePath, m_monitor, ChannelSftp.OVERWRITE);
        }

        //MkDir

        public override void Mkdir(string directory)
        {
            SftpChannel.mkdir(directory);
        }

        //Ls
        public List<string> GetFileList(string path)
        {
            return (from ChannelSftp.LsEntry entry in SftpChannel.ls(path)
                    where !entry.getAttrs().isDir()
                    select entry.getFilename()).Select(f => (string)f).ToList();
        }

        //Ls
        public List<string> GetFileListWithPattern(string path, string pattern)
        {
            List<string> list = new List<string>();

            foreach (ChannelSftp.LsEntry entry in SftpChannel.ls(path))
            {
                if (!entry.getAttrs().isDir())
                {
                    list.Add(entry.getFilename());
                }
            }

            return list;
        }

        //Delete
        public void Delete(string filePath)
        {
            SftpChannel.rm(filePath);
        }

        //Delete
        public void RemoveDir(string dirPath)
        {
            SftpChannel.rmdir(dirPath);
        }

        #region ProgressMonitor Implementation

        private class MyProgressMonitor : SftpProgressMonitor
        {
            private long transferred = 0;
            private long total = 0;
            private int elapsed = -1;
            private Sftp m_sftp;
            private string src;
            private string dest;

            System.Timers.Timer timer;

            public MyProgressMonitor(Sftp sftp)
            {
                m_sftp = sftp;
            }

            public override void init(int op, String src, String dest, long max)
            {
                this.src = src;
                this.dest = dest;
                this.elapsed = 0;
                this.total = max;
                timer = new System.Timers.Timer(1000);
                timer.Start();
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

                string note;
                if (op.Equals(GET))
                {
                    note = "Downloading " + System.IO.Path.GetFileName(src) + "...";
                }
                else
                {
                    note = "Uploading " + System.IO.Path.GetFileName(src) + "...";
                }
                m_sftp.SendStartMessage(src, dest, (int)total, note);
            }
            public override bool count(long c)
            {
                this.transferred += c;
                string note = ("Transfering... [Elapsed time: " + elapsed + "]");
                m_sftp.SendProgressMessage(src, dest, (int)transferred, (int)total, note);
                return !m_sftp.cancelled;
            }
            public override void end()
            {
                timer.Stop();
                timer.Dispose();
                string note = ("Done in " + elapsed + " seconds!");
                m_sftp.SendEndMessage(src, dest, (int)transferred, (int)total, note);
                transferred = 0;
                total = 0;
                elapsed = -1;
                src = null;
                dest = null;
            }

            private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                this.elapsed++;
            }
        }

        #endregion ProgressMonitor Implementation
    }
}
