
using SmartPOS.Core.Contracts.Infrastructure.Persistence;
using SmartPOS.Infrastructure.Persistence.Data;

namespace SmartPOS.Infrastructure.Persistence.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;
    private bool _disposed = false;
    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _dbContext.Database.CommitTransactionAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
