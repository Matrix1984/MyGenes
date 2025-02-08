using MyGenes.Domain.Entities;

namespace MyGenes.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Food> Foods { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
