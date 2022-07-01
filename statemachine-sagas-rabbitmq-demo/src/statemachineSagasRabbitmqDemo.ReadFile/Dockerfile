#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/statemachineSagasRabbitmqDemo.ReadFile/statemachineSagasRabbitmqDemo.ReadFile.csproj", "src/statemachineSagasRabbitmqDemo.ReadFile/"]
COPY ["src/statemachineSagasRabbitmqDemo.Application/statemachineSagasRabbitmqDemo.Application.csproj", "src/statemachineSagasRabbitmqDemo.Application/"]
COPY ["src/statemachineSagasRabbitmqDemo.Domain/statemachineSagasRabbitmqDemo.Domain.csproj", "src/statemachineSagasRabbitmqDemo.Domain/"]
COPY ["src/statemachineSagasRabbitmqDemo.Infrastructure/statemachineSagasRabbitmqDemo.Infrastructure.csproj", "src/statemachineSagasRabbitmqDemo.Infrastructure/"]
RUN dotnet restore "src/statemachineSagasRabbitmqDemo.ReadFile/statemachineSagasRabbitmqDemo.ReadFile.csproj"
COPY . .
WORKDIR "/src/src/statemachineSagasRabbitmqDemo.ReadFile"
RUN dotnet build "statemachineSagasRabbitmqDemo.ReadFile.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "statemachineSagasRabbitmqDemo.ReadFile.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "statemachineSagasRabbitmqDemo.ReadFile.dll"]