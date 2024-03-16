#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/Microservices
COPY ["./Services/Notification/NewsAggregator.Notification.Api/*.csproj", "src/Microservices/Services/Notification/NewsAggregator.Notification.Api/"]
COPY ["./Services/Notification/NewsAggregator.Notification/*.csproj", "src/Microservices/Services/Notification/NewsAggregator.Notification/"]
COPY ["./BuildingBlocks/NewsAggregator.Infrastructure/*.csproj", "src/Microservices/BuildingBlocks/NewsAggregator.Infrastructure/"]
COPY ["./BuildingBlocks/NewsAggregator.Domain/*.csproj", "src/Microservices/BuildingBlocks/NewsAggregator.Domain/"]
RUN dotnet restore "./src/Microservices/Services/Notification/NewsAggregator.Notification.Api/NewsAggregator.Notification.Api.csproj"
COPY . .
WORKDIR "/Services/Notification/NewsAggregator.Notification.Api"
RUN dotnet build "./NewsAggregator.Notification.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NewsAggregator.Notification.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsAggregator.Notification.Api.dll"]