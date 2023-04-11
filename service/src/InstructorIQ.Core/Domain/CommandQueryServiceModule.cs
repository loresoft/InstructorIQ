using Injectio.Attributes;

using InstructorIQ.Core.Data;

using MediatR.CommandQuery.Audit;
using MediatR.CommandQuery.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Domain;


public class CommandQueryServiceModule
{

    [RegisterServices]
    public void Register(IServiceCollection services)
    {
        services.AddMediator();
        services.AddAutoMapper(typeof(InstructorIQContext).Assembly);
        services.AddValidatorsFromAssembly<InstructorIQContext>();
        services.AddEntityAudit();
    }
}
