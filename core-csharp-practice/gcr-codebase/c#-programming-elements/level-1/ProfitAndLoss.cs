using System;
class ProfitAndLoss{
    static void Main(){
        //taking cost price and selling price values
    int costPrice = 129;
    int sellingPrice = 191;
    //calculating the profit in amount and in percentage
    int profit  = sellingPrice-costPrice;
    float profitPercentage = (profit*100f)/costPrice;

    //Printing the results.
    Console.WriteLine($@"The Cost Price is INR {costPrice} and Selling Price is INR {sellingPrice}.
The Profit is INR {profit} and the Profit Percentage is {profitPercentage}");
    }
    }