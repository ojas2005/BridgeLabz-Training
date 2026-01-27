using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace CoreApp.Tests
{
    public class PerformanceUtilsTest
    {
        [Test]
        [Timeout(200)]
        public void LongRunningTask_FailsIfTooSlow()
        {
            PerformanceUtils utils = new PerformanceUtils();
            utils.LongRunningTask();
        }
    }
}
