
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Core.Contracts.Infrastructure.Persistence;

public interface IPurchaseRepository : IRepository<PurchaseTransaction>
{
}
