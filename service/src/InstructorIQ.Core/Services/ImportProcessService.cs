using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using CsvHelper;
using CsvHelper.Configuration;

using FluentCommand;
using FluentCommand.Extensions;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

using MediatR;
using MediatR.CommandQuery.Commands;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using StringExtensions = InstructorIQ.Core.Extensions.StringExtensions;

namespace InstructorIQ.Core.Services;

public class ImportProcessService : IImportProcessService
{
    private readonly InstructorIQContext _context;
    private readonly IStorageService _storageService;
    private readonly IDataSession _dataSession;
    private readonly ILogger<ImportProcessService> _logger;
    private readonly IMediator _mediator;

    public ImportProcessService(InstructorIQContext context, IStorageService storageService, IDataSession dataSession, ILogger<ImportProcessService> logger, IMediator mediator)
    {
        _context = context;
        _storageService = storageService;
        _dataSession = dataSession;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task ImportMembersAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
    {
        ImportJob importJob = null;

        try
        {
            importJob = await _context.ImportJobs.FindAsync(id);
            if (importJob == null)
            {
                _logger.LogError("Invalid import job identifier: {id}", id);
                return;
            }

            var importModel = JsonConvert.DeserializeObject<MemberImportJobModel>(importJob.MappingJson);

            var dataList = await LoadData(importJob, importModel, cancellationToken);

            await ImportUsers(importJob, dataList, cancellationToken);

            var message = $"Processed member import request '{importModel.Name}'; Imported: {dataList.Count}";

            await SendNotification(importJob, message, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing import '{id}': {message}", id, ex.Message);

            if (importJob == null)
                throw;

            var message = $"Error Processing member import request; {ex.GetBaseException().Message}";
            await SendNotification(importJob, message, cancellationToken);

            throw;
        }
    }

    private async Task SendNotification(ImportJob importJob, string message, CancellationToken cancellationToken)
    {
        var createModel = new NotificationCreateModel
        {
            Created = DateTimeOffset.UtcNow,
            CreatedBy = importJob.CreatedBy,
            Updated = DateTimeOffset.UtcNow,
            UpdatedBy = importJob.CreatedBy,
            TenantId = importJob.TenantId,
            UserName = importJob.CreatedBy,
            Type = importJob.Type,
            Message = message
        };

        var command = new EntityCreateCommand<NotificationCreateModel, NotificationReadModel>(null, createModel);
        var result = await _mediator.Send(command, cancellationToken);
    }

    private async Task ImportUsers(ImportJob importJob, List<MemberImportModel> dataList, CancellationToken cancellationToken)
    {
        if (dataList.Count == 0)
        {
            _logger.LogWarning("No data to import");
            return;
        }

        var dataTable = dataList.ToDataTable();

        await _dataSession.StoredProcedure("[IQ].[ImportUsers]")
            .SqlParameter("@userTable", dataTable)
            .Parameter("@tenantId", importJob.TenantId)
            .Parameter("@roleName", Data.Constants.Role.MemberName)
            .ExecuteAsync(cancellationToken);
    }

    private async Task<List<MemberImportModel>> LoadData(ImportJob importJob, MemberImportJobModel importModel, CancellationToken cancellationToken)
    {
        var dataList = new List<MemberImportModel>();

        var configuration = new CsvConfiguration(CultureInfo.CurrentCulture) { HasHeaderRecord = true };

        using var blobStream = await _storageService.OpenReadAsync(importJob.StorageFile, cancellationToken);
        using var reader = new StreamReader(blobStream);
        using var csv = new CsvReader(reader, configuration);

        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            var item = new MemberImportModel();
            item.Email = csv.GetField(importModel.EmailMapping);

            if (StringExtensions.IsNullOrEmpty(item.Email))
                continue;

            if (StringExtensions.HasValue(importModel.DisplayNameMapping))
                item.DisplayName = csv.GetField(importModel.DisplayNameMapping);

            if (StringExtensions.HasValue(importModel.SortNameMapping))
                item.SortName = csv.GetField(importModel.SortNameMapping);

            if (StringExtensions.HasValue(importModel.GivenNameMapping))
                item.GivenName = csv.GetField(importModel.GivenNameMapping);

            if (StringExtensions.HasValue(importModel.FamilyNameMapping))
                item.FamilyName = csv.GetField(importModel.FamilyNameMapping);

            if (StringExtensions.HasValue(importModel.JobTitleMapping))
                item.JobTitle = csv.GetField(importModel.JobTitleMapping);

            if (StringExtensions.HasValue(importModel.PhoneNumberMapping))
                item.PhoneNumber = csv.GetField(importModel.PhoneNumberMapping);

            if (StringExtensions.IsNullOrEmpty(item.DisplayName))
                item.DisplayName = $"{item.GivenName} {item.FamilyName}".Trim();

            if (StringExtensions.IsNullOrEmpty(item.SortName))
                item.SortName = $"{item.FamilyName}, {item.GivenName}".Trim();

            dataList.Add(item);
        }

        return dataList;
    }
}
