class VeganMeal:IMealPlan
{
    public string GetMealType()
    {
        return "vegan";
    }
    
    public string GetNutritionInfo()
    {
        return "plant based meal, no animal products";
    }
}