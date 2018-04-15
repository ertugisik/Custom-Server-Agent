using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCustomServerAgent.Job
{
    public interface IJob
    {
        string Execute(); 
    }
}
