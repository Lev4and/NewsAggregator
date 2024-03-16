#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/Microservices
COPY ["./Gateways/NewsAggregator.Gateways.Api/*.csproj", "./Gateways/NewsAggregator.Gateways.Api/"]
RUN dotnet restore "./Gateways/NewsAggregator.Gateways.Api/./NewsAggregator.Gateways.Api.csproj"
COPY . .
WORKDIR "/Gateways/NewsAggregator.Gateways.Api"
RUN dotnet build "./NewsAggregator.Gateways.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NewsAggregator.Gateways.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsAggregator.Gateways.Api.dll"]