using System;
class YoungestAndTallest{
    static void Main()
    {
        //taking ages and heights as input.
        int numberOfPerson=3;
        int[] age = new int[3];
        int[] height = new int[3];

        for(int i = 0;i<numberOfPerson;i++)
        {
            Console.WriteLine($"Enter age and height for person {i+1}");
            age[i] = int.Parse(Console.ReadLine());
            height[i] = int.Parse(Console.ReadLine());
        }

        //finding the youngest of three.
        if(age[0]<age[1] && age[0]<age[2]){
        Console.WriteLine($"The youngest between Amar,Akbar,Anthony is Amar");
        }
        else if(age[0]>age[1] && age[1]<age[2]){
        Console.WriteLine($"The youngest between Amar,Akbar,Anthony is Akbar");
        }
        else{
            Console.WriteLine($"The youngest between Amar,Akbar,Anthony is Anthony");
        }

        //finding the tallest of three

        if(height[0]>height[1] && height[0]>height[2]){
        Console.WriteLine($"The tallest between Amar,Akbar,Anthony is Amar");
        }
        else if(height[0]<height[1] && height[1]>height[2]){
        Console.WriteLine($"The tallest between Amar,Akbar,Anthony is Akbar");
        }
        else{
        Console.WriteLine($"The tallest between Amar,Akbar,Anthony is Anthony");
        }


    }
}