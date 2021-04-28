.PHONY: all pack clean run profile help

all:
	ivs-projekt-2\bin\Release\ivs-projekt-2.exe

pack:
	echo "pack"

clean:
	del /s /q ivs-projekt-2\bin
	rmdir /s /q ivs-projekt-2\bin
	del /s /q ivs-projekt-2\obj
	rmdir /s /q ivs-projekt-2\obj

	del /s /q Instalator\Debug
	rmdir /s /q Instalator\Debug
	del /s /q Instalator\Release
	rmdir /s /q Instalator\Release
	del /s /q Profiling\obj
	rmdir /s /q Profiling\obj
	xcopy /q "Profiling\bin\Debug\soubor.txt" .
	del /s /q Profiling\bin
	xcopy /q "soubor.txt" "Profiling\bin\Debug\"
	xcopy /q "soubor.txt" "Profiling\bin\Release\"
	del "soubor.txt"
	

run:
	ivs-projekt-2\bin\Release\ivs-projekt-2.exe

profile:
	Profiling\bin\Release\Profiling.exe Profiling\bin\Release\soubor.txt

help:
	echo "Pred Spustenim:"
	echo "Doporučujeme Visual Studio 2019 a zkompilovat Release verze ivs-projekt-2 a Profiling"