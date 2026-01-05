// Base class Patient with encapsulation
public class Patient : IPayable
{
    //for encapsulation we will be creating private fields with public properties
    private int patientId;
    private string patientName;
    private string patientEmail;
    private int patientAge;
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
    public string PatientName
    {
        get
        {
            return patientName;
        }
        set
        {
            patientName=value;
        }
    }
    public string PatientEmail
    {
        get
        {
            return patientEmail;
        }
        set
        {
            patientEmail=value;
        }
    }
    public int PatientAge
    {
        get
        {
            return patientAge;
        }
        set
        {
            patientAge=value;
        }
    }
    //creating a constructor
    public Patient(int id,string name,string email,int age)
    {
        patientId=id;
        patientName=name;
        patientEmail=email;
        patientAge=age;
    }
    //polymorphism(using virtual method)
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Patient Information");
        Console.WriteLine($"Patient id: {patientId}");
        Console.WriteLine($"Patient name: {patientName}");
        Console.WriteLine($"Patient email: {patientEmail}");
        Console.WriteLine($"Patient age: {patientAge}");
    }
    //interface implementation
    public virtual void DisplayPaymentInfo()
    {
        Console.WriteLine($"Payment Information for Patient: {patientName}" );
    }
    public virtual decimal getTotalAmount()
    {
        return 0;
    }
}
