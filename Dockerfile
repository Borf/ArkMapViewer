# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore

# Copy everything else and build
RUN dotnet publish -c Debug
RUN find /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/ArkMapViewer/bin/Debug/net9.0/publish .
ENTRYPOINT ["dotnet", "ArkMapViewer.dll"]
#ENTRYPOINT "/bin/bash"

EXPOSE 2004/tcp
ENV ASPNETCORE_URLS=http://+:2004
