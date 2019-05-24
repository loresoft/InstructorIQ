using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
    public class ExportModel : MediatorModelBase
    {
        public ExportModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var command = new MemberExportQuery(User, Tenant.Value.Id);
            var members = await Mediator.Send(command);

            byte[] buffer;

            var configuration = new CsvHelper.Configuration.Configuration { HasHeaderRecord = true };
            
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream, Encoding.UTF8, 1024, true))
            using (var csv = new CsvWriter(writer, configuration))
            {
                csv.WriteRecords(members);
                writer.Flush();

                buffer = memoryStream.ToArray();
            }
            
            var fileName = $"Members-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.csv";
            return File(buffer, "text/csv", fileName);
        }
    }
}