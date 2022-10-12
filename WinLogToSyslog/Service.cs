using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WinLogToSyslog
{
    public partial class Service : ServiceBase
    {
        const string SOURCE_NAME = "WinLogToSyslog";
        const string LOG_NAME = "Windows Log to Syslog Service";
        public Service()
        {
            InitializeComponent();

            eventLog = new EventLog();
            if (!EventLog.SourceExists(SOURCE_NAME))
            {
                EventLog.CreateEventSource(SOURCE_NAME, LOG_NAME);
            }
            eventLog.Source = SOURCE_NAME;
            eventLog.Log = LOG_NAME;
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("WinLogToSyslog service was started.");
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("WinLogToSyslog service was stopped.");
        }
    }
}
