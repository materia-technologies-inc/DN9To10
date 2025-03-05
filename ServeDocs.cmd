@echo on
if exist ".artifacts/Materia.Blazor.Api" rd ".artifacts/Materia.Blazor.Api" /s /q
if exist ".artifacts/SiteDocFx" rd ".artifacts/SiteDocFx" /s /q
rem dotnet tool install --global --version 2.77.0 docfx
dotnet build Materia.Blazor/Materia.Blazor.csproj --configuration Server
docfx docfx.json --serve
