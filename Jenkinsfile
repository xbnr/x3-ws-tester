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
		stash name:"binRelease", includes: "ConsoleWSTester/bin/x86/Release/**/*"
	}
	
		node('sign') {
		stage('Sign exe and dlls') {
			unstash "binRelease"
			signExe("ConsoleWSTester\\bin\\Release\\ConsoleTester.exe")
			stash name:"binRelease", includes: "ConsoleWSTester/bin/x86/Release/**/*"
		}		
	}

    stage('Build setup') {
	   	bat '''
			set  HEAT="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\heat.exe"		  
			set destinationSetupDir=.\\ConsoleWSTester\\Setup
			set wxsHeatFile="WSTesterHeat.wxs"
			set releaseDir="Release"
			xcopy /y /s ".\\ConsoleWSTester\\bin\\x86\\Release" ".\\ConsoleWSTester\\Setup\\Release" 
			cd .\\ConsoleWSTester\\Setup
			%HEAT% dir %releaseDir% -sreg -sfrag -gg -srd -dr %releaseDir% -cg WSTesterHeat -out %wxsHeatFile%

			set wxsFile="WSTester.wxs"
			set wixHeatFileObj="WSTesterHeat.wixobj"
			set wixFileObj="WSTester.wixobj"
			set candle="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\candle.exe"
			%candle% %wxsFile% %wxsHeatFile% -dbuildfolder -v

	        set current=%BRANCH_NAME:release/=%
   			set current=%current:/=-%
			set setupName="WsTester.%current%.msi";
			set light="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\light.exe"
			%light% %wixFileObj% %wixHeatFileObj% -cultures:en-US -ext WixUIExtension.dll -spdb -b Release -o %setupName%

	    '''		 
     }

    stage('Deliver setup') {
	
    bat '''
		  set LATEST_FOLDER=%DELIVERY_FOLDER%\\Tester
	      set current=%BRANCH_NAME:release/=%
   		  set current=%current:/=-%
	      cd %WORKSPACE%\\ConsoleWSTester\\Setup
	      if exist %LATEST_FOLDER%\\WsTester.%current%.* del /F /Q %LATEST_FOLDER%\\WsTester.%current%.*
	      copy /Y WsTester.%current%.* %LATEST_FOLDER%
	    '''
    }
	
}


