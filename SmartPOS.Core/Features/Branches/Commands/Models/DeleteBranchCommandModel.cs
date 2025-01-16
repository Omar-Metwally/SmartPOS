using MediatR;
using SmartPOS.Common.Results;

namespace SmartPOS.Core.Features.Branches.Commands.Models;

public record DeleteBranchCommandModel(int BranchId) : IRequest<IResult>;