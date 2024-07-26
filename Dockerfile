# Use the official .NET image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY StudentApp.csproj .
RUN dotnet restore StudentApp.csproj
COPY . .
RUN dotnet build StudentApp.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish StudentApp.csproj -c Release -o /app/publish

# Copy the build app to the base image and run
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentApp.dll"]
