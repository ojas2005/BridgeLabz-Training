// Derived class OutPatient
public class OutPatient : Patient
{
    private int consultationFee;
    private int labTestFee;
    public int ConsultationFee
    {
        get
        {
            return consultationFee;
        }
        set
        {
            consultationFee=value;
        }
    }
    public int LabTestFee
    {
        get
        {
            return labTestFee;
        }
        set
        {
            labTestFee=value;
        }
    }

    //Constructor
    public OutPatient(int id,string name,string email,int age,int consultation,int labTest)
        : base(id,name,email,age)
    {
        consultationFee=consultation;
        labTestFee=labTest;
    }

    //using polymorphism concept on display info
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Patient Type: Out-Patient");
        Console.WriteLine($"Consultation Fee: {consultationFee}rs");
        Console.WriteLine($"Lab Test Fee: {labTestFee}rs");
        Console.WriteLine("");
    }
    // Calculate total amount
    public override decimal getTotalAmount()
    {
        decimal totalAmount=consultationFee+labTestFee;
        return totalAmount;
    }
    // Display payment details
    public override void DisplayPaymentInfo()
    {
        Console.WriteLine("Payment details(out patient)");
        Console.WriteLine($"Consultation Fee: {consultationFee}rs");
        Console.WriteLine($"Lab Test Fee: {labTestFee}rs");
        Console.WriteLine($"Total Amount: {getTotalAmount()}rs");
        Console.WriteLine("");
    }

}
