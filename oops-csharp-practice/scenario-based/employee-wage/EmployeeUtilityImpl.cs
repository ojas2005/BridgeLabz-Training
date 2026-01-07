using System;
class EmployeeUtilityImpl : IEmployee{
    private Employee employee ;
    public Employee AddEmployee(){
        employee = new Employee();
        return employee;
    }
    public void Attendace()
    {
        Random r = new Random();
        int n = r.Next(0,1);
        if(n==0)
        {
            Console.WriteLine("Absent");
        } 
        else{
            Console.WriteLine("Present");
        }
    }
}