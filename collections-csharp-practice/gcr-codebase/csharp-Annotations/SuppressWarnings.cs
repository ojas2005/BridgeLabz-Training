using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    internal class SuppressWarnings
    {
        static void Main()
        {
#pragma warning disable CS0618, CS0168

            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add("Hello"); // Mixed types → unsafe

#pragma warning restore CS0618, CS0168

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
