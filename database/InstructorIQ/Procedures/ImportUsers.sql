CREATE PROCEDURE [IQ].[ImportUsers]
	@userTable [IQ].[UserTableType] READONLY,
	@tenantId UNIQUEIDENTIFIER,
	@roleName NVARCHAR(100) = 'Member'
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @membership TABLE
	(
	   [UserId] UNIQUEIDENTIFIER
	);
	DECLARE @roleId UNIQUEIDENTIFIER;

	SELECT TOP 1 @roleId = [Id]
	FROM [Identity].[Role]
	WHERE [Name] = @roleName

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
	   inserted.[Id]
	INTO @membership;

	--ensure membership
	MERGE [IQ].[TenantUserRole] WITH (ROWLOCK) AS D
	USING @membership AS S
		ON D.[UserId] = S.[UserId]
			AND D.[TenantId] = @tenantId
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
			@tenantId,
			s.[UserId],
			@roleId
		);

END
