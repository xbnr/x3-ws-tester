Powershell.exe -executionpolicy remotesigned -File  .\Setup-ConsoleWSTester.ps1
@IF %ERRORLEVEL% EQU 0 GOTO NOERROR1
echo An error occured while building Setup
pause
REM EXIT %ERRORLEVEL%
:NOERROR1

pause