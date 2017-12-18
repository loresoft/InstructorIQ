CREATE TABLE [dbo].[Instructor]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Instructor_Id] DEFAULT (NEWSEQUENTIALID()),

    [GivenName] nvarchar(256) NOT NULL,
    [MiddleName] nvarchar(256) NULL,
    [FamilyName] nvarchar(256) NOT NULL,

    [JobTitle] nvarchar(256) NULL,

    [EmailAddress] nvarchar(256) NOT NULL,
    [MobilePhone] nvarchar(50) NOT NULL,
    [BusinessPhone] nvarchar(50) NULL,

    [UserId] UNIQUEIDENTIFIER NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Instructor_Created] DEFAULT (SYSUTCDATETIME()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Instructor_Updated] DEFAULT (SYSUTCDATETIME()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Instructor] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Instructor_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
)

GO
CREATE INDEX [IX_Instructor_EmailAddress]
ON [dbo].[Instructor] ([EmailAddress])

GO
CREATE INDEX [IX_Instructor_UserId]
ON [dbo].[Instructor] ([UserId])

