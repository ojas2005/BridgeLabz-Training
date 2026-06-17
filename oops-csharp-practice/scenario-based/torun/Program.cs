public class Employee{
    private int EmpNo;
    private string EmpName;
    private double Salary;
    private double HRA;
    private double TA;
    private double DA;
    private double PF;
    private double TDS;
    private double NetSalary;
    private static double GrossSalary;

    public Employee(int EmpNo,string EmpName,double Salary,double HRA,double TA,double DA,double NetSalary)
    {
        this.EmpNo = EmpNo;
        this.EmpName = EmpName;
        this.Salary = Salary;
        this.HRA = HRA;
        this.TA = TA;
        this.DA = DA;
        this.NetSalary = NetSalary;
    }
    public double CalcGrossSalar()
    {
        GrossSalary = Salary+TA+HRA+DA;
        return GrossSalary;
    }
    public double CalculateSalary()
    {
        double gross = CalcGrossSalar();
        PF = 0.10*gross;
        TDS = 0.18*gross;
        NetSalary = gross-(PF+TDS);
        return NetSalary;
    }
    public string Display(){
        GrossSalary = Salary+TA+HRA+DA;
        return EmpNo+","+EmpName+","+Salary+","+HRA+", "+TA+", "+DA+", "+PF+", "+TDS+", "+NetSalary+","+GrossSalary;
    }
}

class Program{
    static void Main()
    {
        Employee emp = new Employee(123,"Ojas",20000,120,22,32,25000);
        Console.WriteLine($"Gross salary is: {emp.CalcGrossSalar()}");
        Console.WriteLine($"net salary is: {emp.CalculateSalary}");
        Console.WriteLine(emp.Display());

    }
}