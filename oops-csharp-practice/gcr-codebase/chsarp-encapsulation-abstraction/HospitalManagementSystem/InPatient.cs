using System;

namespace HospitalApp
{
    internal class InPatient : Patient
    {
        public int rno;
        public int dadmit;

        public InPatient(string pname, int page, long pid, int rno, int dadmit)
            : base(pname, page, pid)
        {
            this.rno=rno;
            this.dadmit=dadmit;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("patient name: " + pname);
            Console.WriteLine("patient age: " + page);
            Console.WriteLine("patient id: " + pid);
            Console.WriteLine("room no: " + rno);
            Console.WriteLine("days admitted: " + dadmit);
        }

        public override double GetBillAmount()
        {
            double rrate=500.0;
            return rrate * dadmit;
        }
    }
}
