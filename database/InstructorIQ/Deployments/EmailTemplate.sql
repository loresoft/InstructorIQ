-- Table [IQ].[EmailTemplate] data

MERGE INTO [IQ].[EmailTemplate] AS t
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
</html>', 
        NULL
    ), 
    (
        '02b4bee4-c75b-e911-aa7c-5cf3708ff0fb', 
        'passwordless-login', 
        'noreply@InstructorIQ.com', 
        'InstructorIQ', 
        NULL, 
        NULL, 
        'Login for InstructorIQ', 
        'You recently requested a login link for your InstructorIQ account. Please follow the link below to automaticly login to your account.

{{ LoginLink }}

Note: Your login link will expire in 15 minutes, and can only be used one time.

For security, this request was received from a {{ UserAgent.OperatingSystem }} device using {{ UserAgent.Browser }}. If you did not request a login link, please ignore this email.', 
        '<!DOCTYPE html>
<html>
<head>
</head>
<body style="font-family: Arial; font-size: 12px;">
<div>
    <p>You recently requested a login link for your InstructorIQ account. Please follow the link below to automaticly login to your account.</p>
    <p><a href="{{ LoginLink }}">Login to InstructorIQ</a></p>
    <p>Note: Your login link will expire in 15 minutes and can only be used one time.</p>
    <p>For security, this request was received from a {{ UserAgent.OperatingSystem }} device using {{ UserAgent.Browser }}. If you did not request a login link, please ignore this email.</p>
    <p style="font-family: Arial; font-size: 10px;">
        If you’re having trouble with the link above, copy and paste the URL below into your web browser.<br />
        <br />
        {{ LoginLink }}<br />
    </p>
</div>
</body>
</html>', 
        NULL
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
    [HtmlBody], 
    [TenantId]
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
        [HtmlBody], 
        [TenantId]
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
        s.[HtmlBody], 
        s.[TenantId]
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
        t.[HtmlBody] = s.[HtmlBody], 
        t.[TenantId] = s.[TenantId]
OUTPUT $action as [Action];

