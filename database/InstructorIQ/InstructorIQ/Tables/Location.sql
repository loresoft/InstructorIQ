CREATE TABLE [dbo].[Location]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Location_Id] DEFAULT (newsequentialid()),
    [Name] NVARCHAR(256) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,

    [AddressLine1] nvarchar(256) NULL,
    [AddressLine2] nvarchar(256) NULL,
    [AddressLine3] nvarchar(256) NULL,
    [City] nvarchar(150) NULL,
    [StateProvince]  nvarchar(150) NULL,
    [PostalCode] nvarchar(50) NULL,

    [Latitude] decimal(20,10) NULL,
    [Longitude] decimal(20,10) NULL,

    [OrganizationId] UNIQUEIDENTIFIER NOT NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Location_Created] DEFAULT (sysutcdatetime()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Location_Updated] DEFAULT (sysutcdatetime()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Location] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Location_Organization_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Organization]([Id]),
)

GO
CREATE INDEX [IX_Location_Name]
ON [dbo].[Location] ([Name])

GO
CREATE INDEX [IX_Location_OrganizationId]
ON [dbo].[Location] ([OrganizationId])
