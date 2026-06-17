using System;
class BmiCalculator
   {
       static void Main(String[] args)
       {
           
           int n = int.Parse(Console.ReadLine()); //Taking Input for number of persons
           double[,] personData = new Double[n, 3];
           String[] status = new string[n];
           
           // taking Input for  weight and height for each person
           for (int i = 0; i < n; i++)
           {
               personData[i, 0] = double.Parse(Console.ReadLine());
               personData[i, 1] = double.Parse(Console.ReadLine());
               personData[i, 2] = Bmi(personData[i, 0], personData[i, 1]);
               status[i] = BmiStatus(personData[i, 2]);
           }
           // Printing weight, height, BMI and status for each person.
           for (int i = 0; i < n; i++)
           {
               Console.WriteLine("Weight: " + personData[i, 0] + " Height: " + personData[i, 1] + " BMI: " + personData[i, 2] + " Status: " + status[i]);
           }

       }
       public static double Bmi(double weight, double height)
       {
           // calculate thebmi
           return weight / (height * height);
       }
       public static String BmiStatus(double bmi)
       {
           // determine the bmi status
           if (bmi < 18.5)
           {
               return "Underweight";
           }
           else if (bmi >= 18.5 && bmi < 24.9)
           {
               return "Normal weight";
           }
           else if (bmi >= 25 && bmi < 29.9)
           {
               return "Overweight";
           }
           else
           {
               return "Obesity";
           }
       }
   }
