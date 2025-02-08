using MyGenes.Application.Foods.Queries.GetFoods;
using MyGenes.Domain.Entities;

namespace MyGenes.Application.FunctionalTests.Foods.Queries;

using static Testing;
public class GetFoodsTests : BaseTestFixture
{
    [Test]
    public async Task ShouldFoodByRange()
    {
        await AddAsync(new Food
        {
            Name = "Test Food 1",
            ImageUrl = "https://example.com/1.png",
            FoodType = (Domain.Enums.FoodType)3,
            Fat = 1,
            Carbohydrates = 2,
            Sugar = 3,
            Cholesterol = 4

        });

        await AddAsync(new Food
        {
            Name = "Test Food 2",
            ImageUrl = "https://example.com/1.png",
            FoodType = (Domain.Enums.FoodType)1,
            Fat = 2,
            Carbohydrates = 3,
            Sugar = 4,
            Cholesterol = 5

        });

        await AddAsync(new Food
        {
            Name = "Test Food 3",
            ImageUrl = "https://example.com/1.png",
            FoodType = (Domain.Enums.FoodType)2,
            Fat = 6,
            Carbohydrates = 700,
            Sugar = 800,
            Cholesterol = 900

        });

        await AddAsync(new Food
        {
            Name = "Test Food 4",
            ImageUrl = "https://example.com/1.png",
            FoodType = (Domain.Enums.FoodType)3,
            Fat = 10,
            Carbohydrates = 110,
            Sugar = 120,
            Cholesterol = 130

        });

        var query = new GetFoodsQuery() { MinScore = 50, MaxScore = 2000 };

        var result = await SendAsync(query);

        result.Should().HaveCount(2);
    }


    [Test]
    public async Task ShouldFoodByFoodType()
    {
        await AddAsync(new Food
        {
            Name = "Test Food 1",
            ImageUrl = "https://example.com/1.png",
            FoodType = (Domain.Enums.FoodType)3,
            Fat = 1,
            Carbohydrates = 2,
            Sugar = 3,
            Cholesterol = 4

        });

        await AddAsync(new Food
        {
            Name = "Test Food 2",
            ImageUrl = "https://example.com/1.png",
            FoodType = (Domain.Enums.FoodType)1,
            Fat = 2,
            Carbohydrates = 3,
            Sugar = 4,
            Cholesterol = 5

        });

        await AddAsync(new Food
        {
            Name = "Test Food 3",
            ImageUrl = "https://example.com/1.png",
            FoodType = (Domain.Enums.FoodType)2,
            Fat = 6,
            Carbohydrates = 700,
            Sugar = 800,
            Cholesterol = 900

        });

        await AddAsync(new Food
        {
            Name = "Test Food 4",
            ImageUrl = "https://example.com/1.png",
            FoodType = (Domain.Enums.FoodType)3,
            Fat = 10,
            Carbohydrates = 110,
            Sugar = 120,
            Cholesterol = 130

        }); 

        var query = new GetFoodsQuery() { FoodType = 2 };

        var result = await SendAsync(query);

        result.Should().HaveCount(2);
    }

}

