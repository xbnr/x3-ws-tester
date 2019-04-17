#!groovy
@Library('jenkins-shared-library') _

    properties([disableConcurrentBuilds()])
    def tag
    env.VERSION = "999"
		def INFO_BRANCH = getInfoFromBranchName("${BRANCH_NAME}","x3-ws-tester")
		if (INFO_BRANCH.release) {
			env.PRINTSERVER_VERSION = INFO_BRANCH.version
		} else {
			env.PRINTSERVER_VERSION = "9.9"
		}

    if ("${BRANCH_NAME}" =~ /^release\//)  {
        tag = "${BRANCH_NAME}".split('/')[1]
        env.VERSION = "${tag}"
        env.SETUP_BASE_NAME = "x3-ws-tester-${VERSION}"
        env.SETUP_NAME = "${SETUP_BASE_NAME}.0.${BUILD_ID}-win"
    } else {
        env.SETUP_BASE_NAME = "stage-x3-ws-tester-"
        env.VERSION = "${BRANCH_NAME}".replaceAll('/','')
        env.SETUP_NAME = "${SETUP_BASE_NAME}.${VERSION}.${BUILD_ID}-win"
    }
    env.DELIVERY_FOLDER = '/var/jenkins_home/userContent'

// This task is restrited to the slave "ser-rsrcs22", the only server able to sign dll
try {  


node('windows') {

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
}

		node('sign') {
		stage('Sign exe and dlls') {
			unstash "binRelease"
			signExe("ConsoleWSTester\\bin\\x86\\Release\\ConsoleTester.exe")
			stash name:"binRelease", includes: "ConsoleWSTester/bin/x86/Release/**/*"
		}		
	}


node('windows') {
    stage('Build setup') {
	   	bat '''
			set  HEAT="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\heat.exe"		  
			set destinationSetupDir=.\\ConsoleWSTester\\Setup
			set wxsHeatFile="WSTesterHeat.wxs"
			set releaseDir="Release"
			xcopy /i /y /s ".\\ConsoleWSTester\\bin\\x86\\Release" ".\\ConsoleWSTester\\Setup\\Release" 
			cd .\\ConsoleWSTester\\Setup
			%HEAT% dir %releaseDir% -sreg -sfrag -gg -srd -dr %releaseDir% -cg WSTesterHeat -out %wxsHeatFile%

			set wxsFile="WSTester.wxs"
			set wixHeatFileObj="WSTesterHeat.wixobj"
			set wixFileObj="WSTester.wixobj"
			set candle="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\candle.exe"
			%candle% %wxsFile% %wxsHeatFile% -dbuildfolder -v

	        set current=%BRANCH_NAME:release/=%
   			set current=%current:/=-%
			REM set setupName="WsTester.%current%.msi";
			set light="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\light.exe"
			%light% %wixFileObj% %wixHeatFileObj% -cultures:en-US -ext WixUIExtension.dll -spdb -b Release -o %SETUP_NAME%.msi

	    '''		 
     }

    stage('Deliver setup') {
	
	String [] files = [
						"${WORKSPACE}/ConsoleWSTester/setup/${SETUP_NAME}.msi"
						];
					deliverSetup("${SETUP_BASE_NAME}.*",files)
        }

        if (tag) {
            def msg = "Success: <${env.BUILD_URL}|Build Tester ${tag}> [${env.BUILD_NUMBER}]\n"
            msg = msg + "<${JENKINS_URL}userContent/Latest/${SETUP_NAME}.jar|${SETUP_NAME}.jar>"
            slackSend(color: '#00FF00', message: msg)
        }	
}


    } catch(e) {
        currentBuild.result = "FAILED"
        if (tag) {
            def msg = "Failed: <${env.BUILD_URL}|Build print server ${tag}> [${env.BUILD_NUMBER}]"
            slackSend(color: '#FF0000', message: msg)
        }
        throw e
    }