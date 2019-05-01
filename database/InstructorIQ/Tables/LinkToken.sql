CREATE TABLE [IQ].[LinkToken]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_LinkToken_Id] DEFAULT (NEWSEQUENTIALID()),

    [TokenHashed] NVARCHAR(256) NOT NULL,

    [UserName] NVARCHAR(256) NOT NULL,
    [Url] NVARCHAR(MAX) NOT NULL,

    [TenantId] UNIQUEIDENTIFIER NOT NULL,

    [Issued] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_LinkToken_Issued] DEFAULT (SYSUTCDATETIME()),
    [Expires] DATETIMEOFFSET NULL,

    CONSTRAINT [PK_LinkToken] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LinkToken_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [IQ].[Tenant]([Id]),
)

GO
CREATE INDEX [IX_LinkToken_UserName]
    ON [IQ].[LinkToken] ([UserName])

GO
CREATE UNIQUE INDEX [UX_LinkToken_TokenHashed]
    ON [IQ].[LinkToken] ([TokenHashed])