@echo off

pushd %APPVEYOR_BUILD_FOLDER%\client

call npm install aurelia-cli -g
call npm install
call au build --env prod

popd

dotnet publish %APPVEYOR_BUILD_FOLDER%\service\src\InstructorIQ.Web\InstructorIQ.Web.csproj -c Release -o %APPVEYOR_BUILD_FOLDER%\publish 

7z a InstructorIQ.Client.v%APPVEYOR_BUILD_VERSION%.zip %APPVEYOR_BUILD_FOLDER%\client\dist\*
7z a InstructorIQ.Service.v%APPVEYOR_BUILD_VERSION%.zip %APPVEYOR_BUILD_FOLDER%\publish\*