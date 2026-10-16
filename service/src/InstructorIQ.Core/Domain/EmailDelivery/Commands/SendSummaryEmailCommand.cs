using System.Security.Claims;

using InstructorIQ.Core.Models;

using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record SendSummaryEmailCommand : EntityModelCommand<SummaryReportModel, CompleteModel>
{
    public SendSummaryEmailCommand(ClaimsPrincipal principal, SummaryReportModel model)
        : base(principal, model)
    {

    }
}
