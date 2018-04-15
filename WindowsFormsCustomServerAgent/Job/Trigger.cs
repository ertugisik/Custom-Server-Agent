using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomServerAgent.Job
{
    public class JobTrigger
    {
        Job job;
        public delegate void JobExecutedHandler(object sender, JobExecutedEventArgs e);
        public event JobExecutedHandler JobExecuted;

        public JobTrigger(Job job)
        {
            this.job = job;
        }

        public JobExecuteContext Execute()
        {
            if (job.CanExecute)
            {
                job.Context.StartFireTime = DateTime.Now;
                var summary = job.Execute();
                job.Context.EndFireTime = DateTime.Now;

                AfterJobExecuted(new JobExecutedEventArgs(job, summary));

                return job.Context;
            }

            return null;
        }

        private void AfterJobExecuted(JobExecutedEventArgs arg)
        {
            if (JobExecuted != null)
            {
                JobExecuted(job, arg);
            }
        }
    }
}
