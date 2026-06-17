using System;

namespace FoodApp
{
    internal class Menu
    {
        FoodItem[] fitems=new FoodItem[3];
        int fidx=0;

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("food menu");
                Console.WriteLine("1. add veg");
                Console.WriteLine("2. add non-veg");
                Console.WriteLine("3. show bill");
                Console.WriteLine("4. exit");
                int c=int.Parse(Console.ReadLine());

                switch (c)
                {
                    case 1: AddFood(new VegItem()); break;
                    case 2: AddFood(new NonVegItem()); break;
                    case 3: ShowBill(); break;
                    case 4: return;
                }
            }
        }

        void AddFood(FoodItem food)
        {
            if (fidx >= fitems.Length) return;

            Console.Write("food name: ");
            food.SetFname(Console.ReadLine());

            Console.Write("price: ");
            food.SetFprice(double.Parse(Console.ReadLine()));

            Console.Write("quantity: ");
            food.SetFqty(int.Parse(Console.ReadLine()));

            fitems[fidx++]=food;
        }

        void ShowBill()
        {
            for (int i=0; i < fidx; i++)
            {
                FoodItem food=fitems[i];
                double tot=food.CalcTotal();
                double disc=0;

                if (food is IDiscountable d)
                    disc=d.GetDiscount();

                Console.WriteLine(food.Fname + " pay: " + (tot - disc));
            }
        }
    }
}
