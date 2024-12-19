#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5005

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/RestaurantService/Restaurant.Api/Restaurant.Api.csproj", "src/Services/RestaurantService/Restaurant.Api/"]
COPY ["src/Services/RestaurantService/Restaurant.Application/Restaurant.Application.csproj", "src/Services/RestaurantService/Restaurant.Application/"]
COPY ["src/Services/RestaurantService/Restaurant.Domain/Restaurant.Domain.csproj", "src/Services/RestaurantService/Restaurant.Domain/"]
COPY ["src/Services/RestaurantService/Restaurant.Infrastructure/Restaurant.Infrastructure.csproj", "src/Services/RestaurantService/Restaurant.Infrastructure/"]
COPY ["src/Services/RestaurantService/Restaurant.Persistence/Restaurant.Persistence.csproj", "src/Services/RestaurantService/Restaurant.Persistence/"]
RUN dotnet restore "./src/Services/RestaurantService/Restaurant.Api/Restaurant.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/RestaurantService/Restaurant.Api"
RUN dotnet build "./Restaurant.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Restaurant.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurant.Api.dll"]