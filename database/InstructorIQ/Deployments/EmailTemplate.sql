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
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Reset Password for InstructorIQ</title>
</head>
<body style="font-family: Arial, ''Helvetica Neue'', Helvetica, sans-serif; font-size: 16px;">
<div>
    <p style="font-size: 16px; line-height: 1.5em; ">You recently requested to reset your password for your InstructorIQ account. Please follow the link below to reset your password</p>
    <table width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0">
                    <tr>
                        <td bgcolor="#2e8a96">
                            <a href="{{ ResetLink }}" target="_blank" style="padding:8px 12px;border:1px solid #2e8a96;font-family:Helvetica,Arial,sans-serif;font-size:14px;color:#fff;text-decoration:none;font-weight:700;display:inline-block;">
                                Reset your password             
                            </a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <p style="font-size: 16px; line-height: 1.5em; ">Note: Your reset link will expire in 24 hours and can only be used one time.</p>
    <p style="font-size: 16px; line-height: 1.5em; ">For security, this request was received from a {{ UserAgent.OperatingSystem }} device using {{ UserAgent.Browser }}. If you did not request a password reset, please ignore this email.</p>
    <hr>
    <p style="font-size: 10px;">
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
        'Login Link for InstructorIQ', 
        'You recently requested a login link for your InstructorIQ account. Please follow the link below to automatically login to your account.

{{ LoginLink }}

Note: Your login link will expire in 4 hours, and can only be used one time.

For security, this request was received from a {{ UserAgent.OperatingSystem }} device using {{ UserAgent.Browser }}. If you did not request a login link, please ignore this email.', 
        '<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>Login Link for InstructorIQ</title>
</head>
<body style="font-family: Arial, ''Helvetica Neue'', Helvetica, sans-serif; font-size: 16px;">
<div>
    <p style="font-size: 16px; line-height: 1.5em; ">You recently requested a login link for your InstructorIQ account. Please follow the link below to automatically login to your account.</p>
    <table width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0">
                    <tr>
                        <td bgcolor="#2e8a96">
                            <a href="{{ LoginLink }}" target="_blank" style="padding:8px 12px;border:1px solid #2e8a96;font-family:Helvetica,Arial,sans-serif;font-size:14px;color:#fff;text-decoration:none;font-weight:700;display:inline-block;">
                                Login to InstructorIQ             
                            </a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <p style="font-size: 16px; line-height: 1.5em; ">Note: Your login link will expire in 4 hours and can only be used one time.</p>
    <p style="font-size: 16px; line-height: 1.5em; ">For security, this request was received from a {{ UserAgent.OperatingSystem }} device using {{ UserAgent.Browser }}. If you did not request a login link, please ignore this email.</p>
    <hr>
    <p style="font-size: 10px;">
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

