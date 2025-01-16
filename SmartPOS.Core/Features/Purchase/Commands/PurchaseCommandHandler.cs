using MediatR;
using SmartPOS.Common.Results;
using SmartPOS.Core.Contracts.Infrastructure.Persistence;
using SmartPOS.Core.Features.Purchase.Commands.Models;
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Core.Features.Purchase.Commands;

public class PurchaseCommandHandler(IPurchaseRepository purchaseRepository, IBranchRepository branchRepository, IWarehouseRepository warehouseRepository, ISafeRepository safeRepository, ISupplierRepository supplierRepository, IUnitOfWork unitOfWork) :
    IRequestHandler<AddPurchaseCommandModel, IResult>,
    IRequestHandler<EditPurchaseCommandModel, IResult>,
    IRequestHandler<AddProductToPurchaseCommandModel, IResult>,
    IRequestHandler<EditProductToPurchaseCommandModel, IResult>
{

    private readonly IPurchaseRepository _purchaseRepository = purchaseRepository;
    private readonly IBranchRepository _branchRepository = branchRepository;
    private readonly IWarehouseRepository _warehouseRepository = warehouseRepository;
    private readonly ISafeRepository _safeRepository = safeRepository;
    private readonly ISupplierRepository _supplierRepository = supplierRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IResult> Handle(AddPurchaseCommandModel request, CancellationToken cancellationToken)
    {
        var doesBranchExist = await _branchRepository.DoesExist(request.BranchId);
        if (!doesBranchExist)
            return new Result().WithBadRequest("The selected branch does not exist");

        var doesWarehouseExist = await _warehouseRepository.DoesExist(request.WarehouseId);
        if (!doesWarehouseExist)
            return new Result().WithBadRequest("The selected warehouse does not exist");

        var doesSafeExist = await _safeRepository.DoesExist(request.SafeId);
        if (!doesSafeExist)
            return new Result().WithBadRequest("The selected safe does not exist");

        var doesSupplierExist = await _supplierRepository.DoesExist(request.SupplierId);
        if (!doesSupplierExist)
            return new Result().WithBadRequest("The selected supplier does not exist");

        var purchaseResult = PurchaseTransaction.Create(request.SupplierId, request.BranchId, request.WarehouseId, request.SafeId, request.PayedAmount, request.PaymentType, request.Note);
        if (purchaseResult.IsFailed)
            return purchaseResult;

        await _purchaseRepository.Add(purchaseResult.Value, cancellationToken);

        await purchaseResult
            .WithTask(() => _unitOfWork.SaveChangesAsync(cancellationToken), "Database error");
        if (purchaseResult.IsFailed)
            return purchaseResult;

        return new Result(purchaseResult.Value.Id).WithCreated();
    }

    public async Task<IResult> Handle(EditPurchaseCommandModel request, CancellationToken cancellationToken)
    {
        IResult purchaseResult = new Result();

        var purchase = await _purchaseRepository.GetByID(request.PurchaseId);
        if (purchase == null)
            return new Result().WithBadRequest("This purchase transaction does not exist");

        if (request.BranchId.HasValue)
        {
            var doesBranchExist = await _branchRepository.DoesExist(request.BranchId.Value);
            if (!doesBranchExist)
                return new Result().WithBadRequest("The selected branch does not exist");

            purchaseResult = purchase.UpdateBranch(request.BranchId.Value);
            if (purchaseResult.IsFailed)
                return purchaseResult;
        }

        if (request.WarehouseId.HasValue)
        {
            var doesWarehouseExist = await _warehouseRepository.DoesExist(request.WarehouseId.Value);
            if (!doesWarehouseExist)
                return new Result().WithBadRequest("The selected warehouse does not exist");

            purchaseResult = purchase.UpdateWarehouse(request.WarehouseId.Value);
            if (purchaseResult.IsFailed)
                return purchaseResult;
        }

        if (request.SafeId.HasValue)
        {
            var doesSafeExist = await _safeRepository.DoesExist(request.SafeId.Value);
            if (!doesSafeExist)
                return new Result().WithBadRequest("The selected safe does not exist");

            purchaseResult = purchase.UpdateSafe(request.SafeId.Value);
            if (purchaseResult.IsFailed)
                return purchaseResult;
        }

        if (request.SupplierId.HasValue)
        {
            var doesSupplierExist = await _supplierRepository.DoesExist(request.SupplierId.Value);
            if (!doesSupplierExist)
                return new Result().WithBadRequest("The selected supplier does not exist");

            purchaseResult = purchase.UpdateSupplier(request.SupplierId.Value);
            if (purchaseResult.IsFailed)
                return purchaseResult;
        }

        await purchaseResult
            .WithTask(() => _unitOfWork.SaveChangesAsync(cancellationToken), "Database error");
        if (purchaseResult.IsFailed)
            return purchaseResult;

        return purchaseResult.WithUpdated();
    }

    public Task<IResult> Handle(AddProductToPurchaseCommandModel request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> Handle(EditProductToPurchaseCommandModel request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
