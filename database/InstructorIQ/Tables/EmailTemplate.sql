﻿CREATE TABLE [IQ].[EmailTemplate]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_EmailTemplate_Id] DEFAULT (NEWSEQUENTIALID()),
    [Key] NVARCHAR(100) NOT NULL,

    [FromAddress] NVARCHAR(256) NOT NULL,
    [FromName] NVARCHAR(256) NOT NULL,

    [ReplyToAddress] NVARCHAR(256) NULL,
    [ReplyToName] NVARCHAR(256) NULL,

    [Subject] NVARCHAR(MAX) NULL,
    [TextBody] NVARCHAR(MAX) NULL,
    [HtmlBody] NVARCHAR(MAX) NULL,

    [TenantId] UNIQUEIDENTIFIER NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_EmailTemplate_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_EmailTemplate_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_EmailTemplate] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmailTemplate_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)

GO
CREATE UNIQUE INDEX [UX_EmailTemplate_Key]
    ON [IQ].[EmailTemplate] ([Key])

GO
CREATE INDEX [IX_EmailTemplate_TenantId]
    ON [IQ].[EmailTemplate] ([TenantId])
