CREATE PROCEDURE [IQ].[ImportInstructors]
	@userTable [IQ].[UserTableType] READONLY,
	@tenantId UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON;

	MERGE [IQ].[Instructor] WITH (ROWLOCK) AS D
	USING @userTable AS S
		ON D.[EmailAddress] = S.[Email] AND D.[TenantId] = @tenantId
	WHEN MATCHED THEN
		UPDATE SET
			D.[DisplayName] = IIF(S.[DisplayName] IS NULL, D.[DisplayName], S.[DisplayName]),
			D.[GivenName] = IIF(S.[GivenName] IS NULL, D.[GivenName], S.[GivenName]),
			D.[MiddleName] = IIF(S.[MiddleName] IS NULL, D.[MiddleName], S.[MiddleName]),
			D.[FamilyName] = IIF(S.[FamilyName] IS NULL, D.[FamilyName], S.[FamilyName]),
			D.[MobilePhone] = IIF(S.[PhoneNumber] IS NULL, D.[MobilePhone], S.[PhoneNumber]),
			D.[JobTitle] = IIF(S.[JobTitle] IS NULL, D.[JobTitle], S.[JobTitle])
	WHEN NOT MATCHED THEN
		INSERT
		(
			[EmailAddress],
			[MobilePhone],
			[GivenName],
			[MiddleName],
			[FamilyName],
			[DisplayName],
			[JobTitle],
			[TenantId]
		)
		VALUES
		(
			S.[Email],
			S.[PhoneNumber],
			S.[GivenName],
			S.[MiddleName],
			S.[FamilyName],
			S.[DisplayName],
			S.[JobTitle],
			@tenantId
		);

END
