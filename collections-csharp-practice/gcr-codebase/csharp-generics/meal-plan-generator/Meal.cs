class Meal<T> where T:IMealPlan
{
    public string MealName;
    public T MealType;
    public int Calories;
    
    public Meal(string mealName,T mealType,int calories)
    {
        MealName=mealName;
        MealType=mealType;
        Calories=calories;
    }
    
    public void DisplayMealInfo()
    {
        Console.WriteLine($"meal:- {MealName},type:- {MealType.GetMealType()},calories: {Calories}kcal");
        Console.WriteLine($"nutrition:- {MealType.GetNutritionInfo()}");
    }
}
