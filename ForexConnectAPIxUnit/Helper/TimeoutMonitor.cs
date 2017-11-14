using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexConnect
{
    class TimeoutMonitor
    {
        private DateTime endTime;

        public TimeoutMonitor(int timeout = 60)
        {
            endTime = DateTime.Now.AddSeconds(timeout);
        }

        public bool CheckTimeout()
        {
            return (endTime < DateTime.Now);
        }
    }
}
