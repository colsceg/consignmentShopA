!include "MUI.nsh"
!include "WordFunc.nsh"
!include "TextFunc.nsh"
!include "FileFunc.nsh"

# All the other settings can be tweaked by editing the !defines at the top of this script
!define APPNAME "PINK2ndHand"
!define APPDIR "PINK2ndHand"
!define COMPANYNAME "2ndHandWare"
!define DESCRIPTION "Programm zur Verwaltung von Kommissionswaren "
!define INSTALLSIZE 40000

;--------------------------------

;General

# This will be in the installer/uninstaller's title bar
	Name "${APPNAME}"
	Icon "logo4.ico"
	outFile "2ndHandWareInstallerPINK.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\${COMPANYNAME}\${APPNAME}"    
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\PINK2ndHand" ""

  ;ReadRegDWORD $x HKLM Software\Microsoft\NET Framework Setup\NDP\v4\Client Install

  ;Request application privileges for Windows 
  ;RequestExecutionLevel admin
  
;--------------------------------


!insertmacro MUI_PAGE_LICENSE "license.rtf"
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

!insertmacro MUI_LANGUAGE "German"

/* Function connectionString1
	
	${WordReplace} '$R9' '<add name="SecondHandCollection_old"' '<add name="SecondHandCollection_old" connectionString="Data Source=$Documents\PINK2ndHand\SecondHandCollection.db; version=3;" />' '+*' $R9
	
	Push $0
FunctionEnd

Function connectionString2
	
	${WordReplace} '$R9' '<add name="SecondHandArchiveCollection_old"' '<add name="SecondHandArchiveCollection_old" connectionString="Data Source=$Documents\$(APPDIR)Archive\SecondHandArchiveCollection.db; version=3;" />' '+*' $R9
	
	Push $0
FunctionEnd */


Section "" SecDummy

SetShellVarContext current


  SetOutPath "$INSTDIR"
  
  ;ADD YOUR OWN FILES HERE...
	
    file "ConsignmentShopLibrary.dll"
    file "ConsignmentShopLibrary.dll.config"		
	file "ConsignmentShopMainUI.exe"
	file "ConsignmentShopMainUI.exe.config"
	file "dotNetFx40_Full_x86_x64.exe"

	file "Dapper.dll"

	file "License.rtf"
	file "logo4.ico"

	file "System.Data.SQLite.dll"
	file "System.Data.SQLite.dll.config"
	file "System.Data.SQLite.EF6.dll"
	file "System.Data.SQLite.Linq.dll"

	SetOutPath "$INSTDIR\x86"
		file "x86\SQLite.Interop.dll"
	SetOutPath "$INSTDIR\x64"
		file "x64\SQLite.Interop.dll"
		
	; nur kopieren wenn nicht vorhanden	
	IfFileExists "$DOCUMENTS\${APPDIR}\SecondHandCollection.db" exists notExists
	
	notExists:
	SetOutPath "$DOCUMENTS\${APPDIR}"
		file "SecondHandCollection.db"
	;Anpassen der connection Strings in ConsignmentShopMainUI.exe.config
	;${LineFind} "$INSTDIR\ConsignmentShopMainUI.exe.config" "$INSTDIR\ConsignmentShopMainUI.exe.config" "1:-1" "connectionString1"

	;${LineFind} "$INSTDIR\ConsignmentShopMainUI.exe.config" "$INSTDIR\ConsignmentShopMainUI.exe.config" "1:-1" "connectionString2"
	
	;Store installation folder
    exists:
  	WriteRegStr HKCU "Software\2ndHandWare" "" $INSTDIR
  	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "PINK2ndHand"
  	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" '"$INSTDIR\uninstall.exe"'
  	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "NoModify" 1
  	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "NoRepair" 1
  
     # Start Menu
   	CreateDirectory "$SMPROGRAMS\${COMPANYNAME}"
   	CreateShortCut "$SMPROGRAMS\${COMPANYNAME}\${APPNAME}.lnk" "$INSTDIR\PINK2ndHand.exe" "" "$INSTDIR\logo4.ico" 
   	CreateShortCut "$SMPROGRAMS\${COMPANYNAME}\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 
	


	;Create uninstaller
  	WriteUninstaller $INSTDIR\uninstall.exe
	;Test for dotNET Framework
	ReadRegDWORD $0 HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client" Install
	Pop $0
   	StrCmp $0 1 found_dotNETFramework no_dotNETFramework

   	found_dotNETFramework: 
		DetailPrint "dotNET found"
		
   	Goto End 

   	no_dotNETFramework: 
		DetailPrint "dotNET not found"  
		ExecWait '"$INSTDIR\dotNetFx40_Full_x86_x64.exe"'
 
   	END:

