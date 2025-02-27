# Backend
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY *.csproj .
COPY Controllers/ ./Controllers/
COPY Properties/ ./Properties/
COPY Program.cs .
COPY appsettings*.json ./
RUN dotnet restore
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "backend.dll"]