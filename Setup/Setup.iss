[Setup]
;-- Main Setup Information
 AppName                         = SQLPWAudit
 AppVerName                      = SQLPWAudit 1.0.0.3
 AppCopyright                    = Copyright © 1995-2012 NetworkDLS.
 DefaultDirName                  = {pf}\NetworkDLS\SQLPWAudit
 DefaultGroupName                = NetworkDLS\SQLPWAudit
 UninstallDisplayIcon            = {app}\SQLPWAudit.exe
 WizardImageFile                 = ..\..\..\..\@Resources\Setup\LgSetup.bmp
 WizardSmallImageFile            = ..\..\..\..\@Resources\Setup\SmSetup.bmp
 PrivilegesRequired              = PowerUser
 Uninstallable                   = Yes
  LicenseFile                     = ..\..\..\..\@Resources\Setup\EULA.txt
 Compression                     = ZIP/9
 OutputBaseFilename              = SQLPWAudit
 MinVersion                      = 0.0,5.0

;-- Windows 2000 & XP (Support Dialog)
 AppPublisher    = NetworkDLS
 AppPublisherURL = http://www.NetworkDLS.com/
 AppUpdatesURL   = http://www.NetworkDLS.com/
 AppVersion      = 1.0.0.3

[Files]
 Source: "..\..\..\..\@Resources\Setup\EULA.txt";  DestDir: "{app}";             
 Source: "..\bin\Release\SQLPWAudit.exe";          DestDir: "{app}"; Flags: IgnoreVersion;
 Source: "SQLPWAudit.exe.config";                  DestDir: "{app}"; Flags: IgnoreVersion;

[Icons]
 Name: "{group}\SQLPWAudit";            Filename: "{app}\SQLPWAudit.exe";
 Name: "{group}\Uninstall SQLPWAudit";  Filename: "{uninstallexe}";
 
[Run]
 Filename: "{app}\SQLPWAudit.exe"; Description: "Run SQLPWAudit now?"; Flags: PostInstall NoWait shellexec skipifsilent;
