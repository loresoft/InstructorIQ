using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class TenantUserResolveCommandHandler : DataContextHandlerBase<InstructorIQContext, TenantUserResolveCommand, TenantUserModel>
    {
        public TenantUserResolveCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<TenantUserModel> Process(TenantUserResolveCommand message, CancellationToken cancellationToken)
        {
            var user = message.User;
            var tenant = await GetTenant(user, cancellationToken);
            var roles = await GetRoles(user, tenant, cancellationToken);

            await UpdateUser(user, tenant, cancellationToken);

            var model = new TenantUserModel { User = user, Tenant = tenant, Roles = roles };

            return model;
        }

        private async Task UpdateUser(User user, TenantReadModel tenant, CancellationToken cancellationToken)
        {
            if (tenant == null || user.LastTenantId == tenant.Id)
                return;

            var currentUser = await DataContext.Users
                .FindAsync(user.Id);

            currentUser.LastTenantId = tenant.Id;
            user.LastTenantId = tenant.Id;

            await DataContext.SaveChangesAsync(cancellationToken);
        }

        private async Task<List<string>> GetRoles(User user, TenantReadModel tenant, CancellationToken cancellationToken)
        {
            if (user == null || tenant == null)
                return null;

            var roles = await DataContext.TenantUserRoles
                .AsNoTracking()
                .Where(u => u.TenantId == tenant.Id && u.UserName == user.UserName)
                .Select(o => o.RoleName)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return roles;
        }

        private async Task<TenantReadModel> GetTenant(User user, CancellationToken cancellationToken, Guid? id = null)
        {
            TenantReadModel tenant;

            // first try by id
            if (id.HasValue)
            {
                tenant = await DataContext.Tenants
                    .AsNoTracking()
                    .Where(t => t.Id == id.Value)
                    .ProjectTo<TenantReadModel>(Mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken)
                    .ConfigureAwait(false);

                if (tenant != null && !tenant.IsDeleted)
                    return tenant;
            }

            if (user == null)
                return null;

            // next try last tenant
            if (user.LastTenantId.HasValue)
            {
                tenant = await DataContext.Tenants
                    .AsNoTracking()
                    .Where(t => t.Id == user.LastTenantId.Value)
                    .ProjectTo<TenantReadModel>(Mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken)
                    .ConfigureAwait(false);

                if (tenant != null && !tenant.IsDeleted)
                    return tenant;
            }

            // next try match email domain to tenant domain
            if (user.Email.HasValue())
            {
                var address = new MailAddress(user.Email);
                var domain = address.Host.Trim();

                tenant = await DataContext.Tenants
                    .AsNoTracking()
                    .Where(t => t.DomainName != null && t.DomainName == domain)
                    .ProjectTo<TenantReadModel>(Mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken)
                    .ConfigureAwait(false);

                if (tenant != null && !tenant.IsDeleted)
                    return tenant;

            }

            // finally try first tenant that user has membership for
            tenant = await DataContext.TenantUserRoles
                .AsNoTracking()
                .Where(u => u.UserName == user.UserName)
                .Select(o => o.Tenant)
                .ProjectTo<TenantReadModel>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            return tenant;
        }
    }
}