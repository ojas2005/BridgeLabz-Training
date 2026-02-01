using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.csharp_csv_data_handling
{
    internal class WriteEmployeesCsv
    {
        static void Main(string[] args)
        {
            using StreamWriter csvWriter = new StreamWriter("employee.csv");
            csvWriter.WriteLine("ID,Name,Dept,Salary");
            csvWriter.WriteLine("01,James Smith,HR,120000");
            csvWriter.WriteLine("02,Jessica Brown,HR,140000");
            csvWriter.WriteLine("03,Michael Johnson,HR,160000");
            csvWriter.WriteLine("04,Sarah Williams,HR,110000");
            csvWriter.WriteLine("05,Robert Martinez,HR,150000");
        }
    }
}
