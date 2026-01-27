using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class PerformanceUtils
    {
        public void LongRunningTask()
        {
            Thread.Sleep(3000);
        }
    }
}
