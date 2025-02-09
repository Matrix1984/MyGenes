namespace MyGenes.Application.Foods.Commands.UpdateFood;

public class UpdateFoodCommandValidator : AbstractValidator<UpdateFoodCommand>
{
    public UpdateFoodCommandValidator()
    {
        RuleFor(v => v.FoodType).GreaterThanOrEqualTo(1).LessThanOrEqualTo(3);

        RuleFor(v => v.Fat).GreaterThanOrEqualTo(0).LessThanOrEqualTo(99);

        RuleFor(v => v.Sugar).GreaterThanOrEqualTo(0).LessThanOrEqualTo(99);

        RuleFor(v => v.Cholesterol).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);

        RuleFor(v => v.Carbohydrates).GreaterThanOrEqualTo(0).LessThanOrEqualTo(99);
    }
}
