using MyGenes.Domain.Entities;

namespace MyGenes.Domain.Common;
public class FoodFormulaCalculator
{
    public static int CalculateFinalScore(Food food) => 100 - (((int)food.FoodType * 40 * (food.Fat / 5)) +
    food.Carbohydrates - (food.Sugar / 2 * (int)food.FoodType) -
            (food.Cholesterol * food.Carbohydrates) / 10);
}
