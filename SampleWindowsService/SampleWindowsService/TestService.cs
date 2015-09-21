using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SampleWindowsService
{
    public partial class TestService : ServiceBase
    {
        private Timer timer1 = null;
        private void timer1Tick(object sender, ElapsedEventArgs e)
        {
            Functions.LogMessage("A message has been generated");
        }
        
        public TestService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Functions.LogMessage("Called OnStart()");
            timer1 = new Timer();
            this.timer1.Interval = 30000;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1Tick);
            this.timer1.Enabled = true;
            Functions.LogMessage("TimerEnabled");
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            Functions.LogMessage("Called OnStop()");
        }

       
    }
}
