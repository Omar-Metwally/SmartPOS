using MediatR;
using SmartPOS.Common.Results;

namespace SmartPOS.Core.Features.Purchase.Commands.Models;

public record AddProductToPurchaseCommandModel(int PurchaseId, List<UpsertProductToPurchaseModel> ItemsToAdd) : IRequest<IResult>;

public record UpsertProductToPurchaseModel(int ProductInstanceId, int UnitOfMeasure, int Quantity, decimal UnitPrice);

public record DeleteProductFromTransactionModel(int ProductInstanceId);