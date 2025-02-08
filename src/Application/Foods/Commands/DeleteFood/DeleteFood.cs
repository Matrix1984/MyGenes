using MyGenes.Application.Common.Interfaces;

namespace MyGenes.Application.Foods.Commands.DeleteFood;
public record DeleteFoodCommand(int Id) : IRequest;

public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteFoodCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Foods
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Foods.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    } 
}
