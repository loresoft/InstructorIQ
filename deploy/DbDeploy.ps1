try
{    
    $packFile = Resolve-Path InstructorIQ.dacpac
    $publishFile = Resolve-Path publish.config

    #Register DLL, SQL Server 2017
    Add-Type -Path "${env:ProgramFiles(x86)}\Microsoft SQL Server\140\DAC\bin\Microsoft.SqlServer.Dac.dll" 

    Write-Host "Profile: $publishFile" 
    #Read publish profile XML to get the deployment options
    $dacProfile = [Microsoft.SqlServer.Dac.DacProfile]::Load($publishFile)

    #Use the connect string from the profile to initiate the service
    $dacService = New-Object Microsoft.SqlServer.dac.dacservices($dacProfile.TargetConnectionString)

    # register events
    register-objectevent -in $dacService -eventname Message -source "message" -action { Write-Host $Event.SourceArgs[1].Message.Message }

    Write-Host "Package: $packFile" 
    $dacPackage = [Microsoft.SqlServer.Dac.DacPackage]::Load($packFile)

    Write-Host "Publish: "$dacProfile.TargetConnectionString"Initial Catalog="$dacProfile.TargetDatabaseName
    $dacService.deploy($dacPackage, $dacProfile.TargetDatabaseName, $true, $dacProfile.DeployOptions)
}
catch
{
    exit -1
}
finally
{
    # clean up event
    unregister-event -source "message" -ErrorAction SilentlyContinue
}