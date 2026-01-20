class MealPlanValidator<T> where T:IMealPlan
{
    private List<Meal<T>> mealPlan=new List<Meal<T>>();
    
    public bool ValidateAndAddMeal(Meal<T> meal)
    {
        if(meal.Calories>0&&meal.Calories<5000)
        {
            mealPlan.Add(meal);
            Console.WriteLine($"meal validated and added:- {meal.MealName}");
            return true;
        }
        else
        {
            Console.WriteLine($"invalid meal calories:-{meal.Calories}");
            return false;
        }
    }
    
    public void GenerateMealPlan()
    {
        Console.WriteLine("\ngenerated meal plan");
        foreach(Meal<T> meal in mealPlan)
        {
            meal.DisplayMealInfo();
            Console.WriteLine();
        }
        Console.WriteLine($"total meals: {mealPlan.Count}");
        CalculateTotalCalories();
    }
    
    public void CalculateTotalCalories()
    {
        int totalCalories=0;
        foreach(Meal<T> meal in mealPlan)
        {
            totalCalories+=meal.Calories;
        }
        Console.WriteLine($"total daily calories: {totalCalories}kcal\n");
    }
}