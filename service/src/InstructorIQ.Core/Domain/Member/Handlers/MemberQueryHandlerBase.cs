using System;
using System.Linq;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using MediatR;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public abstract class MemberQueryHandlerBase<TRequest, TResponse>
        : DataContextHandlerBase<InstructorIQContext, TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected MemberQueryHandlerBase(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected virtual IQueryable<User> UserQuery(Guid tenantId, Guid? roleId)
        {
            return roleId.HasValue
                ? UserRoleQuery(tenantId, roleId.Value)
                : UserMemberQuery(tenantId);
        }

        protected virtual IQueryable<User> UserRoleQuery(Guid tenantId, Guid roleId)
        {
            return from c in DataContext.Users
                   where
                   (
                       from t in DataContext.TenantUserRoles
                       where t.TenantId == tenantId
                             && t.RoleId == roleId
                       select t.UserId
                   ).Contains(c.Id)
                   select c;
        }

        protected virtual IQueryable<User> UserMemberQuery(Guid tenantId)
        {
            return from c in DataContext.Users
                   where
                   (
                       from t in DataContext.TenantUserRoles
                       where t.TenantId == tenantId
                       select t.UserId
                   ).Contains(c.Id)
                   select c;
        }

    }
}