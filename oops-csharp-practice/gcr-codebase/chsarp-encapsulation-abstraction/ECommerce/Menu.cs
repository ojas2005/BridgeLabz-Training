using System;

namespace StoreApp
{
    internal class Menu
    {
        Product[] prods=new Product[3];
        int idx=0;

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. add electronics");
                Console.WriteLine("2. add clothing");
                Console.WriteLine("3. add groceries");
                Console.WriteLine("4. show final price");
                Console.WriteLine("5. exit");
                int c=int.Parse(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        AddProd(new Electronics());
                        break;
                    case 2:
                        AddProd(new Clothing());
                        break;
                    case 3:
                        AddProd(new Groceries());
                        break;
                    case 4:
                        ShowFinal();
                        break;
                    case 5:
                        return;
                }
            }
        }

        void AddProd(Product p)
        {
            if (idx >= prods.Length) return;

            Console.Write("id: ");
            p.SetPid(Convert.ToInt32(Console.ReadLine()));
            Console.Write("name: ");
            p.SetPname(Console.ReadLine());
            Console.Write("price: ");
            p.SetPprice(Convert.ToDouble(Console.ReadLine()));

            prods[idx++]=p;
        }

        void ShowFinal()
        {
            for (int i=0; i < idx; i++)
            {
                Product p=prods[i];
                double tax=0;

                if (p is ITaxable t)
                    tax=t.GetTax();

                double final=p.Pprice + tax - p.GetDiscount();
                Console.WriteLine(p.Pname + " final price: " + final);
            }
        }
    }
}
