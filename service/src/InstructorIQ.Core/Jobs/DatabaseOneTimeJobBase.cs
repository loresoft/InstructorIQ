using InstructorIQ.Core.Data;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Jobs
{
    public abstract class DatabaseOneTimeJobBase : OneTimeJobBase
    {

        protected InstructorIQContext DataContext { get; }

        protected DatabaseOneTimeJobBase(ILoggerFactory loggerFactory, InstructorIQContext dataContext)
            : base(loggerFactory)
        {
            DataContext = dataContext;
        }
    }
}