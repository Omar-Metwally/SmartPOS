using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Attribute = SmartPOS.Domain.Entities.Products.Attribute;
using SmartPOS.Domain.Entities.Products;
using SmartPOS.Domain.Entities.ExternalEntities;
using SmartPOS.Domain.Entities.Organization;
using SmartPOS.Domain.Entities.Transactions;
using SmartPOS.Infrastructure.Persistence.Data.Interceptors;
using SmartPOS.Core.Contracts.Infrastructure.Identity;
using SmartPOS.Domain.Entities.Inventory;
using SmartPOS.Domain.Entities.Accounting;

namespace SmartPOS.Infrastructure.Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) : DbContext(options)
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new CentralInterceptor(currentUserService));
    }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Safe> Safes { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<ProductInventoryLevel> ProductInventoryLevels { get; set; }

    public virtual DbSet<ProductTransferTransaction> ProductTransferTransactions { get; set; }

    public virtual DbSet<PurchaseTransaction> PurchaseTransactions { get; set; }

    public virtual DbSet<ClientSalesTransaction> ClientSalesTransactions { get; set; }

    public virtual DbSet<CustomerSalesTransaction> CustomerSalesTransactions { get; set; }

    public virtual DbSet<PaymentTransaction> PaymentTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
