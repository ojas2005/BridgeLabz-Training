using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class LegacyAPI
    {
        [Obsolete("OldFeature is deprecated. Use NewFeature instead.")]
        public void OldFeature()
        {
            Console.WriteLine("Executing old feature");
        }

        public void NewFeature()
        {
            Console.WriteLine("Executing new feature");
        }
    }
    class Legacy
    {
        static void Main()
        {
            LegacyAPI api = new LegacyAPI();

            api.OldFeature(); // Compiler warning
            api.NewFeature(); // Recommended method
        }
    }
}
