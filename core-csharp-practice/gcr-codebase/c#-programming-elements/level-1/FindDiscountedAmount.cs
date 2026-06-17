using System;
class FindDiscountedAmount{
    static void Main()
    {
        //taking fee and discount values.
        int fee = 125000;
        int discountPercent = 10;
        //calculating the discount amount and final amount of fee to pay.
        float discount = fee/discountPercent;
        float feeToPay = fee-discount;

        //Printing the results.
        Console.WriteLine($"The discount amount is INR {discount} and final discounted fee is INR {feeToPay}");
    }
}