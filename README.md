# PrinterServerTool

# PowerShellAPI:
Enviornment: 
Step:1 if you have windows 10 or below you machine has built in PowerShell with 3.1.0.0 version(cmdt) You need to setup powershel external way. This tools will work version 7.1.0.0 or later. Your windows menu will show you older version but also latest version will show you "PowerShell (version) + '64 or 84'".
Step 2: You need two nuget package: a) System.Management.Automation (need to follow the powershell verion), b) Microsoft.PowerShell.SDK (Same version.)
Step 3: If you use in the query Get-WMIObject - its mean that you are using build in powershell which is below 4.0.0.0. Latest powershell will give the query of Get-CimInstance. Its mean that you are using Powershell 7.0.0.0 or later version.

# Remote Desktop Activated:
Remote desktop need to activated in your system. Home edition version is not possible to activated. 
How to activated Remote Desktop: Setting > System > scroll down left will see Remote Desktop > need to ON(normally its always off.)

# How to save credential in your project:
Right button of project > properties > setting > General > click on link > Name : Username, Type string, Scope: User.

# If installation does not work in your system:
Details information is here:
https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-7.4

For activated Executive policy: before running this app you need run below code in powershell. Powershell will be run as an administrator. Caution: its only for production purpose.
PowerShell: 'Set-ExecutionPolicy RemoteSigned -Scope CurrentUser'


