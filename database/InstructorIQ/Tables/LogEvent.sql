CREATE TABLE [Log].[LogEvent]
(
    [TimeStamp] [datetime2] NOT NULL,
    [Level] [nvarchar](20) NULL,
    [Message] [nvarchar](max) NULL,
    [Exception] [nvarchar](max) NULL,
    [LogEvent] [nvarchar](max) NULL,

    CONSTRAINT [PK_LogEvent] PRIMARY KEY CLUSTERED ([TimeStamp] ASC)
)

GO
CREATE NONCLUSTERED INDEX [IX_LogEvent_Level]
    ON [Log].[LogEvent] ([Level])