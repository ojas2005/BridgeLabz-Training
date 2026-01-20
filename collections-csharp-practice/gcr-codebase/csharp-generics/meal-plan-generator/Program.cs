using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        MealPlanValidator<VegetarianMeal> vegPlan=new MealPlanValidator<VegetarianMeal>();
        
        vegPlan.ValidateAndAddMeal(new Meal<VegetarianMeal>("green salad",new VegetarianMeal(),350));
        vegPlan.ValidateAndAddMeal(new Meal<VegetarianMeal>("milkshake",new VegetarianMeal(),280));
        vegPlan.ValidateAndAddMeal(new Meal<VegetarianMeal>("tomato soup",new VegetarianMeal(),220));
        vegPlan.GenerateMealPlan();
        
        MealPlanValidator<VeganMeal> veganPlan=new MealPlanValidator<VeganMeal>();
        
        veganPlan.ValidateAndAddMeal(new Meal<VeganMeal>("green salad with ketchup",new VeganMeal(),400));
        veganPlan.ValidateAndAddMeal(new Meal<VeganMeal>("vegan Pasta",new VeganMeal(),450));
        veganPlan.GenerateMealPlan();
        
        MealPlanValidator<KetoMeal> ketoPlan=new MealPlanValidator<KetoMeal>();
        
        ketoPlan.ValidateAndAddMeal(new Meal<KetoMeal>("grilled salmon",new KetoMeal(),600));
        ketoPlan.ValidateAndAddMeal(new Meal<KetoMeal>("bacon eggs",new KetoMeal(),500));
        ketoPlan.GenerateMealPlan();
        
        MealPlanValidator<HighProteinMeal> proteinPlan=new MealPlanValidator<HighProteinMeal>();
        
        proteinPlan.ValidateAndAddMeal(new Meal<HighProteinMeal>("chicken breast",new HighProteinMeal(),550));
        proteinPlan.ValidateAndAddMeal(new Meal<HighProteinMeal>("protein bar",new HighProteinMeal(),250));
        proteinPlan.GenerateMealPlan();
    }
}
