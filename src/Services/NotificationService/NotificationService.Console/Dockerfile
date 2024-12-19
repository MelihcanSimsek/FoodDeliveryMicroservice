#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/NotificationService/NotificationService.Console/NotificationService.Console.csproj", "src/Services/NotificationService/NotificationService.Console/"]
COPY ["src/Services/NotificationService/NotificationService.Infrastructure/NotificationService.Infrastructure.csproj", "src/Services/NotificationService/NotificationService.Infrastructure/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Base/EventBus.Base.csproj", "src/MessageBrokers/EventBus/EventBus.Base/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Factory/EventBus.Factory.csproj", "src/MessageBrokers/EventBus/EventBus.Factory/"]
COPY ["src/MessageBrokers/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "src/MessageBrokers/EventBus/EventBus.RabbitMQ/"]
RUN dotnet restore "./src/Services/NotificationService/NotificationService.Console/NotificationService.Console.csproj"
COPY . .
WORKDIR "/src/src/Services/NotificationService/NotificationService.Console"
RUN dotnet build "./NotificationService.Console.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NotificationService.Console.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotificationService.Console.dll"]