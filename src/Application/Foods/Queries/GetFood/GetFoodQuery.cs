using MyGenes.Application.Common.Interfaces;

namespace MyGenes.Application.Foods.Queries.GetFood;
public record GetFoodQuery : IRequest<FoodDto?>
{
    public int Id { get; init; }
}

public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, FoodDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFoodQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FoodDto?> Handle(GetFoodQuery request, CancellationToken cancellationToken)
    {
        return await _context.Foods
            .Where(x => x.Id == request.Id)
            .ProjectTo<FoodDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
