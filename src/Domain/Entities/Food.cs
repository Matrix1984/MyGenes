namespace MyGenes.Domain.Entities;
public class Food : BaseAuditableEntity
{ 
    public required string Name { get; set; }

    public string? ImageUrl { get; set; }

    // Number between 1 to 3.
    public FoodType FoodType { get; set; }

    // Number between 0 to 99.
    public int Fat { get; set; }

    // Number between 0 to 99.
    public int Carbohydrates { get; set; }

    // Number between 0 to 99.
    public int Sugar { get; set; }

    // Number between 0 to 1.
    public int Cholesterol { get; set; }

    public int FinalScore { get; set; } 
}



