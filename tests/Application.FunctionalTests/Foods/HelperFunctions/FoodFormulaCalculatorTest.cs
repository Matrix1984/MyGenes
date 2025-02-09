using MyGenes.Domain.Common;
using MyGenes.Domain.Entities;

namespace MyGenes.Application.FunctionalTests.Foods.HelperFunctions;
public class FoodFormulaCalculatorTest
{
    [Test]
    public void GiveCalculation()
    {
        var food = new Food()
        {
            Name = "Test Food",
            ImageUrl = "https://example.com/1.png",
            FoodType = (Domain.Enums.FoodType)3,
            Fat = 1,
            Carbohydrates = 2,
            Sugar = 3,
            Cholesterol = 4
        };

        var result = FoodFormulaCalculator.CalculateFinalScore(food);

        result!.Should().BeGreaterThan(0);
    }
}
