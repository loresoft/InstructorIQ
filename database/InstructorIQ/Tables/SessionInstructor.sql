CREATE TABLE [IQ].[SessionInstructor]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_SessionInstructor_Id] DEFAULT (NEWSEQUENTIALID()),

    [SessionId] UNIQUEIDENTIFIER NOT NULL,
    [InstructorId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_SessionInstructor] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SessionInstructor_Session_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [IQ].[Session]([Id]),
    CONSTRAINT [FK_SessionInstructor_Instructor_InstructorId] FOREIGN KEY ([InstructorId]) REFERENCES [IQ].[Instructor]([Id]),
)

GO
CREATE CLUSTERED INDEX [IX_SessionInstructor_SessionId_InstructorId]
ON [IQ].[SessionInstructor] ([SessionId] ASC, [InstructorId] ASC)
