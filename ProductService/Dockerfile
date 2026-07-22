# 1 Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# 2 Build phase
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductService/ProductService.csproj", "ProductService/"]
RUN dotnet restore "./ProductService/ProductService.csproj"
COPY . .
WORKDIR "/src/ProductService"
RUN dotnet build "./ProductService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3 Publish phase
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4 Final phase
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.dll"]