using System;
class BankingSystem
{
    static void Main(string[] args)
    {
        Account user1 = new Account(5311607590,Aisha);
        Account user2 = new Account(5471345261,Sunil);
        user1.ShowDetails();
        user2.ShowDetails();
        Account.ShowTotalAccounts();

        if (user1 is Account)
        {
            Console.WriteLine("user1 is object of Account class");
        }
    }
}
public class Account
{
    public static string bankTitle = "Punjab National Bank";
    private static int accountCount = 0;

    protected string holderName;
    private readonly int accountId;
    public Account(int accountId, string holderName)
    {
        this.accountId = accountId;
        this.holderName = holderName;
        accountCount++;
    }
    public static void ShowTotalAccounts()
    {
        Console.WriteLine($"total accounts are {accountCount}");
    }
    public void ShowDetails()
    {
        Console.WriteLine($"name is {holderName}");
        Console.WriteLine($"account number is {accountId}");
        Console.WriteLine($"bank name is {bankTitle}");
    }
}
