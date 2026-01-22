namespace DataStreamProcessing.DataModel
{
    /// <summary>
    /// Represents an employee record with basic organizational information.
    /// </summary>
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public double AnnualSalary { get; set; }
    }
}
