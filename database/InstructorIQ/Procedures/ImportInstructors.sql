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
			D.[DisplayName] = S.[DisplayName],
			D.[GivenName] = S.[GivenName],
			D.[MiddleName] = S.[MiddleName],
			D.[FamilyName] = S.[FamilyName],
			D.[MobilePhone] = S.[PhoneNumber],
			D.[JobTitle] = S.[JobTitle]
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
