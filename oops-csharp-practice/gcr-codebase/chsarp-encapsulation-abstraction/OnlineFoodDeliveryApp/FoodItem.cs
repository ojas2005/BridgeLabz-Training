using System;

namespace FoodApp
{
    internal abstract class FoodItem
    {
        private string fname;
        private double fprice;
        private int fqty;

        public string Fname { get { return fname; } }
        public double Fprice { get { return fprice; } }
        public int Fqty { get { return fqty; } }

        public void SetFname(string n) { fname=n; }
        public void SetFprice(double p) { fprice=p; }
        public void SetFqty(int q) { fqty=q; }

        public void PrintFood()
        {
            Console.WriteLine(fname + " qty: " + fqty);
        }

        public abstract double CalcTotal();
    }
}
