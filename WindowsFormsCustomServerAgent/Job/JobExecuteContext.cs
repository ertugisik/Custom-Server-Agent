using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomServerAgent.Job
{
    public class JobExecuteContext
    {
        public DateTime StartFireTime { get; set; }
        public DateTime EndFireTime { get; set; }
        public DateTime NextFireTime { get; set; }
        public bool Success { get; set; }
    }
}
