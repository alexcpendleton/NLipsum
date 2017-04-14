
msbuild NLipsum.sln /p:Configuration=Release /t:Rebuild

"packages/NuGet.CommandLine.3.5.0/tools/nuget.exe" pack NLipsum.nuspec
