CREATE TABLE [IQ].[RefreshToken]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_RefreshToken_Id] DEFAULT (NEWSEQUENTIALID()),

    [TokenHash] NVARCHAR(256) NOT NULL,

    [UserName] NVARCHAR(256) NOT NULL,

    [ClientId] NVARCHAR(450) NULL,
    [ProtectedTicket] NVARCHAR(MAX) NULL,

    [Issued] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_RefreshToken_Issued] DEFAULT (SYSUTCDATETIME()),
    [Expires] DATETIMEOFFSET NULL,

    CONSTRAINT [PK_RefreshToken] PRIMARY KEY NONCLUSTERED ([Id] ASC),
)

GO
CREATE INDEX [IX_RefreshToken_UserName]
    ON [IQ].[RefreshToken] ([UserName])

GO
CREATE UNIQUE INDEX [UX_RefreshToken_TokenHash]
    ON [IQ].[RefreshToken] ([TokenHash])
