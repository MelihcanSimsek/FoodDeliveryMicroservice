#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5006


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/MenuService/Menu.Api/Menu.Api.csproj", "src/Services/MenuService/Menu.Api/"]
COPY ["src/Services/MenuService/Menu.Application/Menu.Application.csproj", "src/Services/MenuService/Menu.Application/"]
COPY ["src/Services/MenuService/Menu.Domain/Menu.Domain.csproj", "src/Services/MenuService/Menu.Domain/"]
COPY ["src/Services/MenuService/Menu.Infrastructure/Menu.Infrastructure.csproj", "src/Services/MenuService/Menu.Infrastructure/"]
COPY ["src/Services/MenuService/Menu.Persistence/Menu.Persistence.csproj", "src/Services/MenuService/Menu.Persistence/"]
RUN dotnet restore "./src/Services/MenuService/Menu.Api/Menu.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/MenuService/Menu.Api"
RUN dotnet build "./Menu.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Menu.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Menu.Api.dll"]