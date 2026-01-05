public class Bill
{
    private int billId;
    private int patientId;
    private decimal billAmount;
    private string billStatus;
    private string billDate;
    
    public int BillId
    {
        get
        {
            return billId;
        }
        set
        {
            billId=value;
        }
    }

    public int PatientId
    {
        get
        {
            return patientId;
        }
        set
        {
            patientId=value;
        }
    }

    public decimal BillAmount
    {
        get
        {
            return billAmount;
        }
        set
        {
            billAmount=value;
        }
    }

    public string BillStatus
    {
        get
        {
            return billStatus;
        }
        set
        {
            billStatus=value;
        }
    }

    public string BillDate
    {
        get
        {
            return billDate;
        }
        set
        {
            billDate=value;
        }
    }

    // Constructor
    public Bill(int id,int pId,decimal amount,string status,string date)
    {
        billId=id;
        patientId=pId;
        billAmount=amount;
        billStatus=status;
        billDate=date;
    }

// Display bill information
public void DisplayBillInfo()
{
    Console.WriteLine("Patient Bill");
    Console.WriteLine($"Bill id: {billId}");
    Console.WriteLine($"Patient id: {patientId}");
    Console.WriteLine($"Amount: {billAmount}rs");
    Console.WriteLine($"Bill status:{billStatus}");
    Console.WriteLine($"Bill date: {billDate}");
    Console.WriteLine("");
}

}
