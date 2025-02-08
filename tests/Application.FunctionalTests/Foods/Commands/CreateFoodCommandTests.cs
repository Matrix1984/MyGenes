using System.ComponentModel.DataAnnotations;
using MyGenes.Application.Foods.Commands.CreateFood;
using MyGenes.Domain.Entities;

namespace MyGenes.Application.FunctionalTests.Foods.Commands;

using static Testing;
public class CreateFoodCommandTests : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateFood()
    {
        var command = new CreateFoodCommand
        {
            Name = "Test Food",
            ImageUrl = "https://example.com/1.png",
            FoodType = 3,
            Fat = 1,
            Carbohydrates = 2,
            Sugar = 3,
            Cholesterol = 4
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<Food>(itemId);

        item.Should().NotBeNull();

        item!.Name.Should().Be(command.Name);
        item.ImageUrl.Should().Be(command.ImageUrl);
        item.FoodType.Should().Be((Domain.Enums.FoodType)command.FoodType);
        item.Fat.Should().Be(command.Fat);
        item.Carbohydrates.Should().Be(command.Carbohydrates);
        item.Sugar.Should().Be(command.Sugar);
        item.Cholesterol.Should().Be(command.Cholesterol);
    }
}


