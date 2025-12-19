using System;
class DataTypes{
    static void Main()
    {
        //Premetive data types.

        byte b = 120; //stores values 0-255;
        Console.WriteLine(b);

        int a = 10; //stores the integer values,
        Console.WriteLine(a);

        float pi = 3.14f; //stores float values,need to use 'f' after the value.
        Console.WriteLine(pi);
        
        double kiloMeters = 10.123; //it stores larger size values or to store precise values.
        Console.WriteLine(kiloMeters);
        
        char c = 'a'; //To store characters.
        Console.WriteLine(c);
        
        short sh = 15000; //16 bit values can be stored.
        Console.WriteLine(sh);
        
        long l = 100000000L; //can store 64 bit values
        Console.WriteLine(l);
        
        bool flag = true; //Used to represent binary values in conditional logic.
        Console.WriteLine(flag);

        //Type Casting in C# - Implicit Type Casting
        int x = 9;
        double y = x; //it will automatically convert integer into double
        Console.WriteLine(x); //output = 9.
        Console.WriteLine(y); //output = 9.

        //Explicit Type Casting in C#.
        double num = 10.342;
        int value = (int) num;
        Console.WriteLine(num); //output = 10.342
        Console.WriteLine(value); // output = 10.

        //Type Casting Methods in C#.
        int newNum = 23;
        double newValue = 43.2323;
        bool newFlag = true;
        Console.WriteLine(Convert.ToString(newNum)); //int to string conversion.
        Console.WriteLine(Convert.ToDouble(newNum)); //int to double convertion.
        Console.WriteLine(Convert.ToInt32(newValue)); //double to int conversion.
        Console.WriteLine(Convert.ToString(newFlag)); //boolean to string conversion.


    }
}