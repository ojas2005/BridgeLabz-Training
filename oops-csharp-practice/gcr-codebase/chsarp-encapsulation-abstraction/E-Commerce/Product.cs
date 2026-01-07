using System;

namespace StoreApp
{
    internal abstract class Product
    {
        private int pid;
        private string pname;
        private double pprice;

        public int Pid { get { return pid; } }
        public string Pname { get { return pname; } }
        public double Pprice { get { return pprice; } }

        public void SetPid(int id) { pid=id; }
        public void SetPname(string n) { pname=n; }
        public void SetPprice(double p) { pprice=p; }

        public abstract double GetDiscount();
    }
}
