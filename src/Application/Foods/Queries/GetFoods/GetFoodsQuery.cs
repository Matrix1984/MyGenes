using MyGenes.Application.Common.Interfaces;
using MyGenes.Domain.Enums;

namespace MyGenes.Application.Foods.Queries.GetFoods;
public record GetFoodsQuery : IRequest<IReadOnlyCollection<FoodBriefDto>>
{
    public int? FoodType { get; init; }

    public int MinScore { get; init; }

    public int? MaxScore { get; init; }
}

public class GetFoodsQueryHandler : IRequestHandler<GetFoodsQuery, IReadOnlyCollection<FoodBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFoodsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<FoodBriefDto>> Handle(GetFoodsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Foods.Where(x => x.FinalScore >= request.MinScore);

        if (request.MaxScore != null)
            query = query.Where(x => x.FinalScore <= request.MaxScore);

        if (request.FoodType != null)
            query = query.Where(x => x.FoodType == (FoodType)request!.FoodType);

        return (IReadOnlyCollection<FoodBriefDto>)await query
            .OrderBy(x => x.Id)
            .ProjectTo<FoodBriefDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
