using log4net;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Web.UI.WebControls;

namespace GDSG_GetFile_WS
{
    public partial class Service1 : ServiceBase
    {
        //khai báo biến log4net
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string DirectoryLocal = ConfigurationManager.AppSettings.Get("DirectoryLocal");
        private static string SftpHost = ConfigurationManager.AppSettings.Get("SftpHost");
        private static string SftpUser = ConfigurationManager.AppSettings.Get("SftpUser");
        private static string SftpPwd = ConfigurationManager.AppSettings.Get("SftpPwd");
        private System.Timers.Timer timer = null;
        //khai báo backgroundprocess
        private BackgroundWorker myWorker_GetFile = new BackgroundWorker();

        public Service1()
        {
            InitializeComponent();

            //khai báo properties của background process
            myWorker_GetFile.DoWork += new DoWorkEventHandler(myWorker_GetFile_DoWork);
            myWorker_GetFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_GetFile_RunWorkerCompleted);
            myWorker_GetFile.ProgressChanged += new ProgressChangedEventHandler(myWorker_GetFile_ProgressChanged);
            myWorker_GetFile.WorkerReportsProgress = true;
            myWorker_GetFile.WorkerSupportsCancellation = true;

            //chạy background_worker
            myWorker_GetFile.RunWorkerAsync();
        }

        protected override void OnStart(string[] args)
        {
            // Tạo 1 timer từ libary System.Timers
            timer = new System.Timers.Timer();
            // Execute mỗi 1p
            timer.Interval = 60000;
            // Những gì xảy ra khi timer đó dc tick
            timer.Elapsed += timer_Tick;
            // Enable timer
            timer.Enabled = true;
            // Ghi vào log file khi services dc start lần đầu tiên
            log.Info("GDSG_GetFile_WS is running!");
        }

        protected override void OnStop()
        {
            // Ghi log lại khi Services đã được stop
            timer.Enabled = false;
            log.Info("GDSG_GetFile_WS has been stop!");
        }

        private void timer_Tick(object sender, ElapsedEventArgs args)
        {
            if (args.SignalTime.Minute % 2 == 0)
            {
                try
                {
                    //log.Info(args.SignalTime);
                    myWorker_GetFile.RunWorkerAsync();
                }
                catch (Exception e)
                {
                    log.Error(String.Format("Can not run backgroud_worker myWorker_GetFile!|{0}", e.Message));
                }
            }
        }
        private void myWorker_GetFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void myWorker_GetFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            log.Info("myWorker_GetFile_RunWorkerCompleted has completed!");
        }

        private void myWorker_GetFile_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string host = SftpHost;
                string username = SftpUser;
                string password = SftpPwd;

                string remoteDirectory = "/odoo_backups/";
                string localDirectory = DirectoryLocal;

                using (var sftp = new SftpClient(host, username, password))
                {
                    sftp.Connect();
                    var files = sftp.ListDirectory(remoteDirectory);

                    foreach (var file in files)
                    {
                        string remoteFileName = file.Name;
                        string localFileName = DirectoryLocal + file.Name;
                        if (!file.Name.StartsWith(".") && !File.Exists(localFileName))
                        {
                            using (Stream file1 = File.Create(localDirectory + remoteFileName))
                            {
                                sftp.DownloadFile(remoteDirectory + remoteFileName, file1);
                                log.Info(string.Format("Download successfully file: {0}", remoteFileName));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
