@ECHO OFF
SET SEVENZIP=%programfiles%\7-Zip\7z.exe
rem SET CANDLE=%programfiles(x86)%\WixEdit\wix-3.7\candle.exe
rem SET LIGHT=%programfiles(x86)%\WixEdit\wix-3.7\light.exe
rem SET SIGNTOOL=%programfiles(x86)%\Windows Kits\8.0\bin\x64\signtool.exe
@ECHO %DATE% - %TIME% Starting distribution build.>distribution.log
;;
@ECHO Building 7Z package for binary distribution...
call _pack.cmd
;;
@ECHO.
@ECHO Building Setup.msi...
rem "%CANDLE%" -nologo "Setup.wxs" -out "Setup.wixobj"  -ext WixUtilExtension  -ext WixUIExtension  -ext WixNetFxExtension>>distribution.log
rem "%LIGHT%" "Setup.wixobj" -out "WOL2.msi"  -ext WixUtilExtension  -ext WixUIExtension  -ext WixNetFxExtension  -cultures:en-en,de-de>>distribution.log
;;
@ECHO.
@ECHO Cleaning up...
DEL Setup.wixobj>NUL
DEL WOL2.wixpdb>NUL
;;
@ECHO.
@ECHO Signing MSI file...
rem "%SIGNTOOL%" sign /f "\\server\Dokumente\Marko\Marko_Oette.pfx" /p "%1" /t "http://timestamp.verisign.com/scripts/timstamp.dll" "WOL2.msi">>distribution.log
;;
@ECHO.
@ECHO Done.
pause
del distribution.log
