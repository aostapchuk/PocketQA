@echo off

echo Building project . . .

"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" PocketQA.sln /maxcpucount:4 /p:Configuration=Release /p:Platform="Any CPU" /nologo || GOTO ERROR

echo Generating Nuget package . . .

nuget pack PocketQA.nuspec  || GOTO ERROR

echo Success!!!

GOTO END

:ERROR
color C
echo    ------------------------------- ERROR !!!!! -------------------------------
:END

pause