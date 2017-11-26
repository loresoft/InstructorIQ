CREATE TABLE [dbo].[SessionInstructor]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_SessionInstructor_Id] DEFAULT (newsequentialid()),

    [SessionId] UNIQUEIDENTIFIER NOT NULL,
    [InstructorId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_SessionInstructor] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SessionInstructor_Session_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [Session]([Id]),
    CONSTRAINT [FK_SessionInstructor_Instructor_InstructorId] FOREIGN KEY ([InstructorId]) REFERENCES [Instructor]([Id]),
)

GO
CREATE CLUSTERED INDEX [IX_SessionInstructor_SessionId_InstructorId]
ON [dbo].[SessionInstructor] ([SessionId] ASC, [InstructorId] ASC)
