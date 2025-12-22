using System;
class ChocolateDistribution{
    static void Main()
    {
        //taing number of chocolates and number of children as input.
        int numberOfChocolates = int.Parse(Console.ReadLine());
        int numberOfChildrens = int.Parse(Console.ReadLine());

        //Calculating numbers of chocolates which will be remaining after distributing pens equally.
        int remainingAfterDistribution = numberOfChocolates%numberOfChildrens;

        //calculating how many chocolates each children will get.
        int chocolatesPerChildren = (numberOfChocolates-remainingAfterDistribution)/numberOfChildrens;
        Console.WriteLine($"The number of chocolates each child gets is {chocolatesPerChildren} and the number of remaining chocolates is {remainingAfterDistribution}");
    }
}