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
	      set destinationSetupDir=%WORKSPACE%\\ConsoleWSTester\\Setup
		  cp ".\\ConsoleWSTester\\bin\\x86\\Release" $destinationSetupDir"\\Release" -recurse
		  set wxsHeatFile=%destinationSetupDir%\\WSTesterHeat.wxs"
		  set releaseDir=Release
		  %HEAT% dir %releaseDir% -sreg -sfrag -gg -srd -dr %releaseDir% -cg WSTesterHeat -out %wxsHeatFile%

			set wixHeatFileObj="%destinationSetupDir%\\WSTesterHeat.wixobj"
			set wixFileObj=%destinationSetupDir%\\WSTester.wixobj"
			set candle="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\candle.exe"

	    '''		 
     }

    stage('Deliver setup') {
	   

	   /*
	    bat '''
	      set current=%BRANCH_NAME:release/=%
	      cd %WORKSPACE%\\installers\\izpack\\X3Console\\project
	      if exist %LATEST_FOLDER%\\safex3-console-installer-2.%current%.*.jar del /F /Q %LATEST_FOLDER%\\safex3-console-installer-2.%current%.*.jar
	      copy /Y safex3-console-installer-2.%current%.*.jar %LATEST_FOLDER%
	    '''
		*/
    }
	
}


