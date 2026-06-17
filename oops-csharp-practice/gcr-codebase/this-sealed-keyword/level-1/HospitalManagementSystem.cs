using System;
class MedicalCenter
    {
        static void Main(string[] args)
        {
            Person pt1=new Person("Riya",28,"Cold",601);

            if (pt1 is Person)
            {
                pt1.Show();
            }

            Person.ShowCount();
        }
    }
    public class Person
    {
        public static string centerName= "Apollo Hospital";
        static int personCount=0;

        public readonly int personId;
        string personName;
        int personAge;
        string problem;

        public Person(string personName,int personAge,string problem,int personId)
        {
            this.personName=personName;
            this.personAge=personAge;
            this.problem=problem;
            this.personId=personId;
            personCount++;
        }

        public static void ShowCount()
        {
            Console.WriteLine($"total patients are {personCount}");
        }

        public void Show()
        {
            Console.WriteLine($"patient name is {personName}");
            Console.WriteLine($"patient age is {personAge}");
            Console.WriteLine($"patient problem is {problem}");
        }
    }

