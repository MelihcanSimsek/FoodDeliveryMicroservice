#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5002


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/BasketService/BasketService.Api/BasketService.Api.csproj", "src/Services/BasketService/BasketService.Api/"]
COPY ["src/Services/PaymentService/BasketService.Infrastructure/BasketService.Infrastructure.csproj", "src/Services/PaymentService/BasketService.Infrastructure/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Base/EventBus.Base.csproj", "src/MessageBrokers/EventBus/EventBus.Base/"]
COPY ["src/MessageBrokers/EventBus/EventBus.Factory/EventBus.Factory.csproj", "src/MessageBrokers/EventBus/EventBus.Factory/"]
COPY ["src/MessageBrokers/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "src/MessageBrokers/EventBus/EventBus.RabbitMQ/"]
COPY ["src/Services/BasketService/BasketService.Application/BasketService.Application.csproj", "src/Services/BasketService/BasketService.Application/"]
COPY ["src/Services/BasketService/BasketService.Domain/BasketService.Domain.csproj", "src/Services/BasketService/BasketService.Domain/"]
COPY ["src/Services/BasketService/BasketService.Persistence/BasketService.Persistence.csproj", "src/Services/BasketService/BasketService.Persistence/"]
RUN dotnet restore "./src/Services/BasketService/BasketService.Api/BasketService.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/BasketService/BasketService.Api"
RUN dotnet build "./BasketService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BasketService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketService.Api.dll"]