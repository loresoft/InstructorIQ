﻿CREATE TABLE [IQ].[SessionGroup]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_SessionGroup_Id] DEFAULT (NEWSEQUENTIALID()),

    [SessionId] UNIQUEIDENTIFIER NOT NULL,
    [GroupId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_SessionGroup] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SessionGroup_Session_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [IQ].[Session]([Id]),
    CONSTRAINT [FK_SessionGroup_Group_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [IQ].[Group]([Id]),
)

GO
CREATE CLUSTERED INDEX [IX_SessionGroup_SessionId_GroupId]
ON [IQ].[SessionGroup] ([SessionId] ASC, [GroupId] ASC)
