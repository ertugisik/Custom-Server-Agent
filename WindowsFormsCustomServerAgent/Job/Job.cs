using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomServerAgent.Job
{
    public abstract class Job : IJob
    {
        JobExecuteContext _context;
        public virtual JobExecuteContext Context
        {
            get
            {
                if (_context == null)
                    _context = new JobExecuteContext();

                return _context;
            }
            set { _context = value; }
        }
        public virtual string JobName { get { return this.GetType().Name; } }
        public abstract int JobType { get; }
        public abstract int WorkingIntervalStart { get; }
        public abstract int WorkingIntervalEnd { get; }
        public abstract int IntervalInHour { get; }
        protected DateTime CurrentDate { get; set; }

        public bool CanExecute
        {
            get
            {
                if (DateTime.Now < Context.NextFireTime)
                {
                    return false;
                }

                if (DateTime.Now.Hour >= WorkingIntervalStart && DateTime.Now.Hour < WorkingIntervalEnd)
                {
                    if (CurrentDate.Date == DateTime.Now.Date)
                    {
                        Context.NextFireTime = FindNextFireTime();

                        return true;
                    }
                    else
                    {
                        SetDefault();
                        return CanExecute;
                    }
                }

                return false;
            }
        }

        public DateTime FindNextFireTime()
        {
            var dateTime = DateTime.Now.AddHours(IntervalInHour);

            if (WorkingIntervalStart <= dateTime.Hour && dateTime.Hour < WorkingIntervalEnd)
            {
                return dateTime;
            }
            else
            {
                var date = DateTime.Now.AddDays(1);

                return new DateTime(date.Year, date.Month, date.Day, WorkingIntervalStart, 0, 0);
            }
        }

        public void SetDefault() => CurrentDate = DateTime.Now;

        public abstract string Execute();
    }
}
