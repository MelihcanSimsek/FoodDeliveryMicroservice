#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5007


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/CourierService/CourierService.Api/CourierService.Api.csproj", "src/Services/CourierService/CourierService.Api/"]
COPY ["src/Services/CourierService/CourierService.Application/CourierService.Application.csproj", "src/Services/CourierService/CourierService.Application/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Factory/EventBus.Factory.csproj", "src/MessageBrokers/EventBus/EventBus.Factory/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Base/EventBus.Base.csproj", "src/MessageBrokers/EventBus/EventBus.Base/"]
COPY ["src/MessageBrokers/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "src/MessageBrokers/EventBus/EventBus.RabbitMQ/"]
COPY ["src/Services/CourierService/CourierService.Domain/CourierService.Domain.csproj", "src/Services/CourierService/CourierService.Domain/"]
COPY ["src/Services/CourierService/CourierService.Infrastructure/CourierService.Infrastructure.csproj", "src/Services/CourierService/CourierService.Infrastructure/"]
COPY ["src/Services/CourierService/CourierService.Persistence/CourierService.Persistence.csproj", "src/Services/CourierService/CourierService.Persistence/"]
RUN dotnet restore "./src/Services/CourierService/CourierService.Api/CourierService.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/CourierService/CourierService.Api"
RUN dotnet build "./CourierService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CourierService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourierService.Api.dll"]