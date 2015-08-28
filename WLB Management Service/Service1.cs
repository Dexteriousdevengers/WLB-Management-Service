using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WLB_Management_Service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();

        }
        public DateTime effectiveTime;
        

        protected override void OnStart(string[] args)
        {


            bool a = WriteFile();

        }

        public bool WriteFile()
        {
            try
            {
                FileStream fs = new FileStream(@"c:\SystemActiveTimeInformation.txt",
               FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sWriter = new StreamWriter(fs);
                sWriter.BaseStream.Seek(0, SeekOrigin.End);
                sWriter.WriteLine("=====================================================================================");
                sWriter.WriteLine("System Turn On Time: \t " + DateTime.Now);
                sWriter.WriteLine("Timer Started at: " + DateTime.Now);
                sWriter.Flush();
                sWriter.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertSesssionDetails(SessionChangeDescription strReason)
        {

            try
            {
                FileStream fs = new FileStream(@"c:\SystemActiveTimeInformation.txt",
                FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sWriter = new StreamWriter(fs);
                sWriter.BaseStream.Seek(0, SeekOrigin.End);
                switch (strReason.Reason)
                {
                    case SessionChangeReason.SessionLogon:
                        sWriter.WriteLine("System Log On Time: \t " + DateTime.Now);
                        break;
                    case SessionChangeReason.SessionLogoff:
                        sWriter.WriteLine("System Log Off Time: \t " + DateTime.Now);
                        
                        break;
                    case SessionChangeReason.RemoteConnect:
                        sWriter.WriteLine("System Remote Connect Time: \t " + DateTime.Now);
                        break;
                    case SessionChangeReason.RemoteDisconnect:
                        sWriter.WriteLine("System Remote Disconnect Time: \t " + DateTime.Now);
                        
                        break;
                    case SessionChangeReason.SessionLock:
                        sWriter.WriteLine("System Locked Time: \t" + DateTime.Now);
                        
                        break;
                    case SessionChangeReason.SessionUnlock:
                        sWriter.WriteLine("System Unlocked Time: \t " + DateTime.Now);

                        break;
                    default:
                        break;
                }
                sWriter.Flush();
                sWriter.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            bool b = InsertSesssionDetails(changeDescription);
        }

        protected override void OnShutdown()
        {
            FileStream fs = new FileStream(@"c:\SystemActiveTimeInformation.txt",
            FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sWriter = new StreamWriter(fs);
            sWriter.BaseStream.Seek(0, SeekOrigin.End);
            sWriter.WriteLine("System Turn Off Time: \n " + DateTime.Now);
            sWriter.Flush();
            sWriter.Close();
        }

        protected override void OnStop()
        {
        }
    }
}
