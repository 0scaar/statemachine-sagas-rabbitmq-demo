#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/statemachineSagasRabbitmqDemo.ProcessLine/statemachineSagasRabbitmqDemo.ProcessLine.csproj", "src/statemachineSagasRabbitmqDemo.ProcessLine/"]
COPY ["src/statemachineSagasRabbitmqDemo.Domain/statemachineSagasRabbitmqDemo.Domain.csproj", "src/statemachineSagasRabbitmqDemo.Domain/"]
RUN dotnet restore "src/statemachineSagasRabbitmqDemo.ProcessLine/statemachineSagasRabbitmqDemo.ProcessLine.csproj"
COPY . .
WORKDIR "/src/src/statemachineSagasRabbitmqDemo.ProcessLine"
RUN dotnet build "statemachineSagasRabbitmqDemo.ProcessLine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "statemachineSagasRabbitmqDemo.ProcessLine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "statemachineSagasRabbitmqDemo.ProcessLine.dll"]