using System;
class University
    {
        static void Main(string[] args)
        {
            student s1 = new student();
            student s2 = new student(0002, "madhav", 8.5);
            PostgraduateStudent s3 = new PostgraduateStudent();

            //using the display method in main
            s1.Display();
            s2.Display();
            s3.display();
        }

    }

    public class student
    {
        //creating the attributes
        public long rollNumber;
        protected string name;
        private double cgpa;
        // creating constructors
        public student()
        {
            this.name = "ELON";
            this.rollNumber = 37;
            this.cgpa = 8.2;
        }
        public student(long rollNumber,string name,double cgpa)
        {
            this.name = name;
            this.rollNumber = rollNumber;
            this.cgpa = cgpa;
        }
        // getter and setter for private 
        public double GetCgpa()
        {
            return cgpa;
        }
        
        public void SetCgpa(double cgpa)
        {
            if (cgpa>=0 && cgpa<=10)
            {
                this.cgpa=cgpa;
            }
            else
            {
                Console.WriteLine("enter valid cgpa");
            }
        }

        public void Display()
        {
            double cgpa = GetCgpa();
            Console.WriteLine($"Student {name} with roll number {rollNumber} has {cgpa}cgpa");
        }

    }

    public class PostgraduateStudent : student
    {
        public PostgraduateStudent() : base(43, "Steve", 6.92)
        {

        }
        // display method for child class
        public void display()
        {
            Console.WriteLine("the name of the student is " + name + " with roll number " + rollNumber + " and the cgpa of " + GetCgpa());
        }
    }