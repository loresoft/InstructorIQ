Param(
    [string]$version = $env:APPVEYOR_BUILD_VERSION
)

$workingDirectory = Resolve-Path -Path .\
$buildDirectory = Join-Path -Path $workingDirectory -ChildPath "build"

If ((Test-Path -Path $buildDirectory)) {
    Remove-Item $buildDirectory -Recurse -Force
}
Else {
    New-Item -ItemType Directory -Force -Path $buildDirectory
}

If (!$version) {
    $version = "1.0.0.0"
}

# build client
Write-Host "*** Build Client ***"

Push-Location $workingDirectory\client\

& npm install aurelia-cli -g
& npm install
& au build --env prod

Pop-Location

# build database
Write-Host "*** Build Database ***"
& msbuild $workingDirectory\database\InstructorIQ.sln /t:Build /p:Configuration=Release  /p:OutputPath=$buildDirectory\database

# build service
Write-Host "*** Build Service ***"
& dotnet publish $workingDirectory\service\src\InstructorIQ.Web\InstructorIQ.Web.csproj -c Release -o $buildDirectory\website
& dotnet publish $workingDirectory\service\src\InstructorIQ.JobRunner\InstructorIQ.JobRunner.csproj -c Release -o $buildDirectory\runner

# create package
Write-Host "*** Create Packages ***"
Copy-Item -Path $workingDirectory\client\dist -Destination $buildDirectory\website\wwwroot -recurse -Force
Copy-Item -Path $buildDirectory\runner -Destination $buildDirectory\website\App_Data\jobs\continuous\runner -recurse -Force

# zip package
Write-Host "*** Zip Packages ***"
Compress-Archive -Path $buildDirectory\website\* -DestinationPath $buildDirectory\InstructorIQ.Website.$version.zip
Compress-Archive -Path $buildDirectory\database\* -DestinationPath $buildDirectory\InstructorIQ.Database.$version.zip

# deployment package
Write-Host "*** Deployment Packages ***"
& nuget pack $workingDirectory\deploy\InstructorIQ.Website.Deploy.nuspec -BasePath $workingDirectory -Version $version -OutputDirectory $buildDirectory -NoPackageAnalysis
& nuget pack $workingDirectory\deploy\InstructorIQ.Database.Deploy.nuspec -BasePath $workingDirectory -Version $version -OutputDirectory $buildDirectory -NoPackageAnalysis