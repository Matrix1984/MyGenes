using MyGenes.Application.Foods.Commands.CreateFood;
using MyGenes.Application.Foods.Commands.DeleteFood;
using MyGenes.Domain.Entities;

namespace MyGenes.Application.FunctionalTests.Foods.Commands;

using static Testing;
public class DeleteFoodTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidFoodId()
    {
        var command = new DeleteFoodCommand(1);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var itemId = await SendAsync(new CreateFoodCommand
        {
            Name = "Test Food",
            ImageUrl = "https://example.com/1.png",
            FoodType = 3,
            Fat = 1,
            Carbohydrates = 2,
            Sugar = 3,
            Cholesterol = 4
        });

        await SendAsync(new DeleteFoodCommand(itemId));

        var item = await FindAsync<Food>(itemId);

        item.Should().BeNull();
    }
}
