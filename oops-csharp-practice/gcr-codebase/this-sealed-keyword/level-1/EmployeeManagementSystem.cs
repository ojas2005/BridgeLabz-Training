using System;
class EmployeeManagementSystem
    {
        static void Main(string[] args)
        {
            Staff s1=new Staff("ojas",1194,"Trainee");

            if (s1 is Staff)
            {
                s1.Show();
            }

            Staff.ShowTotal();
        }
    }
    public class Staff
    {
        public static string orgName="BridgeLabz";
        static int staffCount=0;
        public readonly int staffId;
        string staffName;
        string role;
        public Staff(string staffName,int staffId,string role)
        {
            this.staffName=staffName;
            this.staffId=staffId;
            this.role=role;
            staffCount++;
        }

        public static void ShowTotal()
        {
            Console.WriteLine($"total employees are {staffCount}");
        }

        public void Show()
        {
            Console.WriteLine($"employee name is {staffName}");
            Console.WriteLine($"employee id is {staffId}");
            Console.WriteLine($"employee role is {role}");
        }
    }
