FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
WORKDIR /app
COPY bin/Release/net7.0/publish .
ENTRYPOINT ["dotnet", "TarkovStats.Web.dll"]
