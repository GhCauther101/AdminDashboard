#stage 1 build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["..", "."]
RUN rm "./AdminDashboard.API/appsettings.json"
RUN mv "./AdminDashboard.API/appsettings.container.json" "./AdminDashboard.API/appsettings.json"

RUN dotnet restore './AdminDashboard.ExchangeService/AdminDashboard.ExchangeService.csproj'
RUN dotnet build "./AdminDashboard.ExchangeService/AdminDashboard.ExchangeService.csproj" -c Release -o /service/build

#stage 2 publish
FROM build AS publish
RUN dotnet publish "AdminDashboard.ExchangeService/AdminDashboard.ExchangeService.csproj" -c Release -o /service/publish /p:UseAppHost=false

#stage 3 launch
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS launch
WORKDIR /service
COPY --from=publish /service/publish .

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "AdminDashboard.ExchangeService.dll"]