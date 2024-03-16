#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/Microservices
COPY ["./Services/News/NewsAggregator.News.Parser/*.csproj", "src/Microservices/Services/News/NewsAggregator.News.Parser/"]
COPY ["./Services/News/NewsAggregator.News/*.csproj", "src/Microservices/Services/News/NewsAggregator.News/"]
COPY ["./BuildingBlocks/NewsAggregator.Infrastructure/*.csproj", "src/Microservices/BuildingBlocks/NewsAggregator.Infrastructure/"]
COPY ["./BuildingBlocks/NewsAggregator.Domain/*.csproj", "src/Microservices/BuildingBlocks/NewsAggregator.Domain/"]
RUN dotnet restore "./src/Microservices/Services/News/NewsAggregator.News.Parser/./NewsAggregator.News.Parser.csproj"
COPY . .
WORKDIR "/Services/News/NewsAggregator.News.Parser"
RUN dotnet build "./NewsAggregator.News.Parser.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NewsAggregator.News.Parser.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsAggregator.News.Parser.dll"]