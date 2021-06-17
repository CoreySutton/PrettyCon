@echo off
@echo **************
@echo * Nuget Push *
@echo **************

set versionNumber=%1
set apiKey=%2
set currentDir=%cd%

cd "..\PrettyCon\bin\Debug"
nuget push CoreySutton.PrettyCon.%versionNumber%.nupkg -Source https://api.nuget.org/v3/index.json -Verbosity detailed -ApiKey %apiKey%

cd %currentDir%