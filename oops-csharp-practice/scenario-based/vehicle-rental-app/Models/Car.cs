namespace VehicleRentalApp.Models
{
    public class Car : Vehicle
    {
        private int seatingCapacity;
        private string fuelType;
        public Car(string id,string name,double rate,int seats,string fuel) : base(id,name,rate)
        {
            seatingCapacity=seats;
            fuelType=fuel;
        }
        public int SeatingCapacity
        {
            get
            {
                return seatingCapacity;
            }
            set
            {
                seatingCapacity=value;
            }
        }
        public string FuelType
        {
            get
            {
                return fuelType;
            }
            set
            {
                fuelType=value;
            }
        }
        public override double CalculateRent(int days)
        {
            double totalRent=dailyRate*days;
            
            if (days>3)
            {
                totalRent=totalRent*0.85; //15% discount for more than 3 days
            }
            
            return totalRent;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Seating Capacity: {seatingCapacity} persons");
            Console.WriteLine($"Fuel Type: {fuelType}");
        }
    }
}
