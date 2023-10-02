# MAUI WITH SQL SERVER

This is a todo app that connects the SQL Server in a localhost through docker using SQL server image for linux container.

## Requirements

- dotnet 7 with MAUI package
- Docker desktop (windows) / docker and docker compose (linux)
- Running on Windows OR Android Emulator

## How to run

### Start SQL Server in Docker 

In case you don't have SQL Server installed, or you won't to install it, you can run it through a docker container. Follow these steps for doing that:

For Windows:
```
docker-compose -f ./src/Docker-compose.yml up
```

For linux:
```
docker compose up -f ./src/Docker-compose.yml up
```

### Start the App

#### In Windows through Visual Studio 2022 with MAUI package

- Open the solution and click on Run "Windows Application" or Android emulator of your choice.

#### In linux through the Terminal

- [Install .NET SDK](https://dotnet.microsoft.com/en-us/download)

- Install .NET MAUI workload with the dotnet CLI. Launch a command prompt and enter the following:
```
dotnet workload install maui
```

- Verify and install missing components with maui-check command line utility.

```
dotnet tool install -g redth.net.MAUI.check

maui-check
```

- Run the MAUI app in the Android Simulator.
```
dotnet build run --project ./src/TodoMaui/TodoMaui.csproj -f net7.0-android
```
