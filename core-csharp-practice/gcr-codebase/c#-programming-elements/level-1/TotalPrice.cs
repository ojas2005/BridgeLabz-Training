using System;
class TotalPrice{
    static void Main()
    {
        //taking unitprice and quantity as input from the user.
        float unitPrice = float.Parse(Console.ReadLine());
        int quantity = int.Parse(Console.ReadLine());

        //calculating total price and printing the results.
        float totalPrice = unitPrice*quantity*1f;
        Console.WriteLine($"The total purchase price is INR {totalPrice} if the quantity {quantity} and unit price is INR {unitPrice}");
    }
}