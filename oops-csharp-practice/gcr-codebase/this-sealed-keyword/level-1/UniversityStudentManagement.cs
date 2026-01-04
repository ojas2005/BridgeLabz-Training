using System;
class UniversityStudentManagement
    {
        static void Main(string[] args)
        {
            Student s1=new Student("Ojas",20,"A");

            if (s1 is Student)
            {
                s1.Show();
            }

            Student.ShowTotal();
        }
    }
    public class Student
    {
        public static string UniversityName="GLA University";
        static int count=0;
        public readonly int rollNo;
        string studentName;
        string studentGrade;
        public Student(string studentName,int rollNo,string studentGrade)
        {
            this.studentName=studentName;
            this.rollNo=rollNo;
            this.studentGrade=studentGrade;
            count++;
        }
        public static void ShowTotal()
        {
            Console.WriteLine($"total students are {count}");
        }
        public void Show()
        {
            Console.WriteLine($"Student name is {studentName}");
            Console.WriteLine($"Student roll number is {rollNo}");
            Console.WriteLine($"grade is {studentGrade}");
        }
    }
