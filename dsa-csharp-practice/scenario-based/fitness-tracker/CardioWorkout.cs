namespace FitTracker
{
    public class CardioWorkout : Workout
    {
        public int distance;
        public string intensity;
        public CardioWorkout(string type, int duration, int calories, string date, int distance, string intensity)
            : base(type, duration, calories, date)
        {
            this.distance = distance;
            this.intensity = intensity;
        }
        public override void Track()
        {
            Console.WriteLine($"tracking cardio workout: {type}");
        }
        public override void Display()
        {
            Console.WriteLine($"type: {type}");
            Console.WriteLine($"duration: {duration} minutes");
            Console.WriteLine($"distance:{distance} km");
            Console.WriteLine($"intensity: {intensity}");
            Console.WriteLine($"calories: {calories}");
            Console.WriteLine($"date: {date}");
        }
    }
}
