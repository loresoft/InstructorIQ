using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Services;

using MediatR.CommandQuery.EntityFrameworkCore.Handlers;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberImportProcessCommandHandler : DataContextHandlerBase<InstructorIQContext, MemberImportProcessCommand, MemberImportJobModel>
    {
        private readonly IImportProcessService _importProcessService;

        public MemberImportProcessCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, IImportProcessService importProcessService)
            : base(loggerFactory, dataContext, mapper)
        {
            _importProcessService = importProcessService;
        }

        protected override async Task<MemberImportJobModel> Process(MemberImportProcessCommand request, CancellationToken cancellationToken)
        {
            var id = request.Import.Id;
            var importJob = await DataContext.ImportJobs.FindAsync(id);
            if (importJob == null)
                return null;

            var mappingJson = JsonConvert.SerializeObject(request.Import);
            var identityName = request.Principal?.Identity?.Name;

            importJob.Updated = DateTimeOffset.UtcNow;
            importJob.UpdatedBy = identityName;
            importJob.MappingJson = mappingJson;

            await DataContext.SaveChangesAsync(cancellationToken);

            await _importProcessService.ImportMembersAsync(id);

            return request.Import;
        }
    }
}
