using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCustomServerAgent.Job;

namespace WindowsFormsCustomServerAgent
{
    public partial class Form1 : Form
    {
        JobTrigger triggerArchiveMessage;
        JobTrigger triggerSendEmail;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10000;

            triggerArchiveMessage = new JobTrigger(new ArchiveMessageJob());
            triggerArchiveMessage.JobExecuted += JobExecuted;

            triggerSendEmail = new JobTrigger(new SendEmailJob());
            triggerSendEmail.JobExecuted += JobExecuted;
        }

        private void JobExecuted(object sender, JobExecutedEventArgs e)
        {
            // Log event args
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            triggerArchiveMessage.Execute();
            triggerSendEmail.Execute();
        }
    }
}
