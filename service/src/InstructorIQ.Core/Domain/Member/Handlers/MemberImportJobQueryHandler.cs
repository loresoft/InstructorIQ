using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberImportJobQueryHandler : DataContextHandlerBase<InstructorIQContext, MemberImportJobQuery, MemberImportJobModel>
    {
        public MemberImportJobQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<MemberImportJobModel> Process(MemberImportJobQuery request, CancellationToken cancellationToken)
        {
            var importJob = await DataContext.ImportJobs.FindAsync(request.Id);
            if (importJob == null)
                return null;

            var importModel = JsonConvert.DeserializeObject<MemberImportJobModel>(importJob.MappingJson);

            return importModel;
        }
    }
}