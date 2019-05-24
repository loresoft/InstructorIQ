using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Services;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberImportUploadCommandHandler : DataContextHandlerBase<InstructorIQContext, MemberImportUploadCommand, MemberImportJobModel>
    {
        private readonly IStorageService _storageService;

        public MemberImportUploadCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, IStorageService storageService)
            : base(loggerFactory, dataContext, mapper)
        {
            _storageService = storageService;
        }

        protected override async Task<MemberImportJobModel> Process(MemberImportUploadCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var fileName = request.Upload.FileName ?? "upload.csv";
            fileName = Path.GetFileName(fileName);
            var storageFile = $"members/{id}/{fileName}";

            var importModel = new MemberImportJobModel { Id = id, Name = fileName };

            // need to upload and parse file, copy stream to memory
            using (var memoryStream = new MemoryStream())
            {
                await request.Upload.CopyToAsync(memoryStream, cancellationToken);

                // upload file
                await StoreFile(storageFile, memoryStream, cancellationToken);

                // parse csv
                ParseCsv(memoryStream, importModel);
            }

            await SaveImportJob(id, storageFile, request, importModel, cancellationToken);

            return importModel;
        }


        private async Task SaveImportJob(Guid id, string storageFile, MemberImportUploadCommand request, MemberImportJobModel importModel, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(importModel);

            // create job
            var identityName = request.Principal?.Identity?.Name;

            var importJob = new ImportJob
            {
                Id = id,
                Type = "MemberImport",
                TenantId = request.TenantId,
                StorageFile = storageFile,
                MappingJson = json,
                Created = DateTimeOffset.UtcNow,
                CreatedBy = identityName,
                Updated = DateTimeOffset.UtcNow,
                UpdatedBy = identityName
            };

            DataContext.ImportJobs.Add(importJob);
            await DataContext.SaveChangesAsync(cancellationToken);
        }

        private void ParseCsv(MemoryStream memoryStream, MemberImportJobModel importModel)
        {
            // reset stream
            memoryStream.Position = 0;

            var configuration = new Configuration { HasHeaderRecord = true };

            using (var reader = new StreamReader(memoryStream))
            using (var csv = new CsvReader(reader, configuration))
            {
                csv.Read();
                csv.ReadHeader();

                importModel.Headers = csv.Context.HeaderRecord;
            }

            // default match headers
            foreach (var header in importModel.Headers)
            {
                if (Regex.IsMatch(header, "first|given", RegexOptions.IgnoreCase))
                    importModel.GivenNameMapping = header;
                else if (Regex.IsMatch(header, "last|family", RegexOptions.IgnoreCase))
                    importModel.FamilyNameMapping = header;
                else if (Regex.IsMatch(header, "middle", RegexOptions.IgnoreCase))
                    importModel.MiddleNameMapping = header;
                else if (Regex.IsMatch(header, "^name|name$|dispay", RegexOptions.IgnoreCase))
                    importModel.DisplayNameMapping = header;
                else if (Regex.IsMatch(header, "email", RegexOptions.IgnoreCase))
                    importModel.EmailMapping = header;
                else if (Regex.IsMatch(header, "phone", RegexOptions.IgnoreCase))
                    importModel.PhoneNumberMapping = header;
                else if (Regex.IsMatch(header, "title|rank", RegexOptions.IgnoreCase))
                    importModel.JobTitleMapping = header;
            }
        }

        private async Task StoreFile(string blobName, MemoryStream memoryStream, CancellationToken cancellationToken)
        {
            // reset stream
            memoryStream.Position = 0;

            var blockBlob = _storageService.Container.GetBlockBlobReference(blobName);
            await blockBlob.UploadFromStreamAsync(memoryStream, cancellationToken);
        }
    }
}
