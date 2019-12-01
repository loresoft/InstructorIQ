CREATE PROCEDURE [IQ].[ImportUsers]
	@userTable [IQ].[UserTableType] READONLY,
	@tenantId UNIQUEIDENTIFIER,
	@roleName NVARCHAR(100) = 'Member'
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @membership TABLE
	(
	   [UserName] NVARCHAR(256)
	);

	-- import users
	MERGE [Identity].[User] WITH (ROWLOCK) AS D
	USING @userTable AS S
		ON D.[Email] = S.[Email]
	WHEN MATCHED THEN
		UPDATE SET
			D.[DisplayName] = IIF(S.[DisplayName] IS NULL, D.[DisplayName], S.[DisplayName]),
			D.[SortName] = IIF(S.[SortName] IS NULL, D.[SortName], S.[SortName]),
			D.[GivenName] = IIF(S.[GivenName] IS NULL, D.[GivenName], S.[GivenName]),
			D.[MiddleName] = IIF(S.[MiddleName] IS NULL, D.[MiddleName], S.[MiddleName]),
			D.[FamilyName] = IIF(S.[FamilyName] IS NULL, D.[FamilyName], S.[FamilyName]),
			D.[PhoneNumber] = IIF(S.[PhoneNumber] IS NULL, D.[PhoneNumber], S.[PhoneNumber]),
			D.[JobTitle] = IIF(S.[JobTitle] IS NULL, D.[JobTitle], S.[JobTitle])
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
			S.[DisplayName],
			S.[SortName],
			S.[JobTitle],
			@tenantId
		)
	OUTPUT
	   inserted.[UserName]
	INTO @membership;

	--ensure membership
	MERGE [IQ].[TenantUserRole] WITH (ROWLOCK) AS D
	USING @membership AS S
		ON D.[UserName] = S.[UserName] 
			AND D.[TenantId] = @tenantId
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
			@tenantId,
			s.[UserName],
			@roleName
		);

END
