create:
	dotnet new sln
	dotnet new classlib -o lib
	dotnet sln add lib/lib.csproj
	dotnet new console -o app
	dotnet sln add app/app.csproj
	dotnet add app/app.csproj reference lib/lib.csproj
run:
	dotnet run --project app/app.csproj
