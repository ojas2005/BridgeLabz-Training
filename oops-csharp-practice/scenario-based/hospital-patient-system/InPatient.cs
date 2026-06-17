//creating a child InPatient class from parent Patient class
public class InPatient : Patient
{
    private int roomNumber;
    private int noOfDays;
    private decimal amountPerDay;

    public int RoomNumber
    {
        get
        {
            return roomNumber;
        }
        set
        {
            roomNumber = value;
        }
    }

    public int NoOfDays
    {
        get
        {
            return noOfDays;
        }
        set
        {
            noOfDays = value;
        }
    }

    public decimal AmountPerDay
    {
        get
        {
            return amountPerDay;
        }
        set
        {
            amountPerDay = value;
        }
    }

    // Constructor
    public InPatient(int id, string name, string email, int age, int room, int days, decimal perDay)
        : base(id, name, email, age)
    {
        roomNumber = room;
        noOfDays = days;
        amountPerDay = perDay;
    }
    //display info(in-patient)
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Patient type: in patient");
        Console.WriteLine($"Room Number: {roomNumber}");
        Console.WriteLine($"Number of Days: {noOfDays}");
        Console.WriteLine($"Amount Per Day: Rs. {amountPerDay}");
        Console.WriteLine("");
    }
    //calculate total amount
    public override decimal getTotalAmount()
    {
        decimal totalAmount = noOfDays * amountPerDay;
        return totalAmount;
    }
    //display payment details
    public override void DisplayPaymentInfo()
    {
        Console.WriteLine("Payment info(in-patient)");
        Console.WriteLine($"Total Days: {noOfDays}");
        Console.WriteLine($"Amount Per Day: Rs. {amountPerDay}");
        Console.WriteLine($"Total Amount: Rs. {getTotalAmount()}");
        Console.WriteLine("");
    }
}
