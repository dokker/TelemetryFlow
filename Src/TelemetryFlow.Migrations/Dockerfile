FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TelemetryFlow.Migrations/TelemetryFlow.Migrations.csproj", "TelemetryFlow.Migrations/"]
RUN dotnet restore "TelemetryFlow.Migrations/TelemetryFlow.Migrations.csproj"
COPY . .
WORKDIR "/src/TelemetryFlow.Migrations"
RUN dotnet build "TelemetryFlow.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TelemetryFlow.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TelemetryFlow.Migrations.dll"]
