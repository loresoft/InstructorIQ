CREATE VIEW [IQ].[SessionCalendar]
    AS

SELECT
    s.[Id],

    s.[Note],

    s.[StartDate],
    s.[StartTime],
    s.[EndDate],
    s.[EndTime],

    s.[TenantId],
    tn.[Name] AS TenantName,

    s.[TopicId],
    tp.[Title] AS TopicTitle,
    tp.[IsRequired] AS TopicRequired,

    s.[LocationId],
    lc.[Name] AS LocationName,

    s.[GroupId],
    gr.[Name] AS GroupName,

    s.[LeadInstructorId],
    li.[DisplayName] AS LeadInstructorName,

    s.[Created],
    s.[CreatedBy],
    s.[Updated],
    s.[UpdatedBy],
    s.[RowVersion],

    (
        STUFF
        (
            (
                SELECT '; ' + i.[DisplayName]
                FROM [IQ].[Instructor] i
                INNER JOIN [IQ].[SessionInstructor] AS si ON i.[Id] = si.[InstructorId]
                WHERE si.[SessionId] = s.[Id]
                FOR XML PATH('')
            ),
            1, 2, ''
        )
    ) AS AdditionalInstructors

FROM [IQ].[Session] AS s
INNER JOIN [IQ].[Tenant] AS tn ON s.[TenantId] = tn.[Id]
INNER JOIN [IQ].[Topic] AS tp ON s.[TopicId] = tp.[Id]
LEFT OUTER JOIN [IQ].[Location] AS lc ON s.[LocationId] = lc.[Id]
LEFT OUTER JOIN [IQ].[Instructor] AS li ON s.[LeadInstructorId] = li.[Id]
LEFT OUTER JOIN [IQ].[Group] AS gr ON s.[GroupId] = gr.[Id];
