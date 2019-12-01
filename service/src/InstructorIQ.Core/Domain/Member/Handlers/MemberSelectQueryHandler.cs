using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentCommand.Extensions;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberSelectQueryHandler 
        : DataContextHandlerBase<InstructorIQContext, MemberSelectQuery, IReadOnlyCollection<MemberReadModel>>
    {
        public MemberSelectQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<IReadOnlyCollection<MemberReadModel>> Process(MemberSelectQuery request, CancellationToken cancellationToken)
        {
            // users that are members for tenant
            var query = request.RoleName.HasValue()
                ? UserRoleQuery(request)
                : UserMemberQuery(request);

            var result = await query
                .AsNoTracking()
                .OrderBy(p => p.DisplayName)
                .ProjectTo<MemberReadModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return result;
        }

        private IQueryable<User> UserRoleQuery(MemberSelectQuery request)
        {
            return from c in DataContext.Users
                   where
                   (
                       from t in DataContext.TenantUserRoles
                       where t.TenantId == request.TenantId
                             && t.RoleName == request.RoleName
                       select t.UserName
                   ).Contains(c.UserName)
                   select c;
        }

        private IQueryable<User> UserMemberQuery(MemberSelectQuery request)
        {
            return from c in DataContext.Users
                   where
                   (
                       from t in DataContext.TenantUserRoles
                       where t.TenantId == request.TenantId
                       select t.UserName
                   ).Contains(c.UserName)
                   select c;
        }
    }
}