using System;

namespace OfficeApp
{
    internal abstract class Employee
    {
        private long id;
        private string nm;
        protected double sal;

        public Employee(long id, string nm, double sal)
        {
            this.id = id;
            this.nm = nm;
            this.sal = sal;
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nm
        {
            get { return nm; }
            set { nm = value; }
        }

        public abstract double GetSalary();

        public void Show()
        {
            Console.WriteLine("id: " + Id);
            Console.WriteLine("name: " + Nm);
            Console.WriteLine("salary: " + sal);
        }
    }
}
