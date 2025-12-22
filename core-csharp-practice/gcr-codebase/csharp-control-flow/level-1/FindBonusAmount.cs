using System;
class FindBonusAmount{
    static void Main()
    {
        //Taking salary and years of service as input and taking bonus as 5% for employees having more than 5 years of experience.
        int salary = int.Parse(Console.ReadLine());
        int yearOfService = int.Parse(Console.ReadLine());
        int bonusPercentage = 5;
        double bonusAmount;

        //checking if employees are having minimum 5 years of experience or not.
        if(yearOfService>5)
        {
            //calculating and printing bonus amount for exployees having minimum 5 years of experience.
            bonusAmount = (salary*bonusPercentage)/100;
            Console.WriteLine($"The bonus amount is: {bonusAmount}");
        }
        //for employees having less than 5 years of experience.
        else{
            Console.WriteLine("No bonus for the employees having less than 5 years of Service");
        }
        
    }
}