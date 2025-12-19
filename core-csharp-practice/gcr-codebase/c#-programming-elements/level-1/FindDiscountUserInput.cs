using System;
class FindDiscountedAmount{
    static void Main()
    {
        //taking fee and discount values from user.
        int fee = int.Parse(Console.ReadLine());
        int discountPercent = int.Parse(Console.ReadLine());

        //calculating the discount amount and final amount of fee to pay.
        float discount = fee/discountPercent;
        float feeToPay = fee-discount;
        //printing results.
        Console.WriteLine($"The discount amount is INR {discount} and final discounted fee is INR {feeToPay}");
    }
}