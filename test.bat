@echo off
Packages\xunit.runner.console.2.1.0\tools\xunit.console ^
	App01.Facts\bin\Debug\App01.Facts.dll^
	-parallel all ^
	-html Result.html ^
	-nologo -verbose
@echo on 