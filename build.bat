@echo off

rem Licensed Materials - Property of IBM
rem IBM Cognos Products: DOCS
rem (C) Copyright IBM Corp. 2005, 2007
rem US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
rem IBM Corp.

rem  Copyright (C) 2007 Cognos ULC, an IBM Company. All rights reserved.
rem  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).

echo If you didn't run build.bat in ..\SamplesCommon, press Ctrl-C and do it now.
echo.
pause

copy ..\SamplesCommon\SamplesCommon.dll .
copy ..\..\cognosdotnet_2_0.dll .
copy ..\..\cognosdotnetassembly_2_0.dll .

set ICON=/win32icon:..\SamplesCommon\SamplesApplication.ico

set SOURCE=Permissions.cs PermissionsDlg.cs

set RESOURCES=PermissionsDlg.resx

set COMPILED_RESOURCES=/res:PermissionsDlg.resources,Permissions.PermissionsDlg.resources

set COGDLLS=/r:cognosdotnet_2_0.dll /r:cognosdotnetassembly_2_0.dll

resgen /compile PermissionsDlg.resx
csc /nologo %COGDLLS% /r:SamplesCommon.dll %SOURCE% %ICON% %COMPILED_RESOURCES%

del *.resources
echo Done.
