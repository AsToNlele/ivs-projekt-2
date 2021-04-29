.PHONY: all pack clean run profile help

all:
	ivs-projekt-2\bin\Release\ivs-projekt-2.exe

pack:
	if exist "..\..\pack" (rmdir "..\..\pack\" /s /q )
	mkdir "..\..\pack"

	mkdir "..\..\pack\doc"
	xcopy "..\..\doc" "..\..\pack\doc" /h /i /e /c /r /y /k

	mkdir "..\..\pack\install"
	xcopy "..\..\install" "..\..\pack\install"

	mkdir "..\..\pack\repo"
	xcopy ".." "..\..\pack\repo" /h /i /e /c /r /y /k
	del /s /q "..\..\pack\repo\src\.vs"
	rmdir /s /q "..\..\pack\repo\src\.vs"
	cd "..\..\pack" & zip -r "xhyblp01_xcelak00_xklond00.zip" * repo\.git

clean:
	if exist "ivs-projekt-2\bin\" (del /s /q ivs-projekt-2\bin & rmdir /s /q ivs-projekt-2\bin)
	
	if exist "ivs-projekt-2\obj\" (del /s /q ivs-projekt-2\obj & rmdir /s /q ivs-projekt-2\obj)

	if exist "CalcTests\bin\" (del /s /q CalcTests\bin & rmdir /s /q CalcTests\bin)

	if exist "CalcTests\obj\" (del /s /q CalcTests\obj &	rmdir /s /q CalcTests\obj)

	if exist "Instalator\Debug\" (del /s /q Instalator\Debug & rmdir /s /q Instalator\Debug)

	if exist "Instalator\Release\" (del /s /q Instalator\Release & rmdir /s /q Instalator\Release)

	if exist "packages\" (del /s /q packages & rmdir /s /q packages)

	if exist "TestResults\" (del /s /q TestResults & rmdir /s /q TestResults)

	if exist "Profiling\obj\" (del /s /q Profiling\obj & rmdir /s /q Profiling\obj)

	if exist "Profiling\bin\" (xcopy /q "Profiling\bin\Debug\soubor.txt" . & del /s /q Profiling\bin & xcopy /q "soubor.txt" "Profiling\bin\Debug\" & xcopy /q "soubor.txt" "Profiling\bin\Release\" & del "soubor.txt")

run:
	ivs-projekt-2\bin\Release\ivs-projekt-2.exe

profile:
	Profiling\bin\Release\Profiling.exe Profiling\bin\Release\soubor.txt

help:
	echo "Pred Spustenim:"
	echo "Doporucujeme Visual Studio 2019 a zkompilovat Release verze ivs-projekt-2 a Profiling"