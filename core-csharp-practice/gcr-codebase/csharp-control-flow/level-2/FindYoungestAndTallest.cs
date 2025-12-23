using System;
class FindYoungestAndTallest{
    static void Main()
    {
        //taking ages and heights as input.
        int ageAmar = int.Parse(Console.ReadLine());
        int ageAkbar = int.Parse(Console.ReadLine());
        int ageAnthony = int.Parse(Console.ReadLine());
        int heightAmar = int.Parse(Console.ReadLine());
        int heightAkbar = int.Parse(Console.ReadLine());
        int heightAnthony = int.Parse(Console.ReadLine());

        //finding the youngest of three.
        if(ageAmar<ageAkbar && ageAmar<ageAnthony){
        Console.WriteLine($"The youngest between Amar,Akbar,Anthony is Amar");
        }
        else if(ageAmar>ageAkbar && ageAkbar<ageAnthony){
        Console.WriteLine($"The youngest between Amar,Akbar,Anthony is Akbar");
        }
        else{
            Console.WriteLine($"The youngest between Amar,Akbar,Anthony is Anthony");
        }

        //finding the tallest of three

        if(heightAmar>heightAkbar && heightAmar>heightAnthony){
        Console.WriteLine($"The tallest between Amar,Akbar,Anthony is Amar");
        }
        else if(heightAmar<heightAkbar && heightAkbar>heightAnthony){
        Console.WriteLine($"The tallest between Amar,Akbar,Anthony is Akbar");
        }
        else{
        Console.WriteLine($"The tallest between Amar,Akbar,Anthony is Anthony");
        }


    }
}