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
    Register-ObjectEvent -InputObject $dacService -EventName "ProgressChanged" -SourceIdentifier "ProgressChanged" -Action { Write-Verbose ("DacServices: {0}" -f $EventArgs.Message) } | Out-Null
    Register-ObjectEvent -InputObject $dacService -EventName "Message" -SourceIdentifier "Message" -Action { Write-Host ($EventArgs.Message.Message) } | Out-Null

    Write-Host "Package: $packFile" 
    $dacPackage = [Microsoft.SqlServer.Dac.DacPackage]::Load($packFile)

    Write-Host "Publish: "$dacProfile.TargetConnectionString"Initial Catalog="$dacProfile.TargetDatabaseName
    $dacService.deploy($dacPackage, $dacProfile.TargetDatabaseName, $true, $dacProfile.DeployOptions)
}
catch
{
    Write-Error $PSItem.ToString()
    exit -1
}
finally
{
    # clean up event
    Unregister-Event -SourceIdentifier "ProgressChanged" -ErrorAction SilentlyContinue
    Unregister-Event -SourceIdentifier "Message" -ErrorAction SilentlyContinue
}