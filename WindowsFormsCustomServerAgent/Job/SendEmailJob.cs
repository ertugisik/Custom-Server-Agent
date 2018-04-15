using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomServerAgent.Job
{
    public class SendEmailJob : Job
    {
        public override int JobType => 2;

        public override int WorkingIntervalStart => 9;

        public override int WorkingIntervalEnd => 17;

        public override int IntervalInHour => 3;

        public override string Execute()
        {
            // do something
            return "I did!";
        }
    }
}
