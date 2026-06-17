using System;

namespace HospitalApp
{
    internal class OutPatient : Patient
    {
        public string adate;
        public int cfee;

        public OutPatient(string pname, int page, long pid, string adate, int cfee)
            : base(pname, page, pid)
        {
            this.adate=adate;
            this.cfee=cfee;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("patient name: " + pname);
            Console.WriteLine("patient age: " + page);
            Console.WriteLine("patient id: " + pid);
            Console.WriteLine("appointment date: " + adate);
            Console.WriteLine("consultation fee: " + cfee);
        }

        public override double GetBillAmount()
        {
            return cfee;
        }
    }
}
