using System;

public class ConsoleUtility : IConsoleUtility
{
    public void DisplayMenu()
    {
        Console.WriteLine("\npress 1 to add adhar number");
        Console.WriteLine("press 2 to display all numbers");
        Console.WriteLine("press 3 to sort numbers (in ascending order)");
        Console.WriteLine("press 4 to sort numbers (Stable)");
        Console.WriteLine("press 5 to search Aadhar Number");
        Console.WriteLine("press 6 to display sorted numbers");
        Console.WriteLine("press 7 to load sample data");
        Console.WriteLine("press 8 to exit");
    }

    public void AddNewNumber(AadharManager manager)
    {
        Console.Write("enter 12 digit aadhar number: ");
        string number = Console.ReadLine();

        if(ValidateAadhar(number))
            manager.AddAadharNumber(number);
        else
            Console.WriteLine("enter a valid adhar number");
    }

    public void SearchAadhar(AadharManager manager)
    {
        Console.Write("enter adhar number to search:");
        string number = Console.ReadLine();

        if(ValidateAadhar(number))
            manager.SearchNumber(number);
        else
            Console.WriteLine("enter a valid adhar number");
    }

    public void LoadSampleData(AadharManager manager)
    {
        string[] sampleData =
        {
            "123456789012",
            "987654321098",
            "456789123456",
            "123456789010",
            "789123456789",
            "123456789011",
            "654321987654",
            "123456789009"
        };

        foreach (string num in sampleData)
            manager.AddAadharNumber(num);

        Console.WriteLine("Sample data loaded.");
    }

    private bool ValidateAadhar(string number)
    {
        if(number == null || number.Length != 12)
            return false;

        foreach (char c in number)
            if(!char.IsDigit(c))
                return false;

        return true;
    }
}
