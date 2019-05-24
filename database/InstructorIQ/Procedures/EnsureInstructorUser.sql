CREATE PROCEDURE [IQ].[EnsureInstructorUser]
	@instructorId UNIQUEIDENTIFIER,
	@roleName NVARCHAR(100) = 'Instructor'
AS
BEGIN

	SET NOCOUNT ON;
	DECLARE @membership TABLE
	(
	   [UserName] NVARCHAR(256),
	   [TenantId] UNIQUEIDENTIFIER
	);

	MERGE [Identity].[User] WITH (ROWLOCK) AS D
	USING 
	(
		SELECT 
			[GivenName],
			[MiddleName],
			[FamilyName],
			[JobTitle],
			[EmailAddress] as [Email],
			[MobilePhone] as [PhoneNumber],
			LTRIM(RTRIM([GivenName] + ' ' + [FamilyName])) AS [DisplayName],
			[TenantId]
		FROM [IQ].[Instructor]
		WHERE [Id] = @instructorId
			AND [EmailAddress] IS NOT NULL
	) 
	AS S
		ON D.[Email] = S.[Email]
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
			S.[JobTitle],
			S.[TenantId]
		)
	OUTPUT
	   inserted.[UserName],
	   inserted.[LastTenantId]
	INTO @membership;


	--ensure membership
	MERGE [IQ].[TenantUserRole] WITH (ROWLOCK) AS D
	USING @membership AS S
		ON D.[UserName] = S.[UserName] 
			AND D.[TenantId] = S.[TenantId]
			AND D.[RoleName] = @roleName
	WHEN NOT MATCHED THEN
		INSERT
		(
			[TenantId],
			[UserName],
			[RoleName]
		)
		VALUES
		(
			S.[TenantId],
			S.[UserName],
			@roleName
		);
END