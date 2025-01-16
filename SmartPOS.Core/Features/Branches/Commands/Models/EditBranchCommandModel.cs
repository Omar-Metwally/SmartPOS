using MediatR;
using SmartPOS.Common.Results;

namespace SmartPOS.Core.Features.Branches.Commands.Models;

public record EditBranchCommandModel(int BranchId, string? Name) : IRequest<IResult>;