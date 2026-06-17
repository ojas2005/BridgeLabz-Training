using System;

namespace HospitalApp
{
    internal class Menu
    {
        public Doctor[] dlist=new Doctor[4];

        public void GetDocs()
        {
            for (int i=0; i < dlist.Length; i++)
            {
                Console.Write("doctor name: ");
                string dname=Console.ReadLine();
                Console.Write("specialization: ");
                string dspec=Console.ReadLine();
                Console.Write("doctor id: ");
                long did=Convert.ToInt64(Console.ReadLine());
                dlist[i]=new Doctor(dname, dspec, did);
            }
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("welcome to hospital");
                Console.WriteLine("1. show doctors");
                Console.WriteLine("2. patient entry");
                Console.WriteLine("3. patient exit");
                Console.WriteLine("4. exit");

                int c=Convert.ToInt32(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        ShowDocs();
                        break;
                    case 2:
                        PatIn();
                        break;
                    case 3:
                        PatOut();
                        break;
                    case 4:
                        return;
                }
            }
        }

        public void ShowDocs()
        {
            Console.WriteLine("doctor list:");
            for (int i=0; i < dlist.Length; i++)
            {
                dlist[i].PrintDoc();
            }
        }

        public void PatIn()
        {
            Console.Write("choose doctor (0-3): ");
            int dno=Convert.ToInt32(Console.ReadLine());

            if (dno < 0 || dno > 3)
            {
                Console.WriteLine("invalid input");
                return;
            }

            Console.Write("patient name: ");
            string pname=Console.ReadLine();
            Console.Write("patient age: ");
            int page=Convert.ToInt32(Console.ReadLine());
            Console.Write("patient id: ");
            long pid=Convert.ToInt64(Console.ReadLine());

            Console.Write("choose 1 for inpatient, 2 for outpatient: ");
            int ptype=Convert.ToInt32(Console.ReadLine());

            Patient p;
            if (ptype == 1)
            {
                Console.Write("room no: ");
                int rno=Convert.ToInt32(Console.ReadLine());
                Console.Write("days admitted: ");
                int dadm=Convert.ToInt32(Console.ReadLine());

                p=new InPatient(pname, page, pid, rno, dadm);
            }
            else
            {
                Console.Write("appointment date: ");
                string adate=Console.ReadLine();
                Console.Write("consultation fee: ");
                int cfee=Convert.ToInt32(Console.ReadLine());

                p=new OutPatient(pname, page, pid, adate, cfee);
            }

            dlist[dno].AddPat(p);
        }

        public void PatOut()
        {
            Console.Write("enter doctor (0-3): ");
            int dno=Convert.ToInt32(Console.ReadLine());

            Console.Write("enter patient (0-9): ");
            int pno=Convert.ToInt32(Console.ReadLine());

            Patient p=dlist[dno].plist[pno];

            if (p != null)
            {
                Bill.GenBill(p);
            }
            else
            {
                Console.WriteLine("patient not found");
            }
        }
    }
}
