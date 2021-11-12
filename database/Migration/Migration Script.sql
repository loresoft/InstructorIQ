DECLARE @membership TABLE
(
    [UserId] UNIQUEIDENTIFIER,
    [UserName] NVARCHAR(256),
    [TenantId] UNIQUEIDENTIFIER,
    [InstructorId] UNIQUEIDENTIFIER
);
DECLARE @roleName NVARCHAR(100) = 'Instructor'
DECLARE @roleId UNIQUEIDENTIFIER = '808c0ec0-39eb-e711-87c1-708bcd56aa6d'

--BEGIN TRANSACTION
ALTER TABLE [IQ].[Instructor] ADD [UserId] UNIQUEIDENTIFIER;
GO 
ALTER TABLE [IQ].[TenantUserRole] ADD [UserId] UNIQUEIDENTIFIER;
GO 
ALTER TABLE [IQ].[TenantUserRole] ADD [RoleId] UNIQUEIDENTIFIER;
GO 

-- set user id for instructors
UPDATE IQ.Instructor SET
    [UserId] = u.Id
FROM IQ.Instructor as i
INNER JOIN [Identity].[User] as u on u.Email = i.EmailAddress
WHERE i.UserId IS NULL

-- fix up tenent user role
UPDATE IQ.TenantUserRole SET
    [UserId] = u.Id
FROM IQ.TenantUserRole as i
INNER JOIN [Identity].[User] as u on u.UserName = i.UserName
WHERE i.UserId IS NULL

UPDATE IQ.TenantUserRole SET
    [RoleId] = r.Id
FROM IQ.TenantUserRole as i
INNER JOIN [Identity].[Role] as r on r.Name = i.RoleName
WHERE i.RoleId IS NULL



-- ensure user for all instructors
MERGE [Identity].[User] WITH (ROWLOCK) AS D
USING 
(
    SELECT 
        [Id],
        [GivenName],
        [MiddleName],
        [FamilyName],
        [JobTitle],
        [EmailAddress] as [Email],
        [MobilePhone] as [PhoneNumber],
        IIF([DisplayName] IS NULL, LTRIM(RTRIM([GivenName] + ' ' + [FamilyName])), [DisplayName]) AS [DisplayName],
        IIF([SortName] IS NULL, [DisplayName], [SortName]) AS [SortName],
        [TenantId],
        [UserId]
    FROM [IQ].[Instructor]
    WHERE [UserId] IS NULL
) 
AS S
    ON D.[Id] = S.[UserId]
WHEN NOT MATCHED THEN
    INSERT
    (
        [Email],
        [NormalizedEmail],
        [UserName],
        [NormalizedUserName],
        [PhoneNumber],
        [GivenName],
        [MiddleName],
        [FamilyName],
        [DisplayName],
        [SortName],
        [JobTitle],
        [LastTenantId]
    )
    VALUES
    (
        S.[Email],
        UPPER(S.[Email]),
        S.[Email],
        UPPER(S.[Email]),
        S.[PhoneNumber],
        S.[GivenName],
        S.[MiddleName],
        S.[FamilyName],
        s.[DisplayName],
        s.[SortName],
        S.[JobTitle],
        S.[TenantId]
    )
OUTPUT
    inserted.[Id] AS UserId,
    inserted.[UserName],
    S.[TenantId],
    S.[Id] AS InstructorId
INTO @membership;


-- add instructor role for users
MERGE [IQ].[TenantUserRole] WITH (ROWLOCK) AS D
USING @membership AS S
    ON D.[TenantId] = S.[TenantId]
        AND D.[UserId] = S.[UserId] 
        AND D.[RoleId] = @roleId
WHEN NOT MATCHED THEN
    INSERT
    (
        [TenantId],
        [UserId],
        [RoleId]
    )
    VALUES
    (
        S.[TenantId],
        S.[UserId],
        @roleId
    );

