class Program
{
    static void Main()
    {
        Console.WriteLine("-------Hospital Management System-----------");
        // creating in-patient object
        InPatient inPatient = new InPatient(101, "Rahul Sharma","rahulsharma@gmail.com",38,205,4,1200);
        inPatient.DisplayInfo();
        inPatient.DisplayPaymentInfo();

        // creating out-patient object
        OutPatient outPatient = new OutPatient(102, "Anita Verma","anitaverma@gmail.com",29,600,350);
        outPatient.DisplayInfo();
        outPatient.DisplayPaymentInfo();

        // creating doctor object
        Doctor doctor = new Doctor(201, "Dr. Suresh Kumar","Cardiology","9876543210");
        doctor.DisplayInfo();

        // creating bill objects
        Bill bill1 = new Bill(1001, 101, inPatient.getTotalAmount(),"Paid","23-02-2025");
        bill1.DisplayBillInfo();

        Bill bill2 = new Bill(1002, 102, outPatient.getTotalAmount(),"Pending","28-02-2025");
        bill2.DisplayBillInfo();
        Console.WriteLine();
    }
}
