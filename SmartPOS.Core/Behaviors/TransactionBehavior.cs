using MediatR;
using SmartPOS.Core.Contracts.Infrastructure.Persistence;
using SmartPOS.Core.MarkerInterfaces;

namespace SmartPOS.Core.Behaviors;

public class TransactionBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ITransactionalRequest
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response;

        //try
        //{
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        throw new Exception();
        response = await next();
        await _unitOfWork.CommitAsync(cancellationToken);
        //}
        //catch (Exception exception)
        //{
        //    await _unitOfWork.RollbackAsync(cancellationToken);

        //    var result = new Result<bool>()
        //        .WithError(SharedResourcesKeys.DatabaseError)
        //        .WithMessage(HttpStatusCode.InternalServerError.ToString())
        //        .WithStatusCode(HttpStatusCode.InternalServerError);

        //    return (TResponse)result;
        //}

        return response;
    }
}