CREATE TYPE [IQ].[UserTableType] AS TABLE
(
    [Email]       NVARCHAR (256) NOT NULL,
    [DisplayName] NVARCHAR (256) NOT NULL,
    [GivenName]   NVARCHAR (256) NULL,
    [MiddleName]  NVARCHAR (256) NULL,
    [FamilyName]  NVARCHAR (256) NULL,
    [PhoneNumber] NVARCHAR (256) NULL,
    [JobTitle]    NVARCHAR (256) NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC)
);
