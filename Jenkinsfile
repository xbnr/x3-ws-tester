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
	  	%msbuild% %slnConsoleTester% /p:configuration=Release /t:Clean
	  	%msbuild% %slnConsoleTester% /p:configuration=Release
			git checkout .
	 	'''
	}	
    stage('Sign exe') {
	// 1. Sign the dll 
		bat '"%JAVA_HOME%\\bin\\keytool" -list -keystore NONE -storetype pkcs11 -storepass  r?$Rc3u4H#N5 -providerclass sun.security.pkcs11.SunPKCS11 -providerArg d:\\eToken.cfg '	
		bat '''
		setlocal EnableDelayedExpansion
		set SIGNTOOL="C:\\Program Files (x86)\\Windows Kits\\8.1\\bin\\x86\\signtool.exe"
		set CONSOLE=%WORKSPACE%\\BinRelease\\Console.exe

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
    stage('Build setup') {
	   dir('installers') {
        	git url: 'https://github.com/Sage-ERP-X3/installers.git' // clones installers folder
		bat '''
			git checkout master
			set iZPACK_HOME=%WORKSPACE%\\izpack
			set current=%BRANCH_NAME:release/=%
			
			cd %WORKSPACE%\\installers\\izpack\\X3Console\\project
			del /F /Q safex3-console-installer-2.%current%.*.jar
			mkdir base
			
			echo Start to build %current%
			xcopy %WORKSPACE%\\BinRelease\\*.* base /sy
			"%SED_HOME%\\sed" -e "s/2\\.999/%current%/g" X3Console.xml > X3Console-final.xml 
			"%IZPACK_HOME%\\bin\\compile.bat" X3Console-final.xml -b . -o safex3-console-installer-2.%current%.%BUILD_NUMBER%-win32.jar -k standard -l 9

		'''		

		
		} 	
		 
     }
    stage('Deliver setup') {
	    bat '''
	      set LATEST_FOLDER=%DELIVERY_FOLDER%\\Console
	      set current=%BRANCH_NAME:release/=%
	      cd %WORKSPACE%\\installers\\izpack\\X3Console\\project
	      if exist %LATEST_FOLDER%\\safex3-console-installer-2.%current%.*.jar del /F /Q %LATEST_FOLDER%\\safex3-console-installer-2.%current%.*.jar
	      copy /Y safex3-console-installer-2.%current%.*.jar %LATEST_FOLDER%
	    '''
    }
	
}

