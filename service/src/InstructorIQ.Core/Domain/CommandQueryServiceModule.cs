using AutoMapper;

using InstructorIQ.Core.Data;

using MediatR.CommandQuery;
using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Domain;


public class CommandQueryServiceModule
{

    [RegisterServices]
    public void Register(IServiceCollection services)
    {
        services.AddMediator();
        services.AddAutoMapper(_ => { }, typeof(InstructorIQContext).Assembly);
        services
            .AddOptions<MapperConfigurationExpression>()
            .Configure<IConfiguration>((options, configuration) => options.LicenseKey = configuration["AutoMapper:LicenseKey"]);
        services.AddValidatorsFromAssembly<InstructorIQContext>();
        services.AddEntityAudit();
    }
}
