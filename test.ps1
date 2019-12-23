Param(
    [string]$version = $env:APPVEYOR_BUILD_VERSION
)

$workingDirectory = Resolve-Path -Path .\
$buildDirectory = Join-Path -Path $workingDirectory -ChildPath "build"

$connectionString = "Data Source=(local);Initial Catalog=InstructorIQUnitTest;Integrated Security=True"
If ((Test-Path -Path env:APPVEYOR)) {
    $connectionString = "Server=(local)\\SQL2017;Database=InstructorIQUnitTest;Integrated security=SSPI;"
}  

Write-Host "*** Deploy Database ***"
& SqlPackage.exe `
    /Action:Publish `
    /SourceFile:"$buildDirectory\database\InstructorIQ.dacpac" `
    /TargetConnectionString:"$connectionString"

Write-Host "*** Running Tests ***"
& dotnet test service\InstructorIQ.sln `
    --configuration Release `
    /p:CollectCoverage=true `
    /p:CoverletOutputFormat=opencover `
    /p:Exclude="[xunit*]*"