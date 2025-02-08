using MyGenes.Application.Foods.Queries.GetFood;
using MyGenes.Domain.Entities;

namespace MyGenes.Application.Foods.Queries.GetFoods;
public class FoodBriefDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
    public int FoodType { get; set; }
    public int Fat { get; set; }
    public int Carbohydrates { get; set; }
    public int Sugar { get; set; }

    public int Cholesterol { get; set; }

    public int FinalScore { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Food, FoodBriefDto>(); 

        }
    }
}
