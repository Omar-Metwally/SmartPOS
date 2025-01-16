using MediatR;
using SmartPOS.Common.Results;

namespace SmartPOS.Core.Features.Purchase.Commands.Models;

public record AddPurchaseCommandModel(int BranchId, int WarehouseId, int SafeId, int SupplierId, DateTime? Date, decimal PayedAmount, string PaymentType, string? Note) : IRequest<IResult>;