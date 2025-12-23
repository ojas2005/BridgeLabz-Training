using System;

class Calculator {
    static void Main(String[] args) {

        // taking two numbers and operator from thr user
        double first = double.Parse(Console.ReadLine());
        double second = double.Parse(Console.ReadLine());
        string op = Console.ReadLine();
        //performing the operations
        switch (op){
            case "+":
                Console.WriteLine(first+ second);
                break;

            case "-":
                Console.WriteLine(first- second);
                break;

            case "*":
                Console.WriteLine(first* second);
                break;

            case "/":
                Console.WriteLine(first/ second);
                break;
            default:
                Console.WriteLine("Invalid opareter");
                break;
        }
    }
}