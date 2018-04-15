using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomServerAgent.Job
{
    public class JobExecutedEventArgs : EventArgs
    {
        public JobExecutedEventArgs(Job job, string summary)
        {
            StartFireTime = job.Context.StartFireTime;
            EndFireTime = job.Context.EndFireTime;
            NextFireTime = job.Context.NextFireTime;
            JobName = job.JobName;
            JobType = job.JobType;
            Success = job.Context.Success;
            Summary = summary;
        }

        public DateTime StartFireTime { get; set; }
        public DateTime EndFireTime { get; set; }
        public DateTime NextFireTime { get; set; }
        public string JobName { get; set; }
        public int JobType { get; set; }
        public string Summary { get; set; }
        public bool Success { get; set; }
    }
}
