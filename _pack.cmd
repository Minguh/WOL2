IF EXIST WOL2.7z del WOL2.7z
"%SEVENZIP%" a WOL2.7z .\deploy\bkg.png .\deploy\ReadMe_En.htm .\deploy\ReadMe_De.htm .\deploy\wol2.sh .\deploy\wol2_todo.txt .\WOL2\bin\Release\WOL2.exe .\deploy\WOL2.profile.xml .\deploy\oui.txt .\deploy\example.csv

@echo Adding language DLLs
"%SEVENZIP%" a -r WOL2.7z .\WOL2\bin\Release\*\WOL2.resources.dll

@echo Adding Icons...
"%SEVENZIP%" a -r WOL2.7z .\deploy\icons