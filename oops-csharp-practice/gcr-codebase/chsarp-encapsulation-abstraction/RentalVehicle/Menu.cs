using System;

namespace RentalApp
{
    internal class Menu
    {
        public Customer GetCustInfo()
        {
            Console.Write("customer name: ");
            string cn=Console.ReadLine();
            Console.Write("customer id: ");
            long cid=Convert.ToInt32(Console.ReadLine());
            Console.Write("days to rent: ");
            int dys=Convert.ToInt32(Console.ReadLine());

            return new Customer(cn, cid, dys);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("rental menu");
                Console.WriteLine("1. rent bike");
                Console.WriteLine("2. rent car");
                Console.WriteLine("3. rent truck");
                Console.WriteLine("4. exit");

                int c=Convert.ToInt32(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        RentBk();
                        break;
                    case 2:
                        RentCr();
                        break;
                    case 3:
                        RentTr();
                        break;
                    case 4:
                        return;
                }
            }
        }

        public void RentBk()
        {
            Console.Write("enter id: ");
            long id=Convert.ToInt32(Console.ReadLine());
            Console.Write("enter type: ");
            string type=Console.ReadLine();

            Vehicle bk=new Bike(id, type);
            bk.PrintInfo();
            Customer cust=GetCustInfo();
            Console.WriteLine("total rent for bike: " + bk.CalcRent(cust));
        }

        public void RentCr()
        {
            Console.Write("enter id: ");
            long id=Convert.ToInt32(Console.ReadLine());
            Console.Write("enter type: ");
            string type=Console.ReadLine();

            Vehicle cr=new Car(id, type);
            cr.PrintInfo();
            Customer cust=GetCustInfo();
            Console.WriteLine("total rent for car: " + cr.CalcRent(cust));
        }

        public void RentTr()
        {
            Console.Write("enter id: ");
            long id=Convert.ToInt32(Console.ReadLine());
            Console.Write("enter type: ");
            string type=Console.ReadLine();

            Vehicle tr=new Truck(id, type);
            tr.PrintInfo();
            Customer cust=GetCustInfo();
            Console.WriteLine("total rent for truck: " + tr.CalcRent(cust));
        }
    }
}
