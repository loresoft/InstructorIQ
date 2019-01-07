﻿CREATE TABLE [IQ].[Role]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Role_Id] DEFAULT (NEWSEQUENTIALID()),
    [Name] NVARCHAR(256) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Role_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Role_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Role] PRIMARY KEY NONCLUSTERED ([Id] ASC),
)

GO
CREATE UNIQUE INDEX [UX_Role_Name]
ON [IQ].[Role] ([Name])