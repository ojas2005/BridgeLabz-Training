using System;
class StudentVote
   {
       static void Main(String[] args)
       {
           // Input age of 10 students
           int numberOfStudents = 10;
           int[] age = new int[numberOfStudents];
           for (int i = 0; i < numberOfStudents; i++)
           {
               age[i] = Convert.ToInt32(Console.ReadLine());
           }
           
           bool[] result = CanStudentVote(age);
           for (int i = 0; i < numberOfStudents; i++)
           {
               Console.WriteLine(result[i]);
           }

       }
       public static bool[] CanStudentVote(int[] age)
       {
           // checking if student can vote or not
           bool[] result = new bool[age.Length];
           for (int i = 0; i < age.Length; i++)
           {
               if (age[i] >= 18)
               {
                   result[i] = true;
               }
               else
               {
                   result[i] = false;
               }
           }
           return result;
       }
   }
