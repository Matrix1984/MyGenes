using MyGenes.Application.Foods.Commands.CreateFood;
using MyGenes.Application.Foods.Queries.GetFood;
using MyGenes.Domain.Entities;

namespace MyGenes.Application.FunctionalTests.Foods.Queries;

using static Testing;
public class GetFoodTests : BaseTestFixture
{
    [Test]
    public async Task ShouldFoodById()
    {
       var command = new CreateFoodCommand
        {
            Name = "Test Food",
            ImageUrl = "https://example.com/1.png",
            FoodType = 3,
            Fat = 1,
            Carbohydrates = 2,
            Sugar = 3,
            Cholesterol = 1
        };

        var itemId = await SendAsync(command);

        var query = new GetFoodQuery() { Id = itemId };
         
        var result = await SendAsync(query);

        result.Should().NotBeNull();
    }

}
