using System;
class FindBonus{
    static void Main()
    {
        //Initialising arrays
        int size = 10;
        double[] salary = new double[size]; 
        double[] yearOfService = new double[size]; 
        double[] bonus = new double[size];
        double[] newSalary = new double[size];
        double totalBonus = 0;
        double totalOldSalary = 0;
        double totalNewSalary = 0;

        //taking input for salary and years of service.
        for(int i = 0;i<size;i++)
        {
            salary[i] = double.Parse(Console.ReadLine());
            yearOfService[i] = double.Parse(Console.ReadLine());
        }
        //checking if employees are having minimum 5 years of experience or not.
        for(int i =0;i<size;i++)
        {
        if(yearOfService[i]>5)
        {
            //calculating bonus amount for exployees having minimum 5 years of experience.
            bonus[i] = (salary[i]*5)/100;
            
        }
        //for employees having less than 5 years of experience.
        else{
            bonus[i] = (salary[i]*2)/100;
        }

        //calculating new salary,total bonus amount,old salary,total new salary.
        newSalary[i] = salary[i]+bonus[i];
        totalBonus = totalBonus+bonus[i];
        totalOldSalary = totalOldSalary+salary[i];
        totalNewSalary = totalNewSalary+newSalary[i];
        }

        //printing the results.
        Console.WriteLine($"Total Bonus Amount to be paid is {totalBonus}");
        Console.WriteLine($"Total Old Salary is {totalOldSalary}");
        Console.WriteLine($"Total new Salary is {totalNewSalary}");
    }
}