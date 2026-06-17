using System;

namespace HospitalApp
{
    internal abstract class Patient : IPlayable
    {
        public string pname;
        public int page;
        public long pid;

        protected Patient(string pname, int page, long pid)
        {
            this.pname=pname;
            this.page=page;
            this.pid=pid;
        }

        public abstract void PrintInfo();
        public abstract double GetBillAmount();
    }
}
