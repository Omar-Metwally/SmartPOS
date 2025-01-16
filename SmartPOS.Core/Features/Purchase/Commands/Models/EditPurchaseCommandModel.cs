using MediatR;
using SmartPOS.Common.Results;

namespace SmartPOS.Core.Features.Purchase.Commands.Models;

public record EditPurchaseCommandModel(int PurchaseId,int? BranchId, int? WarehouseId, int? SafeId, int? SupplierId, DateTime? Date, decimal? PayedAmount, string? PaymentMethod) : IRequest<IResult>;