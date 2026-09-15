# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore
COPY ["TAYF.API/TAYF.API.csproj", "TAYF.API/"]
COPY ["TAYF.Application/TAYF.Application.csproj", "TAYF.Application/"]
COPY ["TAYF.Domain/TAYF.Domain.csproj", "TAYF.Domain/"]
COPY ["TAYF.Infrastructure/TAYF.Infrastructure.csproj", "TAYF.Infrastructure/"]

RUN dotnet restore "TAYF.API/TAYF.API.csproj"

# Copy everything else
COPY . .

# Build and publish
WORKDIR "/src/TAYF.API"
RUN dotnet publish "TAYF.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Copy seed data
COPY --from=build /src/TAYF.Infrastructure/Seed /app/Seed

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "TAYF.API.dll"]
