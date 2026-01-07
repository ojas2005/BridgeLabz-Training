using System;

namespace HospitalApp
{
    internal class Bill
    {
        public static void GenBill(Patient p)
        {
            p.PrintInfo();
            double total=p.GetBillAmount();
            Console.WriteLine("total bill: " + total);
        }
    }
}
