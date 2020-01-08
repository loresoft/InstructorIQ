using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvHelper;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Models
{
    public abstract class ExportModelBase : MediatorModelBase
    {
        protected ExportModelBase(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory) 
            : base(tenant, mediator, loggerFactory)
        {
        }

        public FileContentResult Export<T>(IEnumerable<T> items, string fileName)
        {
            byte[] buffer;

            var configuration = new CsvHelper.Configuration.Configuration { HasHeaderRecord = true };

            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream, Encoding.UTF8, 1024, true))
            using (var csv = new CsvWriter(writer, configuration))
            {
                csv.WriteRecords(items);
                writer.Flush();

                buffer = memoryStream.ToArray();
            }

            return File(buffer, "text/csv", fileName);
        }
    }
}