-- update instructor user id
MERGE [IQ].[Instructor] WITH (ROWLOCK) AS D
USING @membership AS S
    ON D.[TenantId] = S.[TenantId]
        AND D.[Id] = S.[InstructorId] 
WHEN MATCHED THEN
    UPDATE SET D.[UserId] = S.[UserId];


-- drop fkeys for instructor

ALTER TABLE [IQ].[Topic] 
DROP CONSTRAINT [FK_Topic_Instructor_LeadInstructorId]
GO

EXEC sp_rename 'IQ.Topic.LeadInstructorId', 'old_LeadInstructorId', 'COLUMN';
GO

ALTER TABLE [IQ].[Topic] ADD [LeadInstructorId] UNIQUEIDENTIFIER;
GO 

UPDATE [IQ].[Topic] SET
    LeadInstructorId = I.UserId
FROM [IQ].[Topic] AS T
INNER JOIN [IQ].[Instructor] AS I ON I.Id = T.old_LeadInstructorId
GO

ALTER TABLE [IQ].[Topic]
ADD CONSTRAINT [FK_Topic_Instructor_LeadInstructorId] 
FOREIGN KEY ([LeadInstructorId]) REFERENCES [Identity].[User]([Id])
GO 


ALTER TABLE [IQ].[Session] 
DROP CONSTRAINT [FK_Session_Instructor_LeadInstructorId]
GO

EXEC sp_rename 'IQ.Session.LeadInstructorId', 'old_LeadInstructorId', 'COLUMN';
GO

ALTER TABLE [IQ].[Session] ADD [LeadInstructorId] UNIQUEIDENTIFIER;
GO 

UPDATE [IQ].[Session] SET
    LeadInstructorId = I.UserId
FROM [IQ].[Session] AS T
INNER JOIN [IQ].[Instructor] AS I ON I.Id = T.old_LeadInstructorId
GO

ALTER TABLE [IQ].[Session]
ADD CONSTRAINT [FK_Session_Instructor_LeadInstructorId] 
FOREIGN KEY ([LeadInstructorId]) REFERENCES [Identity].[User]([Id])



ALTER TABLE [IQ].[TopicInstructor] DROP CONSTRAINT [FK_TopicInstructor_Instructor_InstructorId]
GO

EXEC sp_rename 'IQ.TopicInstructor.InstructorId', 'old_InstructorId', 'COLUMN';
GO

ALTER TABLE [IQ].[TopicInstructor] ADD [InstructorId] UNIQUEIDENTIFIER;
GO

UPDATE [IQ].[TopicInstructor] SET
    InstructorId = I.UserId
FROM [IQ].[TopicInstructor] AS T
INNER JOIN [IQ].[Instructor] AS I ON I.Id = T.old_InstructorId
GO

ALTER TABLE [IQ].[TopicInstructor]
ADD CONSTRAINT [FK_TopicInstructor_Instructor_InstructorId] 
FOREIGN KEY ([InstructorId]) REFERENCES [Identity].[User]([Id])
GO 



ALTER TABLE [IQ].[SessionInstructor] DROP CONSTRAINT [FK_SessionInstructor_Instructor_InstructorId]
GO

EXEC sp_rename 'IQ.SessionInstructor.InstructorId', 'old_InstructorId', 'COLUMN';
GO

ALTER TABLE [IQ].[SessionInstructor] ADD [InstructorId] UNIQUEIDENTIFIER;
GO

UPDATE [IQ].[SessionInstructor] SET
    InstructorId = I.UserId
FROM [IQ].[SessionInstructor] AS T
INNER JOIN [IQ].[Instructor] AS I ON I.Id = T.old_InstructorId
GO

ALTER TABLE [IQ].[SessionInstructor]
ADD CONSTRAINT [FK_SessionInstructor_Instructor_InstructorId] 
FOREIGN KEY ([InstructorId]) REFERENCES [Identity].[User]([Id])
GO 


--COMMIT