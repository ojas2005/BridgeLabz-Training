public class Employee
{
    public string EmployeeId { get; set; }
    public double EmployeeSalary { get; set; }
    public string EmployeeEmail { get; set; }
    public string EmployeePhone { get; set; }

    public override string ToString()
    {
        return   EmployeeId + EmployeeSalary + EmployeeEmail + EmployeePhone;
    }
}
