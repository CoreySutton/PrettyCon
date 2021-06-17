@echo off
@echo **************
@echo * Nuget Pack *
@echo **************

cd "..\PrettyCon"
nuget pack -Build -OutputDirectory "Nuget Packages" -Verbosity detailed