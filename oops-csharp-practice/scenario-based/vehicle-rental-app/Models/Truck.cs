namespace VehicleRentalApp.Models
{
    public class Truck : Vehicle
    {
        private double cargoCapacityTons;

        public Truck(string id,string name,double rate,double cargo) : base(id,name,rate)
        {
            cargoCapacityTons=cargo;
        }

        public double CargoCapacity
        {
            get
            {
                return cargoCapacityTons;
            }
            set
            {
                cargoCapacityTons=value;
            }
        }
        public override double CalculateRent(int days)
        {
            double totalRent=dailyRate * days;
            
            if (days>2)
            {
                totalRent=totalRent*0.8; //20% discount for more than 2 days
            }
           return totalRent;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Truck capacity is {cargoCapacityTons} tons");
        }
    }
}
