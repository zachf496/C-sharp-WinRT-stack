msbuild Benchmarks\Benchmarks.csproj -t:restore -t:build /p:platform=x64 /p:configuration=release
dotnet %~dp0Benchmarks\bin\x64\Release\netcoreapp2.0\Benchmarks.dll -filter * --runtimes netcoreapp2.0 netcoreapp3.1 netcoreapp5.0