using MyGenes.Application.Foods.Commands.CreateFood;
using MyGenes.Application.Foods.Commands.UpdateFood;
using MyGenes.Domain.Entities;

namespace MyGenes.Application.FunctionalTests.Foods.Commands;

using static Testing;
public class UpdateFoodTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidFoodId()
    {
        var command = new UpdateFoodCommand
        {
            Name = "Test Food",
            ImageUrl = "https://example.com/1.png",
            FoodType = 3,
            Fat = 1,
            Carbohydrates = 2,
            Sugar = 3,
            Cholesterol = 4
        };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateFood()
    {
        var foodId = await SendAsync(new CreateFoodCommand
        {
           
            Name = "Test Food",
            ImageUrl = "https://example.com/1.png",
            FoodType = 3,
            Fat = 1,
            Carbohydrates = 2,
            Sugar = 3,
            Cholesterol = 4
        });


        var command = new UpdateFoodCommand
        {
            Id = foodId,
            Name = "Test Food Updated",
            ImageUrl = "https://example.com/1-updated.png",
            FoodType = 2,
            Fat = 5,
            Carbohydrates = 6,
            Sugar = 7,
            Cholesterol = 8
        };

        await SendAsync(command);

        var item = await FindAsync<Food>(foodId);

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
