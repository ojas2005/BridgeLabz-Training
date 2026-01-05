namespace VehicleRentalApp.Models
{
    public abstract class Vehicle : IRentable
    {
        //protected fields for encapsulation
        protected string vehicleId;
        protected string vehicleName;
        protected double dailyRate;
        protected bool isAvailable;
        public Vehicle(string id,string name,double rate)
        {
            vehicleId=id;
            vehicleName=name;
            dailyRate=rate;
            isAvailable=true;
        }
        public string VehicleId
        {
            get
            {
                return vehicleId;
            }
            set
            {
                vehicleId=value;
            }
        }
        public string VehicleName
        {
            get
            {
                return vehicleName;
            }
            set
            {
                vehicleName=value;
            }
        }
        public double DailyRate
        {
            get
            {
                return dailyRate;
            }
            set
            {
                dailyRate=value;
            }
        }
        public bool IsAvailable
        {
            get
            {
                return isAvailable;
            }
            set
            {
                isAvailable=value;
            }
        }
        //method for polymorphism(abstract)
        public abstract double CalculateRent(int days);
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Vehicle id: {vehicleId}");
            Console.WriteLine($"Vehicle name: {vehicleName}");
            Console.WriteLine($"Daily rate:{dailyRate}");
            Console.WriteLine($"available: {isAvailable}");
        }
    }
}
