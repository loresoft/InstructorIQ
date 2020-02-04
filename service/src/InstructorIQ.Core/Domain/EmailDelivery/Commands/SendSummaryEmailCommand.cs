using System.Security.Principal;
using InstructorIQ.Core.Models;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class SendSummaryEmailCommand : EntityModelCommand<SummaryReportModel, CommandCompleteModel>
    {
        public SendSummaryEmailCommand(IPrincipal principal, SummaryReportModel model)
            : base(principal, model)
        {

        }
    }
}