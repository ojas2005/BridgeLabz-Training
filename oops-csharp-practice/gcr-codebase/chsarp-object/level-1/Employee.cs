using System;
class Employee{
    public string name;
    public string id;
    public double salary;
    public Employee(string name,string id,double salary)
    {
        this.name = name;
        this.id = id;
        this.salary = salary;

    }
        public void Details(){
        Console.WriteLine("Name:"+name);
        Console.WriteLine("id:"+id);
        Console.WriteLine("Salary:" + salary);
    }
}
class Program{
    static void Main()
    {
        Console.WriteLine("Enter the name of the employee");
        string name= Console.ReadLine();
        Console.WriteLine("Enter the ID of the employee");
        string id = Console.ReadLine();
        Console.WriteLine("Enter the Salary of the employee");
        double salary = double.Parse(Console.ReadLine());
        Employee e = new Employee(name,id,salary);
        Console.WriteLine("Here are the details of the employee");
        e.Details();

    }
}