using System;

namespace HospitalApp
{
    internal class Doctor
    {
        public string dname;
        public string dspec;
        public long did;
        public Patient[] plist=new Patient[10];
        int pcnt=0;

        public Doctor(string dname, string dspec, long did)
        {
            this.dname=dname;
            this.dspec=dspec;
            this.did=did;
        }

        public void AddPat(Patient p)
        {
            if (pcnt < plist.Length)
            {
                plist[pcnt]=p;
                pcnt++;
            }
            else
            {
                Console.WriteLine("cannot add more patients");
            }
        }

        public void PrintDoc()
        {
            Console.WriteLine("doctor name: " + dname);
            Console.WriteLine("specialization: " + dspec);
            Console.WriteLine("doctor id: " + did);
        }
    }
}
