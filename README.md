# PrinterServerTool

# PowerShellAPI:
Enviornment: 
Step:1 if you have windows 10 or below you machine has built in PowerShell with 3.1.0.0 version(cmdt) You need to setup powershel external way. This tools will work version 7.1.0.0 or later. Your windows menu will show you older version but also latest version will show you "PowerShell (version) + '64 or 84'".
Step 2: You need two nuget package: a) System.Management.Automation (need to follow the powershell verion), b) Microsoft.PowerShell.SDK (Same version.)
Step 3: If you use in the query Get-WMIObject - its mean that you are using build in powershell which is below 4.0.0.0. Latest powershell will give the query of Get-CimInstance. Its mean that you are using Powershell 7.0.0.0 or later version.
