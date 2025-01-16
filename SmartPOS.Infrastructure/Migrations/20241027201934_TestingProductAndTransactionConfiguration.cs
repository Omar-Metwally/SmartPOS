using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPOS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestingProductAndTransactionConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ExternalPartySequence");

            migrationBuilder.CreateSequence(
                name: "TransactionSequence");

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ExternalPartySequence]"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ExternalPartySequence]"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address_Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Safes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CashStartBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    VISAStartBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ChequeStartBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ExternalPartySequence]"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => new { x.AttributeId, x.Id });
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientAddresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientContacts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelfLifeInDays = table.Column<int>(type: "int", nullable: true),
                    WarrantyInDays = table.Column<int>(type: "int", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierAddresses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierContacts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DefaultQuantityAlertLevel = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInstances_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInstanceAttributeValues",
                columns: table => new
                {
                    ProductInstanceId = table.Column<int>(type: "int", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    AttributeValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInstanceAttributeValues", x => new { x.ProductInstanceId, x.AttributeId, x.AttributeValueId });
                    table.ForeignKey(
                        name: "FK_ProductInstanceAttributeValues_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInstanceAttributeValues_ProductInstances_ProductInstanceId",
                        column: x => x.ProductInstanceId,
                        principalTable: "ProductInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInstanceImages",
                columns: table => new
                {
                    Path = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInstanceImages", x => x.Path);
                    table.ForeignKey(
                        name: "FK_ProductInstanceImages_ProductInstances_ProductInstanceId",
                        column: x => x.ProductInstanceId,
                        principalTable: "ProductInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInstancePrices",
                columns: table => new
                {
                    ProductInstanceId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInstancePrices", x => new { x.ProductInstanceId, x.UnitOfMeasureId });
                    table.ForeignKey(
                        name: "FK_ProductInstancePrices_ProductInstances_ProductInstanceId",
                        column: x => x.ProductInstanceId,
                        principalTable: "ProductInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInstancePrices_UnitsOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitsOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventoryLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductInstanceId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventoryLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInventoryLevels_ProductInstancePrices_ProductInstanceId_UnitOfMeasureId",
                        columns: x => new { x.ProductInstanceId, x.UnitOfMeasureId },
                        principalTable: "ProductInstancePrices",
                        principalColumns: new[] { "ProductInstanceId", "UnitOfMeasureId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventoryLevels_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLevelChange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductInventoryLevelId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangeType = table.Column<int>(type: "int", nullable: false),
                    PreviousQuantity = table.Column<int>(type: "int", nullable: false),
                    ChangedQuantity = table.Column<int>(type: "int", nullable: false),
                    NewQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLevelChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLevelChange_ProductInventoryLevels_ProductInventoryLevelId",
                        column: x => x.ProductInventoryLevelId,
                        principalTable: "ProductInventoryLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerializedUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductInstanceId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    ProductInventoryLevelId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProductInstancePriceProductInstanceId = table.Column<int>(type: "int", nullable: true),
                    ProductInstancePriceUnitOfMeasureId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerializedUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerializedUnit_ProductInstancePrices_ProductInstanceId_UnitOfMeasureId",
                        columns: x => new { x.ProductInstanceId, x.UnitOfMeasureId },
                        principalTable: "ProductInstancePrices",
                        principalColumns: new[] { "ProductInstanceId", "UnitOfMeasureId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerializedUnit_ProductInstancePrices_ProductInstancePriceProductInstanceId_ProductInstancePriceUnitOfMeasureId",
                        columns: x => new { x.ProductInstancePriceProductInstanceId, x.ProductInstancePriceUnitOfMeasureId },
                        principalTable: "ProductInstancePrices",
                        principalColumns: new[] { "ProductInstanceId", "UnitOfMeasureId" });
                    table.ForeignKey(
                        name: "FK_SerializedUnit_ProductInventoryLevels_ProductInventoryLevelId",
                        column: x => x.ProductInventoryLevelId,
                        principalTable: "ProductInventoryLevels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SerialUnitChange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerializedUnitId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldWarehouseId = table.Column<int>(type: "int", nullable: true),
                    NewWarehouseId = table.Column<int>(type: "int", nullable: true),
                    ProductLevelChangeId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialUnitChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerialUnitChange_ProductLevelChange_ProductLevelChangeId",
                        column: x => x.ProductLevelChangeId,
                        principalTable: "ProductLevelChange",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SerialUnitChange_SerializedUnit_SerializedUnitId",
                        column: x => x.SerializedUnitId,
                        principalTable: "SerializedUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerialUnitChange_Warehouses_NewWarehouseId",
                        column: x => x.NewWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SerialUnitChange_Warehouses_OldWarehouseId",
                        column: x => x.OldWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientSalesTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [TransactionSequence]"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SafeId = table.Column<int>(type: "int", nullable: false),
                    Payment_PayedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Payment_Type = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Payment_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDetails_Address_Id = table.Column<int>(type: "int", nullable: false),
                    DeliveryDetails_Address_Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeliveryDetails_Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeliveryDetails_Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeliveryDetails_Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeliveryDetails_Address_PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DeliveryDetails_Address_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSalesTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSalesTransactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientSalesTransactions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientSalesTransactions_Safes_SafeId",
                        column: x => x.SafeId,
                        principalTable: "Safes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientSalesTransactions_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSalesTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [TransactionSequence]"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SafeId = table.Column<int>(type: "int", nullable: false),
                    Payment_PayedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Payment_Type = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Payment_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDetails_Address_Id = table.Column<int>(type: "int", nullable: false),
                    DeliveryDetails_Address_Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeliveryDetails_Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeliveryDetails_Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeliveryDetails_Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeliveryDetails_Address_PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DeliveryDetails_Address_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSalesTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSalesTransactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSalesTransactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSalesTransactions_Safes_SafeId",
                        column: x => x.SafeId,
                        principalTable: "Safes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSalesTransactions_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address_Id = table.Column<int>(type: "int", nullable: true),
                    Address_Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [TransactionSequence]"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    SafeId = table.Column<int>(type: "int", nullable: false),
                    Payment_PayedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment_Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Payment_Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Safes_SafeId",
                        column: x => x.SafeId,
                        principalTable: "Safes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTransferTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [TransactionSequence]"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ReceivingWarehouseId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTransferTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTransferTransactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTransferTransactions_Warehouses_ReceivingWarehouseId",
                        column: x => x.ReceivingWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTransferTransactions_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [TransactionSequence]"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    SafeId = table.Column<int>(type: "int", nullable: false),
                    Payment_PayedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Payment_Type = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Payment_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Safes_SafeId",
                        column: x => x.SafeId,
                        principalTable: "Safes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SafeTransferTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [TransactionSequence]"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafeId = table.Column<int>(type: "int", nullable: false),
                    ReceivingSafeId = table.Column<int>(type: "int", nullable: false),
                    Payment_PayedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment_Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Payment_Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafeTransferTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafeTransferTransaction_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SafeTransferTransaction_Safes_ReceivingSafeId",
                        column: x => x.ReceivingSafeId,
                        principalTable: "Safes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafeTransferTransaction_Safes_SafeId",
                        column: x => x.SafeId,
                        principalTable: "Safes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientSalesTransactions_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UnitPriceBeforeDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InventoryTransactionId = table.Column<int>(type: "int", nullable: false),
                    ProductInstanceId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSalesTransactions_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSalesTransactions_Items_ClientSalesTransactions_InventoryTransactionId",
                        column: x => x.InventoryTransactionId,
                        principalTable: "ClientSalesTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientSalesTransactions_Items_ProductInstancePrices_ProductInstanceId_UnitOfMeasureID",
                        columns: x => new { x.ProductInstanceId, x.UnitOfMeasureID },
                        principalTable: "ProductInstancePrices",
                        principalColumns: new[] { "ProductInstanceId", "UnitOfMeasureId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientSalesTransactions_Returns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_PayedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Payment_Type = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Payment_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSalesTransactions_Returns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSalesTransactions_Returns_ClientSalesTransactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "ClientSalesTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSalesTransactions_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UnitPriceBeforeDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InventoryTransactionId = table.Column<int>(type: "int", nullable: false),
                    ProductInstanceId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSalesTransactions_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSalesTransactions_Items_CustomerSalesTransactions_InventoryTransactionId",
                        column: x => x.InventoryTransactionId,
                        principalTable: "CustomerSalesTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSalesTransactions_Items_ProductInstancePrices_ProductInstanceId_UnitOfMeasureID",
                        columns: x => new { x.ProductInstanceId, x.UnitOfMeasureID },
                        principalTable: "ProductInstancePrices",
                        principalColumns: new[] { "ProductInstanceId", "UnitOfMeasureId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSalesTransactions_Returns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_PayedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Payment_Type = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Payment_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSalesTransactions_Returns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSalesTransactions_Returns_CustomerSalesTransactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "CustomerSalesTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTransferTransactions_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryTransactionId = table.Column<int>(type: "int", nullable: false),
                    ProductInstanceId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTransferTransactions_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTransferTransactions_Items_ProductInstancePrices_ProductInstanceId_UnitOfMeasureID",
                        columns: x => new { x.ProductInstanceId, x.UnitOfMeasureID },
                        principalTable: "ProductInstancePrices",
                        principalColumns: new[] { "ProductInstanceId", "UnitOfMeasureId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTransferTransactions_Items_ProductTransferTransactions_InventoryTransactionId",
                        column: x => x.InventoryTransactionId,
                        principalTable: "ProductTransferTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTransactions_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryTransactionId = table.Column<int>(type: "int", nullable: false),
                    ProductInstanceId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTransactions_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Items_ProductInstancePrices_ProductInstanceId_UnitOfMeasureID",
                        columns: x => new { x.ProductInstanceId, x.UnitOfMeasureID },
                        principalTable: "ProductInstancePrices",
                        principalColumns: new[] { "ProductInstanceId", "UnitOfMeasureId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Items_PurchaseTransactions_InventoryTransactionId",
                        column: x => x.InventoryTransactionId,
                        principalTable: "PurchaseTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTransactions_Returns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_PayedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Payment_Type = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Payment_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTransactions_Returns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Returns_PurchaseTransactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "PurchaseTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientSalesTransactions_Returns_ReturnedItems",
                columns: table => new
                {
                    ExternalEntityInventoryTransactionReturnId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnTransactionId = table.Column<int>(type: "int", nullable: false),
                    InventoryTransactionItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSalesTransactions_Returns_ReturnedItems", x => new { x.ExternalEntityInventoryTransactionReturnId, x.Id });
                    table.ForeignKey(
                        name: "FK_ClientSalesTransactions_Returns_ReturnedItems_ClientSalesTransactions_Returns_ExternalEntityInventoryTransactionReturnId",
                        column: x => x.ExternalEntityInventoryTransactionReturnId,
                        principalTable: "ClientSalesTransactions_Returns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSalesTransactions_Returns_ReturnedItems",
                columns: table => new
                {
                    ExternalEntityInventoryTransactionReturnId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnTransactionId = table.Column<int>(type: "int", nullable: false),
                    InventoryTransactionItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSalesTransactions_Returns_ReturnedItems", x => new { x.ExternalEntityInventoryTransactionReturnId, x.Id });
                    table.ForeignKey(
                        name: "FK_CustomerSalesTransactions_Returns_ReturnedItems_CustomerSalesTransactions_Returns_ExternalEntityInventoryTransactionReturnId",
                        column: x => x.ExternalEntityInventoryTransactionReturnId,
                        principalTable: "CustomerSalesTransactions_Returns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTransactions_Returns_ReturnedItems",
                columns: table => new
                {
                    ExternalEntityInventoryTransactionReturnId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnTransactionId = table.Column<int>(type: "int", nullable: false),
                    InventoryTransactionItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTransactions_Returns_ReturnedItems", x => new { x.ExternalEntityInventoryTransactionReturnId, x.Id });
                    table.ForeignKey(
                        name: "FK_PurchaseTransactions_Returns_ReturnedItems_PurchaseTransactions_Returns_ExternalEntityInventoryTransactionReturnId",
                        column: x => x.ExternalEntityInventoryTransactionReturnId,
                        principalTable: "PurchaseTransactions_Returns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ManagerId",
                table: "Branches",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddresses_ClientId",
                table: "ClientAddresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_ClientId",
                table: "ClientContacts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSalesTransactions_BranchId",
                table: "ClientSalesTransactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSalesTransactions_ClientId",
                table: "ClientSalesTransactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSalesTransactions_SafeId",
                table: "ClientSalesTransactions",
                column: "SafeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSalesTransactions_WarehouseId",
                table: "ClientSalesTransactions",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSalesTransactions_Items_InventoryTransactionId",
                table: "ClientSalesTransactions_Items",
                column: "InventoryTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSalesTransactions_Items_ProductInstanceId_UnitOfMeasureID",
                table: "ClientSalesTransactions_Items",
                columns: new[] { "ProductInstanceId", "UnitOfMeasureID" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientSalesTransactions_Returns_TransactionId",
                table: "ClientSalesTransactions_Returns",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSalesTransactions_BranchId",
                table: "CustomerSalesTransactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSalesTransactions_CustomerId",
                table: "CustomerSalesTransactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSalesTransactions_SafeId",
                table: "CustomerSalesTransactions",
                column: "SafeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSalesTransactions_WarehouseId",
                table: "CustomerSalesTransactions",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSalesTransactions_Items_InventoryTransactionId",
                table: "CustomerSalesTransactions_Items",
                column: "InventoryTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSalesTransactions_Items_ProductInstanceId_UnitOfMeasureID",
                table: "CustomerSalesTransactions_Items",
                columns: new[] { "ProductInstanceId", "UnitOfMeasureID" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSalesTransactions_Returns_TransactionId",
                table: "CustomerSalesTransactions_Returns",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobId",
                table: "Employees",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_BranchId",
                table: "PaymentTransactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_PartyId",
                table: "PaymentTransactions",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_SafeId",
                table: "PaymentTransactions",
                column: "SafeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInstanceAttributeValues_AttributeId",
                table: "ProductInstanceAttributeValues",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInstanceAttributeValues_ProductInstanceId_AttributeId",
                table: "ProductInstanceAttributeValues",
                columns: new[] { "ProductInstanceId", "AttributeId" },
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInstanceImages_ProductInstanceId",
                table: "ProductInstanceImages",
                column: "ProductInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInstancePrices_UnitOfMeasureId",
                table: "ProductInstancePrices",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInstances_ProductId",
                table: "ProductInstances",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInstances_Sku",
                table: "ProductInstances",
                column: "Sku",
                unique: true,
                filter: "[Sku] IS NOT NULL")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventoryLevels_ProductInstanceId_UnitOfMeasureId_WarehouseId",
                table: "ProductInventoryLevels",
                columns: new[] { "ProductInstanceId", "UnitOfMeasureId", "WarehouseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventoryLevels_WarehouseId",
                table: "ProductInventoryLevels",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLevelChange_ProductInventoryLevelId",
                table: "ProductLevelChange",
                column: "ProductInventoryLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLevelChange_TransactionId",
                table: "ProductLevelChange",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransferTransactions_BranchId",
                table: "ProductTransferTransactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransferTransactions_ReceivingWarehouseId",
                table: "ProductTransferTransactions",
                column: "ReceivingWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransferTransactions_WarehouseId",
                table: "ProductTransferTransactions",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransferTransactions_Items_InventoryTransactionId",
                table: "ProductTransferTransactions_Items",
                column: "InventoryTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransferTransactions_Items_ProductInstanceId_UnitOfMeasureID",
                table: "ProductTransferTransactions_Items",
                columns: new[] { "ProductInstanceId", "UnitOfMeasureID" });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_BranchId",
                table: "PurchaseTransactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_SafeId",
                table: "PurchaseTransactions",
                column: "SafeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_SupplierId",
                table: "PurchaseTransactions",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_WarehouseId",
                table: "PurchaseTransactions",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Items_InventoryTransactionId",
                table: "PurchaseTransactions_Items",
                column: "InventoryTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Items_ProductInstanceId_UnitOfMeasureID",
                table: "PurchaseTransactions_Items",
                columns: new[] { "ProductInstanceId", "UnitOfMeasureID" });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_Returns_TransactionId",
                table: "PurchaseTransactions_Returns",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_SafeTransferTransaction_BranchId",
                table: "SafeTransferTransaction",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SafeTransferTransaction_ReceivingSafeId",
                table: "SafeTransferTransaction",
                column: "ReceivingSafeId");

            migrationBuilder.CreateIndex(
                name: "IX_SafeTransferTransaction_SafeId",
                table: "SafeTransferTransaction",
                column: "SafeId");

            migrationBuilder.CreateIndex(
                name: "IX_SerializedUnit_ProductInstanceId_SerialNumber",
                table: "SerializedUnit",
                columns: new[] { "ProductInstanceId", "SerialNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SerializedUnit_ProductInstanceId_UnitOfMeasureId",
                table: "SerializedUnit",
                columns: new[] { "ProductInstanceId", "UnitOfMeasureId" });

            migrationBuilder.CreateIndex(
                name: "IX_SerializedUnit_ProductInstancePriceProductInstanceId_ProductInstancePriceUnitOfMeasureId",
                table: "SerializedUnit",
                columns: new[] { "ProductInstancePriceProductInstanceId", "ProductInstancePriceUnitOfMeasureId" });

            migrationBuilder.CreateIndex(
                name: "IX_SerializedUnit_ProductInventoryLevelId",
                table: "SerializedUnit",
                column: "ProductInventoryLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialUnitChange_NewWarehouseId",
                table: "SerialUnitChange",
                column: "NewWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialUnitChange_OldWarehouseId",
                table: "SerialUnitChange",
                column: "OldWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialUnitChange_ProductLevelChangeId",
                table: "SerialUnitChange",
                column: "ProductLevelChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialUnitChange_SerializedUnitId",
                table: "SerialUnitChange",
                column: "SerializedUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierAddresses_SupplierId",
                table: "SupplierAddresses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierContacts_SupplierId",
                table: "SupplierContacts",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Employees_ManagerId",
                table: "Branches",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Employees_ManagerId",
                table: "Branches");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "ClientAddresses");

            migrationBuilder.DropTable(
                name: "ClientContacts");

            migrationBuilder.DropTable(
                name: "ClientSalesTransactions_Items");

            migrationBuilder.DropTable(
                name: "ClientSalesTransactions_Returns_ReturnedItems");

            migrationBuilder.DropTable(
                name: "CustomerSalesTransactions_Items");

            migrationBuilder.DropTable(
                name: "CustomerSalesTransactions_Returns_ReturnedItems");

            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "ProductInstanceAttributeValues");

            migrationBuilder.DropTable(
                name: "ProductInstanceImages");

            migrationBuilder.DropTable(
                name: "ProductTransferTransactions_Items");

            migrationBuilder.DropTable(
                name: "PurchaseTransactions_Items");

            migrationBuilder.DropTable(
                name: "PurchaseTransactions_Returns_ReturnedItems");

            migrationBuilder.DropTable(
                name: "SafeTransferTransaction");

            migrationBuilder.DropTable(
                name: "SerialUnitChange");

            migrationBuilder.DropTable(
                name: "SupplierAddresses");

            migrationBuilder.DropTable(
                name: "SupplierContacts");

            migrationBuilder.DropTable(
                name: "ClientSalesTransactions_Returns");

            migrationBuilder.DropTable(
                name: "CustomerSalesTransactions_Returns");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "ProductTransferTransactions");

            migrationBuilder.DropTable(
                name: "PurchaseTransactions_Returns");

            migrationBuilder.DropTable(
                name: "ProductLevelChange");

            migrationBuilder.DropTable(
                name: "SerializedUnit");

            migrationBuilder.DropTable(
                name: "ClientSalesTransactions");

            migrationBuilder.DropTable(
                name: "CustomerSalesTransactions");

            migrationBuilder.DropTable(
                name: "PurchaseTransactions");

            migrationBuilder.DropTable(
                name: "ProductInventoryLevels");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Safes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "ProductInstancePrices");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "ProductInstances");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasure");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropSequence(
                name: "ExternalPartySequence");

            migrationBuilder.DropSequence(
                name: "TransactionSequence");
        }
    }
}
