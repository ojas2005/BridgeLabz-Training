using System;
class CalculateBMI{
    static void Main()
    {

        //initialising 2D array
        Console.WriteLine("Enter number of persons");
        int numberOfPerson = int.Parse(Console.ReadLine());
        double[][] personData = new double[numberOfPerson][];
        
        //initialising personData array
        for(int i = 0;i<numberOfPerson;i++)
        {
            personData[i] = new double[3];
        }

        
        for(int i = 0;i<numberOfPerson;i++)
        {

        //calculating BMI
        Console.WriteLine($"Enter Person {i+1}'s weight and height(meters).");
        personData[i][0] = double.Parse(Console.ReadLine()); //to take weights
        personData[i][1] = double.Parse(Console.ReadLine()); //to take heights
        personData[i][2] = personData[i][0]/(personData[i][1]*personData[i][1]);
        //categorising the results.
        if(personData[i][2]<=18.4){
        
        Console.WriteLine($"For this person with height {personData[i][1]} meter ,weight {personData[i][0]},The BMI will be {personData[i][2]} and he is underweight");
        }
        else if(personData[i][2]>18.4 && personData[i][2]<=24.9){
        Console.WriteLine($"For this person with height {personData[i][1]} meter,weight {personData[i][0]},The BMI will be {personData[i][2]} and he is Normal");
        }
        else if(personData[i][2]>24.9 && personData[i][2] <=39.9){
        Console.WriteLine($"For this person with height {personData[i][1]} meter,weight {personData[i][0]},The BMI will be {personData[i][2]} and he is Overweight");
        }
        else{
            Console.WriteLine($"For this person with height {personData[i][1]} meter,weight {personData[i][0]},The BMI will be {personData[i][2]} and he is Obese");
        }

    }
    }
}