iisreset /stop
dotnet build -c release -o C:\Temp\BuildAlunosMVC
dotnet publish -c Release -o C:\publish\BuildAlunosMVC

    # $appPool = Get-WebAppPool -Name "AlunoMVCPool"
    # if ($appPool -ne $null)
    # {
    #     Write-Host "Pool de aplicativo já existe!"
    # }
    # else
    # {
    #     New-WebAppPool -Name AlunoMVCPool -.ManagedPipelineMode Integrated
    # }
import-module webadministration

$AppPoolName="AlunoMVCPool"

if(Test-Path IIS:\AppPools\$AppPoolName)
{
    Write-Host "Pool de aplicativo já existe!"
}
else
{
    "AppPool is not present"
    "Creating new AppPool"
    New-WebAppPool "$AppPoolName" -Force
}
    
New-WebSite -Name "AlunoMVC" -PhysicalPath "C:\publish\BuildAlunosMVC" -Port 8080 -ApplicationPool AlunoMVCPool -Force 


iisreset /start

