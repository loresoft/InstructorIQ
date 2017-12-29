-- Table [EmailTemplate] data

MERGE INTO [EmailTemplate] AS t
USING
(
    VALUES
    (
        '855daac8-cbdf-e711-87bf-708bcd56aa6d',
        'reset-password',
        'noreply@InstructorIQ.com',
        'InstructorIQ',
        NULL,
        NULL,
        'Reset your password for InstructorIQ',
        'You recently requested to reset your password for your InstructorIQ account. Please follow the link below to reset your password

{{ ResetLink }}

For security, this request was received from a {{ UserAgent.OperatingSystem }} device using {{ UserAgent.Browser }}. If you did not request a password reset, please ignore this email.',
        '<!DOCTYPE html>
<html>
<head>
</head>
<body style="font-family: Arial; font-size: 12px;">
<div>
    <p>You recently requested to reset your password for your InstructorIQ account. Please follow the link below to reset your password</p>
    <p><a href="{{ ResetLink }}">Follow this link to reset your password.</a></p>
    <p>For security, this request was received from a {{ UserAgent.OperatingSystem }} device using {{ UserAgent.Browser }}. If you did not request a password reset, please ignore this email.</p>
    <p style="font-family: Arial; font-size: 10px;">
        If you’re having trouble with the link above, copy and paste the URL below into your web browser.<br />
        <br />
        {{ ResetLink }}<br />
    </p>
</div>
</body>
</html>'
    )
)
AS s
(
    [Id],
    [Key],
    [FromAddress],
    [FromName],
    [ReplyToAddress],
    [ReplyToName],
    [Subject],
    [TextBody],
    [HtmlBody]
)
ON
(
    t.[Id] = s.[Id]
)
WHEN NOT MATCHED BY TARGET THEN
    INSERT
    (
        [Id],
        [Key],
        [FromAddress],
        [FromName],
        [ReplyToAddress],
        [ReplyToName],
        [Subject],
        [TextBody],
        [HtmlBody]
    )
    VALUES
    (
        s.[Id],
        s.[Key],
        s.[FromAddress],
        s.[FromName],
        s.[ReplyToAddress],
        s.[ReplyToName],
        s.[Subject],
        s.[TextBody],
        s.[HtmlBody]
    )
WHEN MATCHED THEN
    UPDATE SET
        t.[Key] = s.[Key],
        t.[FromAddress] = s.[FromAddress],
        t.[FromName] = s.[FromName],
        t.[ReplyToAddress] = s.[ReplyToAddress],
        t.[ReplyToName] = s.[ReplyToName],
        t.[Subject] = s.[Subject],
        t.[TextBody] = s.[TextBody],
        t.[HtmlBody] = s.[HtmlBody]
OUTPUT $action as [Action];

