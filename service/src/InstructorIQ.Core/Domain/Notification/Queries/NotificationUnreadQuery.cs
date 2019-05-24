using System;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class NotificationUnreadQuery : PrincipalQueryBase<NotificationUnreadModel>
    {
        public NotificationUnreadQuery(IPrincipal principal, string userName, Guid tenantId) : base(principal)
        {
            UserName = userName;
            TenantId = tenantId;
        }

        public string UserName { get; }

        public Guid TenantId { get; }
    }
}
