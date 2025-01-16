using MediatR;
using SmartPOS.Common.Results;

namespace SmartPOS.Core.Features.Purchase.Commands.Models;

public record EditProductToPurchaseCommandModel(int PurchaseId, List<UpsertProductToPurchaseModel> ItemsToEdit, List<DeleteProductFromTransactionModel> ItemsToDelete) : IRequest<IResult>;
