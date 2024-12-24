$packageName = 'organizeit.cli'
$toolsDir = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$binRoot = Get-ToolsLocation

$targetPath = Join-Path $binRoot $packageName

Install-ChocolateyZipPackage $packageName 'https://github.com/Toyin5/OrganizeIt/releases/download/v1.0.0-alpha/release.zip' $toolsDir

# Create a shortcut to the executable
Install-ChocolateyShortcut -shortcutFilePath "$env:ProgramData\Microsoft\Windows\Start Menu\Programs\OrganizeIt.Cli.lnk" -targetPath "$targetPath\organizeit.cli.exe"