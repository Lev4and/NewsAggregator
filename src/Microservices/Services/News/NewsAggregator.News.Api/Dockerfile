#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Microservices/Services/News/NewsAggregator.News.Api/NewsAggregator.News.Api.csproj", "src/Microservices/Services/News/NewsAggregator.News.Api/"]
COPY ["src/Microservices/Services/News/NewsAggregator.News/NewsAggregator.News.csproj", "src/Microservices/Services/News/NewsAggregator.News/"]
COPY ["src/Microservices/BuildingBlocks/NewsAggregator.Infrastructure/NewsAggregator.Infrastructure.csproj", "src/Microservices/BuildingBlocks/NewsAggregator.Infrastructure/"]
COPY ["src/Microservices/BuildingBlocks/NewsAggregator.Domain/NewsAggregator.Domain.csproj", "src/Microservices/BuildingBlocks/NewsAggregator.Domain/"]
RUN dotnet restore "./src/Microservices/Services/News/NewsAggregator.News.Api/./NewsAggregator.News.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Services/News/NewsAggregator.News.Api"
RUN dotnet build "./NewsAggregator.News.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NewsAggregator.News.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsAggregator.News.Api.dll"]