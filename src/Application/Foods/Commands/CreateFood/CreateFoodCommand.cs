using MyGenes.Application.Common.Interfaces;
using MyGenes.Domain.Common;
using MyGenes.Domain.Entities;
using MyGenes.Domain.Enums;

namespace MyGenes.Application.Foods.Commands.CreateFood;
public record CreateFoodCommand : IRequest<int>
{
    public required string Name { get; init; }

    public string? ImageUrl { get; init; }

    // Number between 1 to 3.
    public int FoodType { get; init; }

    // Number between 0 to 99.
    public int Fat { get; init; }

    // Number between 0 to 99.
    public int Carbohydrates { get; init; }

    // Number between 0 to 99.
    public int Sugar { get; init; }

    // Number between 0 to 1.
    public int Cholesterol { get; init; }
}

public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFoodCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
    {
        var entity = new Food
        {
            Name = request.Name,
            ImageUrl = request.ImageUrl,
            FoodType = (FoodType)request.FoodType,
            Fat = request.Fat,
            Carbohydrates = request.Carbohydrates,
            Sugar = request.Sugar,
            Cholesterol = request.Cholesterol
        };

        entity.FinalScore = FoodFormulaCalculator.CalculateFinalScore(entity);

        _context.Foods.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}


