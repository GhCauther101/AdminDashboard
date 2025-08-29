#stage 1 build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["..", "."]
RUN rm "./AdminDashboard.API/appsettings.json"
RUN mv "./AdminDashboard.API/appsettings.container.json" "./AdminDashboard.API/appsettings.json"

RUN dotnet restore "./AdminDashboard.API/AdminDashboard.API.csproj"
RUN dotnet build "./AdminDashboard.API/AdminDashboard.API.csproj" -c Release -o /app/build

#stage 2 publish
FROM build AS publish
RUN dotnet publish "AdminDashboard.API/AdminDashboard.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

#stage 3 launch
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS launch
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8000
EXPOSE 8080

ENTRYPOINT ["dotnet", "AdminDashboard.API.dll"]