using System;
class CalculateBMINormal{
    static void Main()
    {

        //initialising arrays.
        int numberOfPerson = int.Parse(Console.ReadLine());
        double[] weight = new double[numberOfPerson];
        double[] height = new double[numberOfPerson];
        double[] bmi = new double[numberOfPerson];

        //taking weight and height as input.
        for(int i = 0;i<numberOfPerson;i++)
        {
            weight[i] = double.Parse(Console.ReadLine()); //weights
            height[i] = double.Parse(Console.ReadLine()); //heights

        //calculating BMI
        bmi[i] = weight[i]/(height[i] *height[i]);
       
            //categorising the results.
        if(bmi[i]<=18.4){
        
        Console.WriteLine($"For this person with height {height[i]} meter ,weight {weight[i]},The BMI will be {bmi[i]} and he is underweight");
        }
        else if(bmi[i]>18.4 && bmi[i]<=24.9){
        Console.WriteLine($"For this person with height {height[i]} meter,weight {weight[i]},The BMI will be {bmi[i]} and he is Normal");
        }
        else if(bmi[i]>24.9 && bmi[i] <=39.9){
        Console.WriteLine($"For this person with height {height[i]} meter,weight {weight[i]},The BMI will be {bmi[i]} and he is Overweight");
        }
        else{
            Console.WriteLine($"For this person with height {height[i]} meter,weight {weight[i]},The BMI will be {bmi[i]} and he is Obese");
        }

    }
    }
}
