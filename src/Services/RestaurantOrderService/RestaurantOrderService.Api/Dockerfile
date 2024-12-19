#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5008

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/RestaurantOrderService/RestaurantOrderService.Api/RestaurantOrderService.Api.csproj", "src/Services/RestaurantOrderService/RestaurantOrderService.Api/"]
COPY ["src/Services/RestaurantOrderService/RestaurantOrderService.Application/RestaurantOrderService.Application.csproj", "src/Services/RestaurantOrderService/RestaurantOrderService.Application/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Base/EventBus.Base.csproj", "src/MessageBrokers/EventBus/EventBus.Base/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Factory/EventBus.Factory.csproj", "src/MessageBrokers/EventBus/EventBus.Factory/"]
COPY ["src/MessageBrokers/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "src/MessageBrokers/EventBus/EventBus.RabbitMQ/"]
COPY ["src/Services/RestaurantOrderService/RestaurantOrderService.Domain/RestaurantOrderService.Domain.csproj", "src/Services/RestaurantOrderService/RestaurantOrderService.Domain/"]
COPY ["src/Services/RestaurantOrderService/RestaurantOrderService.Infrastructure/RestaurantOrderService.Infrastructure.csproj", "src/Services/RestaurantOrderService/RestaurantOrderService.Infrastructure/"]
COPY ["src/Services/RestaurantOrderService/RestaurantOrderService.Persistence/RestaurantOrderService.Persistence.csproj", "src/Services/RestaurantOrderService/RestaurantOrderService.Persistence/"]
RUN dotnet restore "./src/Services/RestaurantOrderService/RestaurantOrderService.Api/RestaurantOrderService.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/RestaurantOrderService/RestaurantOrderService.Api"
RUN dotnet build "./RestaurantOrderService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RestaurantOrderService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestaurantOrderService.Api.dll"]