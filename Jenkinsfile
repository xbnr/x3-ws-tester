#!groovy
// This task is restrited to the slave "ser-rsrcs22", the only server able to sign dll
node('ser-rsrcs22') {
   stage('Checkout and scan') {
         checkout scm	  
		
    }

   stage('Build solution') {
		bat '''
			set current=%BRANCH_NAME:release/=%
			set version=%current%.%BUILD_ID%
			echo current= %current%  version= %version% 
			for /R %cd%  %%G IN (AssemblyInfo.*) do (
			"%SED_HOME%\\sed" -i "s/2\\.999\\.99/%version%/g"  %%G
			"%SED_HOME%\\sed" -i "s/2\\.999/%current%/g"  %%G
			)


	  	    set slnConsoleTester="WSTester.sln"
	  	    set msbuild="c:\\program files (x86)\\microsoft visual studio\\2017\\buildtools\\msbuild\\15.0\\bin\\msbuild.exe" 

			set nuget=".nuget\\NuGet.exe"
			%nuget% restore %slnConsoleTester%

	  	%msbuild% %slnConsoleTester% /p:configuration=Release /t:Clean
	  	%msbuild% %slnConsoleTester% /p:configuration=Release /p:Platform="x86"
			git checkout .
	 	'''
	}
	/*	
    stage('Sign exe') {
	// 1. Sign the dll 
		bat '"%JAVA_HOME%\\bin\\keytool" -list -keystore NONE -storetype pkcs11 -storepass  r?$Rc3u4H#N5 -providerclass sun.security.pkcs11.SunPKCS11 -providerArg d:\\eToken.cfg '	
		bat '''
		setlocal EnableDelayedExpansion
		set SIGNTOOL="C:\\Program Files (x86)\\Windows Kits\\8.1\\bin\\x86\\signtool.exe"
		set CONSOLE=%WORKSPACE%\\ConsoleWSTester\\bin\\x86\\Release\\ConsoleTester.exe

	   %SIGNTOOL% verify /pa "%CONSOLE%"
			if !ERRORLEVEL! GEQ 1  (
			    set ERRORLEVEL=0
				echo This file is not signed.
				call C:\\Syracuse\\Signature\\sign_proc  "%CONSOLE%"	
			) else (
				  echo This file is already signed.
			)

		'''
	    stash name:"consoleBinRelease", includes: "BinRelease/*"

    }
	*/
    stage('Build setup') {
	   	bat '''
			set LATEST_FOLDER=%DELIVERY_FOLDER%\\Tester
			set  HEAT="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\heat.exe"		  
			set destinationSetupDir=.\\ConsoleWSTester\\Setup
			set wxsHeatFile=".\\ConsoleWSTester\\Setup\\WSTesterHeat.wxs"
			set releaseDir="ConsoleWSTester\\bin\\x86\\Release"
			%HEAT% dir %releaseDir% -sreg -sfrag -gg -srd -dr %releaseDir% -cg WSTesterHeat -out %wxsHeatFile%

			set wxsFile=".\\ConsoleWSTester\\Setup\\WSTester.wxs"
			set wixHeatFileObj=".\\ConsoleWSTester\\Setup\\WSTesterHeat.wixobj"
			set wixFileObj=".\\ConsoleWSTester\\Setup\\WSTester.wixobj"
			set candle="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\candle.exe"
			%candle% %wxsFile% %wxsHeatFile% -dbuildfolder -v

	        set current=%BRANCH_NAME:release/=%
			set setupName=".\\ConsoleWSTester\\Setup\\WsTester.%current%.msi";
			set light="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\light.exe"
			%light% %wixFileObj% %wixHeatFileObj% -cultures:en-US -ext WixUIExtension.dll -spdb -b Release -o %setupName%

	    '''		 
     }

    stage('Deliver setup') {
	
    bat '''
	      set current=%BRANCH_NAME:release/=%
	      cd %WORKSPACE%\\ConsoleWSTester\\Setup
	      if exist %LATEST_FOLDER%\\WsTester.%current%.* del /F /Q %LATEST_FOLDER%\\WsTester.%current%.*
	      copy /Y WsTester.%current%.* %LATEST_FOLDER%
	    '''
    }
	
}


