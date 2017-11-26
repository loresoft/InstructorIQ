using System;
using System.Collections.Generic;
using System.Text;
using KickStart.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Data
{
    public class DataServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfigurationRoot>();
            var connectionString = configuration.GetConnectionString("InstructorIQ");

            services.AddDbContext<InstructorIQContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
