using System;
using System.Collections.Generic;
using System.Text;
using KickStart.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Jobs
{
    public class JobServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.AddTransient<IOneTimeJob, TopicSummaryOneTimeJob>();
        }
    }
}
