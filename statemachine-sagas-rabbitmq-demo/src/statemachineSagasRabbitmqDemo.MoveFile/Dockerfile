#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/statemachineSagasRabbitmqDemo.MoveFile/statemachineSagasRabbitmqDemo.MoveFile.csproj", "src/statemachineSagasRabbitmqDemo.MoveFile/"]
COPY ["src/statemachineSagasRabbitmqDemo.Domain/statemachineSagasRabbitmqDemo.Domain.csproj", "src/statemachineSagasRabbitmqDemo.Domain/"]
RUN dotnet restore "src/statemachineSagasRabbitmqDemo.MoveFile/statemachineSagasRabbitmqDemo.MoveFile.csproj"
COPY . .
WORKDIR "/src/src/statemachineSagasRabbitmqDemo.MoveFile"
RUN dotnet build "statemachineSagasRabbitmqDemo.MoveFile.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "statemachineSagasRabbitmqDemo.MoveFile.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "statemachineSagasRabbitmqDemo.MoveFile.dll"]