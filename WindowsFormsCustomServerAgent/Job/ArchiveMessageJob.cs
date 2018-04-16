using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomServerAgent.Job
{

    public class ArchiveMessageJob : Job
    {
        public override int JobType => 1;
        public override int WorkingIntervalStart => 0;
        public override int WorkingIntervalEnd => 23;
        public override int IntervalInHour => 2;

        public override string Execute()
        {
            // code here..  
            this.Context.Success = true;

            return "I worked";
        }
    }
}
