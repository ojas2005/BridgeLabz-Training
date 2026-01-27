using CoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp_MS_Testing
{
    public class PerformanceUtilsMSTest
    {
        [TestMethod]
        [Timeout(2000)]
        public void LongRunningTask_FailsIfTooSlow()
        {
            PerformanceUtils utils = new PerformanceUtils();
            utils.LongRunningTask();
        }
    }
}
