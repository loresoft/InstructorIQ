using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentCommand;
using FluentCommand.Extensions;
using FluentCommand.Merge;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Handlers;
using MediatR.CommandQuery.Models;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberAssignRoleCommandHandler
        : RequestHandlerBase<MemberAssignRoleCommand, CommandCompleteModel>
    {
        private readonly IDataSession _dataSession;

        public MemberAssignRoleCommandHandler(ILoggerFactory loggerFactory, IDataSession dataSession)
            : base(loggerFactory)
        {
            _dataSession = dataSession;
        }

        protected override async Task<CommandCompleteModel> Process(MemberAssignRoleCommand request, CancellationToken cancellationToken)
        {
            if (request.Users.Count == 0 || request.Roles.Count == 0)
            {
                Logger.LogWarning("No users or roles to process");
                return new CommandCompleteModel();
            }

            var assignments = from user in request.Users
                              from role in request.Roles
                              select new MemberAssignRoleModel
                              {
                                  TenantId = request.TenantId,
                                  UserName = user,
                                  RoleName = role
                              };

            int rows = await _dataSession
                .MergeData("[IQ].[TenantUserRole]")
                .IncludeInsert()
                .IncludeUpdate(false)
                .Mode(DataMergeMode.SqlStatement)
                .Map<MemberAssignRoleModel>(m =>
                {
                    m.Column(p => p.TenantId).Key();
                    m.Column(p => p.UserName).Key();
                    m.Column(p => p.RoleName).Key();
                })
                .ExecuteAsync(assignments, cancellationToken);

            Logger.LogInformation("Processed {rows} user role assignments", rows);

            return new CommandCompleteModel();
        }
    }
}