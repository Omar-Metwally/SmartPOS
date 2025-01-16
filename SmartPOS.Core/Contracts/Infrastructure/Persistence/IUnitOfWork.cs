namespace SmartPOS.Core.Contracts.Infrastructure.Persistence;

public interface IUnitOfWork
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
