#!groovy
@Library('jenkins-shared-library') _

    properties([disableConcurrentBuilds()])
    def tag
    env.VERSION = "999"
		def INFO_BRANCH = getInfoFromBranchName("${BRANCH_NAME}","x3-ws-tester")
		if (INFO_BRANCH.release) {
			env.TESTER_VERSION = INFO_BRANCH.version
		} else {
			env.TESTER_VERSION = "0.9"
		}
    env.RELEASE = "0"		

    if ("${BRANCH_NAME}" =~ /^release\//)  {
        tag = "${BRANCH_NAME}".split('/')[1]
        env.VERSION = "${tag}"
        env.SETUP_BASE_NAME = "X3-ws-tester-${VERSION}"
        env.SETUP_NAME = "${SETUP_BASE_NAME}.0.${BUILD_ID}"
    } else {
        env.SETUP_BASE_NAME = "stage-X3-ws-tester-"
        env.VERSION = "${BRANCH_NAME}".replaceAll('/','')
        env.SETUP_NAME = "${SETUP_BASE_NAME}.${VERSION}.${BUILD_ID}"
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
			set current=%TESTER_VERSION%
			set version=%current%.%RELEASE%.%BUILD_ID%
			echo current= %current%  version= %version% 
			for /R %cd%  %%G IN (AssemblyInfo.*) do (
				"%SED_HOME%\\sed" -i "s/0\\.99\\.99\\.99/%version%/g"  "%%G"
				"%SED_HOME%\\sed" -i "s/0\\.99/%current%/g"  "%%G"
			)

			"%SED_HOME%\\sed" -i "s/0\\.99\\.99\\.99/%version%/g"  "Setup\\WSTester.wxs"

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
			set wxsHeatFile="WSTesterHeat.wxs"
			set releaseDir="Release"
			xcopy /i /y /s ".\\ConsoleWSTester\\bin\\x86\\Release" ".\\Setup\\Release" 
			copy ".\\Resources\\log4Net-1.2.10\\log4net.dll" ".\\Setup\\Release"

			cd .\\Setup
			%HEAT% dir %releaseDir% -sreg -sfrag -gg -srd -dr %releaseDir% -cg WSTesterHeat -out %wxsHeatFile%

			set wxsFile="WSTester.wxs"
			set wixHeatFileObj="WSTesterHeat.wixobj"
			set wixFileObj="WSTester.wixobj"
			set candle="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\candle.exe"
			%candle% %wxsFile% %wxsHeatFile% -dbuildfolder -v

			set light="C:\\Program Files (x86)\\WiX Toolset v4.0\\bin\\light.exe"
			%light% %wixFileObj% %wixHeatFileObj% -cultures:en-US -ext WixUIExtension.dll -spdb -b Release -o %SETUP_NAME%.msi
			cd %WORKSPACE%
	    '''		 
		stash name:"consoleWSTester", includes: "Setup/${SETUP_NAME}.msi"

     }
}

node('linux') {
    stage('Deliver setup') 
	{
		sh '''
		if [ ! -d "${WORKSPACE}/Setup" ] 
		then
		 mkdir "${WORKSPACE}/Setup"
		fi
		'''
		unstash "consoleWSTester"
		String [] files = [ "${WORKSPACE}/Setup/${SETUP_NAME}.msi" ];
		deliverSetup("${SETUP_BASE_NAME}.*",files)
	}
    if (INFO_BRANCH.release) {notifyBuildResult(buildResult:"SUCCESS")}
 }

 } catch(e) {
        if (INFO_BRANCH.release) {notifyBuildResult(buildResult:"FAILED")}
	    throw e
 }