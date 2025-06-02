FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/OrderInventory.OrderApi/OrderInventory.OrderApi.csproj", "src/OrderInventory.OrderApi/"]
RUN dotnet restore "src/OrderInventory.OrderApi/OrderInventory.OrderApi.csproj"
COPY . .
WORKDIR "/src/src/OrderInventory.OrderApi"
RUN dotnet build "./OrderInventory.OrderApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OrderInventory.OrderApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderInventory.OrderApi.dll"]
