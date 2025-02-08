using Microsoft.AspNetCore.Http.HttpResults;
using MyGenes.Application.Foods.Commands.CreateFood;
using MyGenes.Application.Foods.Commands.DeleteFood;
using MyGenes.Application.Foods.Commands.UpdateFood;
using MyGenes.Application.Foods.Queries.GetFood;
using MyGenes.Application.Foods.Queries.GetFoods;

namespace MyGenes.Web.Endpoints;

public class Foods : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetFood, "{id}")
            .MapGet(GetFoods)
            .MapPost(CreateFood)
            .MapPut(UpdateFood, "{id}")
            .MapDelete(DeleteFood, "{id}");
    }

    public async Task<Ok<IReadOnlyCollection<FoodBriefDto>>> GetFoods(ISender sender, [AsParameters] GetFoodsQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Results<Ok<FoodDto>, NotFound>> GetFood(ISender sender, int id)
    {
        var result = await sender.Send(new GetFoodQuery { Id = id });

        if (result == null)
            return TypedResults.NotFound();

        return TypedResults.Ok(result);
    }


    public async Task<Created<int>> CreateFood(ISender sender, CreateFoodCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(Foods)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateFood(ISender sender, int id, UpdateFoodCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteFood(ISender sender, int id)
    {
        await sender.Send(new DeleteFoodCommand(id));

        return TypedResults.NoContent();
    }
}
