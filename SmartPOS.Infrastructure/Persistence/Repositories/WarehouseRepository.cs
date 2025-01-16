using Microsoft.EntityFrameworkCore;
using SmartPOS.Core.Contracts.Infrastructure.Persistence;
using SmartPOS.Domain.Entities.Organization;
using SmartPOS.Infrastructure.Persistence.Data;

namespace SmartPOS.Infrastructure.Persistence.Repositories;

public class WarehouseRepository(AppDbContext context) : Repository<Warehouse>(context), IWarehouseRepository
{
}