SectionEnd

; Optional section (can be disabled by the user)
Section /o "Daten loeschen" SecDeleteOldData
	#Desktop Icon
	;ADD YOUR OWN FILES HERE...
	Delete "$DOCUMENTS\${APPDIR}\SecondHandCollection.db" 
	SetOutPath "$DOCUMENTS\${APPDIR}"
		file "SecondHandCollection.db"

SectionEnd

Section "DeskTop Icon" SecIcon
	#Desktop Icon
	CreateShortCut "$DESKTOP\${APPNAME}.lnk" "$INSTDIR\ConsignmentShopMainUI.exe" "" "$INSTDIR\logo4.ico"
SectionEnd

;Descriptions

  ;Language strings
	LangString DESC_SecDummy ${Lang_German} "Hauptprogram"
	LangString DESC_SecIcon ${Lang_German} "Icon auf dem Desktop erstellen"
	LangString DESC_SecDelete  ${Lang_German} "Alle vom Benutzer erstellten vorhandenen Daten loeschen"
  
    ;Assign language strings to sections
	!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
	!insertmacro MUI_DESCRIPTION_TEXT ${SecDummy} $(DESC_SecDummy)
	!insertmacro MUI_DESCRIPTION_TEXT ${SecIcon} $(DESC_SecIcon)
	!insertmacro MUI_DESCRIPTION_TEXT ${SecDeleteOldData} $(DESC_SecDelete)
	!insertmacro MUI_FUNCTION_DESCRIPTION_END
 
;--------------------------------
  

Section "Uninstall"

	# Registry Einträge löschen
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"
	DeleteRegKey /ifempty HKCU "Software\2ndHandWare"
	
	# Remove Desktop Icon
	Delete "$DESKTOP\${APPNAME}.lnk"

	# Remove Start Menu launcher
	Delete "$SMPROGRAMS\${COMPANYNAME}\${APPNAME}.lnk"
	Delete "$SMPROGRAMS\${COMPANYNAME}\Uninstall.lnk"
	RMDir "$SMPROGRAMS\${COMPANYNAME}"

  ;ADD YOUR OWN FILES HERE...
    Delete "$INSTDIR\ConsignmentShopLibrary.dll"
    Delete "$INSTDIR\ConsignmentShopLibrary.dll.config"		
	Delete "$INSTDIR\ConsignmentShopMainUI.exe"
	Delete "$INSTDIR\ConsignmentShopMainUI.exe.config"
	Delete "$INSTDIR\License.rtf"
	Delete "$INSTDIR\logo4.ico"
	
	Delete "$INSTDIR\dotNetFx40_Full_x86_x64.exe"
	Delete "$INSTDIR\Dapper.dll"
	Delete "$INSTDIR\System.Data.SQLite.dll"
	Delete "$INSTDIR\System.Data.SQLite.dll.config"
	Delete "$INSTDIR\System.Data.SQLite.EF6.dll"
	Delete "$INSTDIR\System.Data.SQLite.Linq.dll"
  	Delete "$INSTDIR\Uninstall.exe"
	
	Delete "$INSTDIR\x86\SQLite.Interop.dll"
	Delete "$INSTDIR\x64\SQLite.Interop.dll"
  	RMDir "$INSTDIR\x64"
  	RMDir "$INSTDIR\x86"
	
  # Try to remove the Start Menu folder - this will only happen if it is empty
  	RMDir "$INSTDIR"
	
  # Remove AppDir
  ; Optional section (can be disabled by the user)
	#Section /o "Daten loeschen" SecDeleteOldData
	#Desktop Icon
	;ADD YOUR OWN FILES HERE...
	Delete "$DOCUMENTS\${APPDIR}\SecondHandCollection.db" 
	Delete "$DOCUMENTS\${APPDIR}\Backup\*.*" 
	RMdir "$DOCUMENTS\${APPDIR}\Backup"
	RMdir "$DOCUMENTS\${APPDIR}"
	#SetOutPath "$DOCUMENTS\${APPDIR}"
	#	file "SecondHandCollection.db"

SectionEnd