using Injectio.Attributes;

using Microsoft.Extensions.DependencyInjection;

namespace InstructorIQ.Core.Jobs
{
    public class JobServiceModule
    {

        [RegisterServices]
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IOneTimeJob, TopicSummaryOneTimeJob>();
        }
    }
}
