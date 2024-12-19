#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5001


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/IdentityService/Identity.Api/Identity.Api.csproj", "src/Services/IdentityService/Identity.Api/"]
COPY ["src/Services/IdentityService/Identity.Application/Identity.Application.csproj", "src/Services/IdentityService/Identity.Application/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Base/EventBus.Base.csproj", "src/MessageBrokers/EventBus/EventBus.Base/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Factory/EventBus.Factory.csproj", "src/MessageBrokers/EventBus/EventBus.Factory/"]
COPY ["src/MessageBrokers/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "src/MessageBrokers/EventBus/EventBus.RabbitMQ/"]
COPY ["src/Services/IdentityService/Identity.Domain/Identity.Domain.csproj", "src/Services/IdentityService/Identity.Domain/"]
COPY ["src/Services/IdentityService/Identity.Infrastructure/Identity.Infrastructure.csproj", "src/Services/IdentityService/Identity.Infrastructure/"]
COPY ["src/Services/IdentityService/Identity.Persistence/Identity.Persistence.csproj", "src/Services/IdentityService/Identity.Persistence/"]
RUN dotnet restore "./src/Services/IdentityService/Identity.Api/Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/IdentityService/Identity.Api"
RUN dotnet build "./Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]