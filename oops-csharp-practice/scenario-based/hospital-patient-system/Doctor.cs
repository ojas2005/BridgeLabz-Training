// Doctor class with encapsulation
public class Doctor
{
    private int doctorId;
    private string doctorName;
    private string specialization;
    private string contactNumber;
    public int DoctorId
    {
        get
        {
            return doctorId;
        }
        set
        {
            doctorId=value;
        }
    }

    public string DoctorName
    {
        get
        {
            return doctorName;
        }
        set
        {
            doctorName=value;
        }
    }

    public string Specialization
    {
        get
        {
            return specialization;
        }
        set
        {
            specialization=value;
        }
    }

    public string ContactNumber
    {
        get
        {
            return contactNumber;
        }
        set
        {
            contactNumber=value;
        }
    }

    //Constructor
    public Doctor(int id,string name,string special,string contact)
    {
        doctorId=id;
        doctorName=name;
        specialization=special;
        contactNumber=contact;
    }

    //Display method to display doctor information.
    public void DisplayInfo()
    {
        Console.WriteLine("Doctor Info");
        Console.WriteLine($"Doctor ID is {doctorId}");
        Console.WriteLine($"Doctor Name is {doctorName}");
        Console.WriteLine($"Specialist in {specialization} ");
        Console.WriteLine($"Contact Number:- {contactNumber}");
        Console.WriteLine("");
    }
}
