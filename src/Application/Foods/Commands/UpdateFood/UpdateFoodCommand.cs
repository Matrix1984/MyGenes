﻿using MyGenes.Application.Common.Interfaces;

namespace MyGenes.Application.Foods.Commands.UpdateFood;

public record UpdateFoodCommand : IRequest
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public string? ImageUrl { get; init; }

    public int FoodType { get; init; }

    // Number between 0 to 99.
    public int Fat { get; init; }

    // Number between 0 to 99.
    public int Carbohydrates { get; init; }

    // Number between 0 to 99.
    public int Sugar { get; init; }

    // Number between 0 to 1.
    public int Cholesterol { get; init; }
    public int FinalScore
    {
        get
        {
            return 100 - (((int)FoodType * 40 * (Fat / 5)) +
             Carbohydrates - (Sugar / 2 * (int)FoodType) -
            (Cholesterol * Carbohydrates) / 10);
        }
    }
}

public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateFoodCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Foods
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        entity.ImageUrl = request.ImageUrl;

        entity.FoodType = (Domain.Enums.FoodType)request.FoodType;

        entity.ImageUrl = request.ImageUrl;

        entity.Fat = request.Fat;

        entity.ImageUrl = request.ImageUrl;

        entity.Carbohydrates = request.Carbohydrates;

        entity.Sugar = request.Sugar;

        entity.Cholesterol = request.Cholesterol;

        entity.FinalScore = request.FinalScore;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
