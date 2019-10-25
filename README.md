# ServiceStackModules

This project is a demo of how we can generate different build outputs for different clients.

There are various Build Configurations created:

- Debug (default)
- DebugClientA - to generate output only for the Client A - builds only dlls related to Client A.
- DebugClientB - to generate output only for the Client B - builds only dlls related to Client B.
- DebugDefault - to generate output only for the Client A - builds only single ServiceInterface and related ServiceModel project.

If there is another client added to the solution and there is a need to generate the new output for it, you can simply create the new build configuration and tell it which projects to include in the output:

![Tick/untick needed projects](https://raw.githubusercontent.com/yuriiproniuk/ServiceStackModules/master/Screenshot_1.png)

## Build

IMPORTANT: Build using the dotnet CLI. Visual Studio build does not build the solution correctly.
IMPORTANT: Pass the ```--configuration``` parameter for the proper build.

```bash
dotnet build --configuration DebugClientA
```

## Run

```bash
dotnet run --project MyApp.csproj --configuration DebugClientA
```

## Publish

For executable projects targeting versions earlier than .NET Core 3.0, library dependencies from NuGet are typically NOT copied to the output folder. They're resolved from the NuGet global packages folder at run time. With that in mind, the product of dotnet build isn't ready to be transferred to another machine to run. To create a version of the application that can be deployed, you need to publish it (for example, with the dotnet publish command).

```bash
dotnet publish MyApp.csproj --configuration DebugClientA
```
