
msbuild NLipsum.sln /p:Configuration=Release /t:Rebuild

nuget pack NLipsum.nuspec
