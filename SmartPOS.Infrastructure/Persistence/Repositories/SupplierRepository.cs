using SmartPOS.Core.Contracts.Infrastructure.Persistence;
using SmartPOS.Domain.Entities.ExternalEntities;
using SmartPOS.Infrastructure.Persistence.Data;

namespace SmartPOS.Infrastructure.Persistence.Repositories;

public class SupplierRepository(AppDbContext context) : Repository<Supplier>(context), ISupplierRepository
{
}
