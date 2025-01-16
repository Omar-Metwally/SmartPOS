using MediatR;
using SmartPOS.Common.Results;
using SmartPOS.Core.Contracts.Infrastructure.Persistence;
using SmartPOS.Core.Features.Branches.Commands.Models;
using SmartPOS.Domain.Entities.Organization;

namespace SmartPOS.Core.Features.Branches.Commands.Handlers;

public class BranchCommandHandler(IBranchRepository branchRepository, IUnitOfWork unitOfWork) :
    IRequestHandler<AddBranchCommandModel, IResult>
    //IRequestHandler<EditBranchCommandModel, IResult>,
    //IRequestHandler<DeleteBranchCommandModel, IResult>

{
    private readonly IBranchRepository _branchRepository = branchRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IResult> Handle(AddBranchCommandModel request, CancellationToken cancellationToken)
    {
        var doesNameExist = await _branchRepository.DoesExist(x => x.Name == request.Name);
        if (doesNameExist)
            return new Result<int>()
                .WithBadRequest("");

        //return new Result(5);
        var branchToBeCreatedResult = Branch.Create(request.Name);
        if (branchToBeCreatedResult.IsFailed)
            return branchToBeCreatedResult;

        var branch = branchToBeCreatedResult.Value;

        await _branchRepository.Add(branch, cancellationToken);

        await branchToBeCreatedResult
            .WithTask(() => _unitOfWork.SaveChangesAsync(cancellationToken), "Database Error");
        if (branchToBeCreatedResult.IsFailed)
            return branchToBeCreatedResult;

        return branchToBeCreatedResult;

    }

    //public async Task<IResult> Handle(EditBranchCommandModel request, CancellationToken cancellationToken)
    //{
    //    var branchToBeEdited = await _branchRepository.GetByID(request.BranchId);
    //    if (branchToBeEdited == null)
    //        return new Result<Branch>()
    //            .WithBadRequest(SharedResourcesKeys.DoesNotExist.Localize(SharedResourcesKeys.Branch.Localize()));

    //    if (!string.IsNullOrWhiteSpace(request.EnglishName))
    //    {
    //        var doesEnglishNameExist = await _branchRepository.DoesExist(x => x.Name.English == request.EnglishName && x.Id != request.BranchId);
    //        if (doesEnglishNameExist)
    //            return new Result<Branch>()
    //                .WithBadRequest(SharedResourcesKeys.DoesExist.Localize(SharedResourcesKeys.NameEn.Localize()));

    //        branchToBeEdited.Name.UpdateEnglish(request.EnglishName);
    //    }

    //    if (!string.IsNullOrWhiteSpace(request.ArabicName))
    //    {
    //        var doesArabicNameExist = await _branchRepository.DoesExist(x => x.Name.Arabic == request.ArabicName && x.Id != request.BranchId);
    //        if (doesArabicNameExist)
    //            return new Result<Branch>()
    //                .WithBadRequest(SharedResourcesKeys.DoesExist.Localize(SharedResourcesKeys.NameAr.Localize()));

    //        branchToBeEdited.Name.UpdateArabic(request.ArabicName);
    //    }

    //    _branchRepository.Update(branchToBeEdited);

    //    var branchUpdateResult = await new Result<Branch>(branchToBeEdited)
    //        .WithTask(() => _unitOfWork.SaveChangesAsync(cancellationToken), SharedResourcesKeys.DatabaseError);
    //    if (branchUpdateResult.IsFailed)
    //        return branchUpdateResult;

    //    return branchUpdateResult.WithUpdated();
    //}

    //public async Task<IResult> Handle(DeleteBranchCommandModel request, CancellationToken cancellationToken)
    //{
    //    var branchToBeDeleted = await _branchRepository.GetByID(request.BranchId);
    //    if (branchToBeDeleted == null)
    //        return new Result<Branch>()
    //            .WithBadRequest(SharedResourcesKeys.DoesNotExist.Localize(SharedResourcesKeys.Branch.Localize()));

    //    _branchRepository.Remove(branchToBeDeleted);

    //    var branchDeleteResult = await new Result<Branch>(branchToBeDeleted)
    //        .WithTask(() => _unitOfWork.SaveChangesAsync(cancellationToken), SharedResourcesKeys.DatabaseError);
    //    if (branchDeleteResult.IsFailed)
    //        return branchDeleteResult;

    //    return branchDeleteResult.WithDeleted();
    //}
}