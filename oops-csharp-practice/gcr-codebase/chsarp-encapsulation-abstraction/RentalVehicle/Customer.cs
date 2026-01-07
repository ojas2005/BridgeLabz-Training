using System;

namespace RentalApp
{
    internal class Customer
    {
        public string cname;
        public long cid;
        public int dys;

        public Customer(string cname, long cid, int dys)
        {
            this.cname=cname;
            this.cid=cid;
            this.dys=dys;
        }
    }
}
