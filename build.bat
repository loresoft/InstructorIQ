@echo off

@echo *** Build Client ***
pushd %APPVEYOR_BUILD_FOLDER%\client

call npm install aurelia-cli -g
call npm install
call au build --env prod

popd

@echo *** Build Database ***
msbuild %APPVEYOR_BUILD_FOLDER%\database\InstructorIQ.sln /t:Build /p:Configuration=Release  /p:OutputPath=%APPVEYOR_BUILD_FOLDER%

@echo *** Build Service ***
dotnet publish %APPVEYOR_BUILD_FOLDER%\service\src\InstructorIQ.Web\InstructorIQ.Web.csproj -c Release -o %APPVEYOR_BUILD_FOLDER%\publish 

@echo *** Zip Packages ***
7z a InstructorIQ.Client.v%APPVEYOR_BUILD_VERSION%.zip %APPVEYOR_BUILD_FOLDER%\client\dist\*
7z a InstructorIQ.Service.v%APPVEYOR_BUILD_VERSION%.zip %APPVEYOR_BUILD_FOLDER%\publish\*