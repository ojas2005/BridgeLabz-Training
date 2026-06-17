using System;
class CalculateBMI{
    static void CalculateBMIFunction(double[,] data){
        for (int i=0;i<10;i++){
            double weight=data[i,0];           
            double heightCm=data[i,1];    
            double heightM=heightCm/100;      
            data[i,2]=weight/(heightM*heightM);
        }
    }
    static string[] BMIStatus(double[,] data){
        string[] status=new string[10];

        for(int i=0;i<10;i++){
            double bmi=data[i,2];
            if(bmi<18.5) status[i]="Underweight";
            else if(bmi<25) status[i]="Normal";
            else if(bmi<30) status[i]="Overweight";
            else status[i]="Obese";
        }
        return status;
    }

    static void Main(){
        double[,] persons=new double[10, 3];
        for (int i=0;i<10;i++){
            Console.WriteLine($"Enter details of Person {i + 1}");
            Console.Write("Weight (kg): ");
            persons[i,0] = double.Parse(Console.ReadLine());
            Console.Write("Height (cm): ");
            persons[i,1] = double.Parse(Console.ReadLine());
        }
        CalculateBMI(persons);
        string[] status=BMIStatus(persons);
        for (int i=0;i<10;i++){
            Console.WriteLine($"{persons[i,0]} {persons[i,1]} {persons[i,2]} {status[i]}");
        }
    }
}
