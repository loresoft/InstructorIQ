using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using XUnit.Hosting;

namespace InstructorIQ.Core.Tests;

public class DependencyInjectionFixture : TestHostFixture
{
    protected override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddTransient<ITenant<TenantReadModel>>(provider => new TenantValue<TenantReadModel>(new TenantReadModel
        {
            Id = Data.Constants.Tenant.Test,
            Slug = "Test",
            Name = "Test"
        }));

        services.AddUrlHelper();

        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<InstructorIQContext>()
            .AddDefaultTokenProviders();

        services.AddInstructorIQCore();
    }
}
