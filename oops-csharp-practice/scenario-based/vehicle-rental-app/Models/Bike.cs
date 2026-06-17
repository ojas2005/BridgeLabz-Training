namespace VehicleRentalApp.Models
{
    public class Bike : Vehicle
    {
        private int engineCC;

        public Bike(string id,string name,double rate,int cc) : base(id,name,rate)
        {
            engineCC=cc;
        }

        public int EngineCC
        {
            get
            {
                return engineCC;
            }
            set
            {
                engineCC=value;
            }
        }

        // bike has lower discount on days
        public override double CalculateRent(int days)
        {
            double totalRent=dailyRate*days;
            if (days>5)
            {
                totalRent=totalRent*0.9;
            }
            return totalRent;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Engine CC: {engineCC}cc");
        }
    }
}
