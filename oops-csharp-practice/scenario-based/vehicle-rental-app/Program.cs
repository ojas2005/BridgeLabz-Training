using VehicleRentalApp.Models;

class Program
{
    static void Main()
    {
        Console.WriteLine("Vehicle Rental Application\n");
        // create customers
        Customer cust1=new Customer("C001","Rohit Sharma","9876543210","rohit@gmail.com");
        Customer cust2=new Customer("C002","Neha Verma","9123456789","neha@gmail.com");

        // creating vehicles
        Bike bike=new Bike("B001","Royal Enfield",50,350);
        Car car=new Car("CAR001","Maruti Swift",100,5,"Petrol");
        Truck truck=new Truck("T001","Tata Truck",200,25);

        //displaying customer info
        cust1.DisplayInfo();
        cust2.DisplayInfo();

        //displaying vehicle info
        bike.DisplayInfo();
        car.DisplayInfo();
        truck.DisplayInfo();

        //calculating rents
        int days=5;
        Console.WriteLine("\nRental Amount:");
        Console.WriteLine($"bike : {bike.CalculateRent(days)}");
        Console.WriteLine($"car  : {car.CalculateRent(days)}");
        Console.WriteLine($"truck: {truck.CalculateRent(days)}");

        //short rental
        int shortDays=2;
        Console.WriteLine("\nShort Rental:");
        Console.WriteLine($"bike : {bike.CalculateRent(shortDays)}");
        Console.WriteLine($"car  : {car.CalculateRent(shortDays)}");
        Console.WriteLine($"truck: {truck.CalculateRent(shortDays)}");
    }
}
