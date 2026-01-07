class EmployeeUtilityImpl : IEmployee
{
    public Employee AddEmployee()
    {
        return new Employee();
    }
    public string Attendace(Employee emp)
    {
        Random r = new Random();
        int n = r.Next(0,2);

        if (n==0)
            return "Absent";

        return "Present";
    }
}
