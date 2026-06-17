using System;

namespace FitTracker
{
    public class Menu
    {
        public static void ShowMainMenu()
        {
            Console.WriteLine("fitness tracker menu");
            Console.WriteLine("press 1 to add cardio workout");
            Console.WriteLine("press 2 to add strength workout");
            Console.WriteLine("press 3 to view all workouts");
            Console.WriteLine("press 4 to view user profile");
            Console.WriteLine("press 5 to view calorie summary");
            Console.WriteLine("press 6 to exit");
            Console.WriteLine(" ");
        }

        public static void AddCardioWorkoutMenu(UserProfile user)
        {
            Console.WriteLine("enter workout type (running/cycling/swimming)");
            string type = Console.ReadLine();
            Console.WriteLine("enter duration of workout in minutes");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("enter calories burned");
            int calories = int.Parse(Console.ReadLine());
            Console.WriteLine("enter date");
            string date = Console.ReadLine();
            Console.WriteLine("enter distance in km");
            int distance = int.Parse(Console.ReadLine());
            Console.WriteLine("enter intensity(low/medium/high)");
            string intensity = Console.ReadLine();
            CardioWorkout cardio = new CardioWorkout(type,duration,calories,date,distance,intensity);
            WorkoutUtility.AddWorkout(user, cardio);
            cardio.Track();
        }

        public static void AddStrengthWorkoutMenu(UserProfile user)
        {
            Console.WriteLine("enter workout type");
            string type = Console.ReadLine();
            Console.WriteLine("enter exercise name");
            string exercise = Console.ReadLine();
            Console.WriteLine("enter number of sets");
            int sets = int.Parse(Console.ReadLine());
            Console.WriteLine("enter number of reps");
            int reps = int.Parse(Console.ReadLine());
            Console.WriteLine("enter duration in minutes");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("enter calories burned");
            int calories = int.Parse(Console.ReadLine());
            Console.WriteLine("enter date");
            string date = Console.ReadLine();
            StrengthWorkout strength = new StrengthWorkout(type,duration,calories,date,exercise,sets,reps);
            WorkoutUtility.AddWorkout(user, strength);
            strength.Track();
        }
    }
}
