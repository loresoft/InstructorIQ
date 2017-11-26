CREATE TABLE [dbo].[InstructorOrganization]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_InstructorOrganization_Id] DEFAULT (newsequentialid()),
    [InstructorId] UNIQUEIDENTIFIER NOT NULL,
    [OrganizationId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_InstructorOrganization] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_InstructorOrganization_Instructor_InstructorId] FOREIGN KEY ([InstructorId]) REFERENCES [Instructor]([Id]),
    CONSTRAINT [FK_InstructorOrganization_Organization_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Organization]([Id]),
)

GO
CREATE CLUSTERED INDEX [IX_InstructorOrganization_InstructorId_OrganizationId]
ON [dbo].[InstructorOrganization] ([InstructorId] ASC, [OrganizationId] ASC)
