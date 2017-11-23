# Setup Tester
# Wix Tools

$ErrorActionPreference = "Stop"

# recopie d'une config (peu importe laquelle)
write-host "0/ $(get-date -f HH:mm:ss) copy config files"


# Copy-Item "Console\App.Internal.config" "Console\App.config" -recurse

#
# clean & build
#

write-host "1/ $(get-date -f HH:mm:ss) clean"


$msbuild = "c:\program files (x86)\microsoft visual studio\2017\enterprise\msbuild\15.0\bin\msbuild.exe"
if ((test-path $msbuild) -eq $false)
{
   $msbuild = "c:\program files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe"
}
if ($env:computername -eq "ser-rsrcs04") 
{ 
   $msbuild = "c:\program files (x86)\microsoft visual studio\2017\buildtools\msbuild\15.0\bin\msbuild.exe" 
}


$slnTester = 'WSTester.sln'
&$msbuild ($slnTester,'/p:configuration=Release','/t:Clean') > clean.txt
if (!$?) {
   write-host "ERROR: an error occured while cleanning"
   write-host "ERROR --> Please, read file clean.txt for more information"
   
   write-host (Get-Content clean.txt)
   
   exit 1;    
}

write-host "2/ $(get-date -f HH:mm:ss) build $slnTester"

&$msbuild ($slnTester,'/p:Configuration=Release;Platform=x86') > build.txt
if (!$?) {
   write-host "ERROR: an error occured while building $slnTester"
   write-host "ERROR --> Please, read file build.txt for more information"
   
   write-host (Get-Content build.txt)
   
   exit 2;   
}


write-host "3/ $(get-date -f HH:mm:ss) $slnTester Built                                        "
write-host "4/ $(get-date -f HH:mm:ss) Generate package WSTester Wix"

#
# nettoyage, avant
#
$destinationSetupDir = "c:\Master\WSTester"
write-host "5/ $(get-date -f HH:mm:ss) Preparation: Clean directory $destinationSetupDir"


If (Test-Path $destinationSetupDir) 
{
    Remove-Item $destinationSetupDir -recurse
}

Copy-Item ".\ConsoleWSTester\bin\x86\Release" $destinationSetupDir"\Release" -recurse
Copy-Item ".\ConsoleWSTester\Setup\WSTester.ico" $destinationSetupDir"\WSTester.ico" -recurse
Copy-Item ".\ConsoleWSTester\Setup\WSTester.wxs" $destinationSetupDir"\WSTester.wxs" -recurse
Copy-Item ".\ConsoleWSTester\Setup\License.rtf" $destinationSetupDir"\License.rtf" -recurse


Push-Location $destinationSetupDir

write-host "6/ $(get-date -f HH:mm:ss) Generate MSI setup in $destinationSetupDir"
write-host ""

# Generate MSI: Heat, Candle, Light
# 
# 1. Heat: build dynamic file  TesterHeat.wxs to harvest all bin files to set in the MS setup
# heat project ..\Desktop\Tools.Tester.Desktop.csproj -pog Binaries -pog Content -pog Satellites -ag -template fragment  -out WSTester.wxs
# 2. Candle: Preprocesses and compiles WiX source files into object files (.wixobj)
# candle Tester.wxs
# 3: light: Links and binds one or more .wixobj files and creates a Windows Installer database (.msi or .msm).
# light  Tester.wixobj

$heat = "C:\Program Files (x86)\WiX Toolset v4.0\bin\heat.exe"
if ((test-path $heat) -eq $false)
{
    $WixToolSeturl = "http://wixtoolset.org/releases/weekly/"
    write-host "----------------------------------------------------------"
    write-host "Please, install WiX Toolset v4.0 before lauching MD setup:"
    write-host "Download WiX Toolset v4.0 here: "
    write-host $WixToolSeturl 
    write-host "----------------------------------------------------------"
    Start-Process "chrome.exe" $WixToolSeturl
   exit 1;    
}
$wxsHeatFile = $destinationSetupDir + "\WSTesterHeat.wxs"
$releaseDir = "Release"
&$heat ('dir', 'Release', '-sreg', '-sfrag', '-gg', '-srd', '-dr', $releaseDir, '-cg','WSTesterHeat', '-out', $wxsHeatFile)
#&$heat ('dir', 'Release', '-sreg', '-sfrag', '-gg', '-srd', '-var', 'var.MyBinSource', '-cg','TesterHeat', '-out', $wxsHeatFile)
#"$(WIX)bin\heat.exe" dir "$(SuperFormFilesDir)" -cg SuperFormFiles -gg -scom -sreg -sfrag -srd -dr INSTALLLOCATION -var env.SuperFormFilesDir -out "$(ProjectDir)Fragments\FilesFragment.wxs"

$wxsFile = $destinationSetupDir + "\WSTester.wxs"
if ((test-path $wxsFile) -eq $false)
{
    write-host "Error Wix file $wxsFile doesnt exist"
   exit 1;    
}
$wixHeatFileObj = $destinationSetupDir + "\WSTesterHeat.wixobj"
$wixFileObj = $destinationSetupDir + "\WSTester.wixobj"
$candle = "C:\Program Files (x86)\WiX Toolset v4.0\bin\candle.exe"
&$candle ($wxsFile, $wxsHeatFile,'-dbuildfolder', '-v')


if ((test-path $wixFileObj) -eq $false)
{
    write-host "Error while Candle file $wixFileObj has not been generated by Candle"
   exit 1;    
}

$setupName = ".\Setup\WsTester.msi";
$light = "C:\Program Files (x86)\WiX Toolset v4.0\bin\light.exe"
&$light ($wixFileObj, $wixHeatFileObj, '-cultures:en-US', '-ext', 'WixUIExtension.dll', '-spdb', '-b', 'Release', '-o', $setupName)

write-host "7/ $(get-date -f HH:mm:ss) Tester setup finished: $destinationSetupDir$setupName"
