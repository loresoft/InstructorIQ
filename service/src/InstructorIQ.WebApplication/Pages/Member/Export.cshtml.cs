using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CsvHelper;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Member
{
    public class ExportModel : ExportModelBase
    {
        private readonly IMapper _mapper;

        public ExportModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, IMapper mapper)
            : base(tenant, mediator, loggerFactory)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var command = new MemberSelectQuery(User, Tenant.Value.Id);
            var members = await Mediator.Send(command);
            var exported = _mapper.Map<List<MemberImportModel>>(members);

            var fileName = $"Members-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.csv";
            
            return Export(exported, fileName);
        }
    }
}