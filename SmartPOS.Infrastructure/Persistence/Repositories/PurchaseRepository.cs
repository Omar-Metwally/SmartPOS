using Microsoft.EntityFrameworkCore;
using SmartPOS.Core.Contracts.Infrastructure.Persistence;
using SmartPOS.Domain.Entities.Transactions;
using SmartPOS.Infrastructure.Persistence.Data;

namespace SmartPOS.Infrastructure.Persistence.Repositories;

public class PurchaseRepository(AppDbContext context) : Repository<PurchaseTransaction>(context), IPurchaseRepository
{
}
