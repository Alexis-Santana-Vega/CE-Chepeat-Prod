#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
ENV DB_CONNECTION_STRING="Server=34.173.108.32;Database=ChepeatDev;User Id=sqlserver;Password='ASV5499A';TrustServerCertificate=True;"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CE.Chepeat.API/CE.Chepeat.API.csproj", "CE.Chepeat.API/"]
COPY ["CE.Chepeat.Application/CE.Chepeat.Application.csproj", "CE.Chepeat.Application/"]
COPY ["CE.Chepeat.Domain/CE.Chepeat.Domain.csproj", "CE.Chepeat.Domain/"]
COPY ["CE.Chepeat.Infraestructure/CE.Chepeat.Infraestructure.csproj", "CE.Chepeat.Infraestructure/"]
RUN dotnet restore "./CE.Chepeat.API/CE.Chepeat.API.csproj"
COPY . .
WORKDIR "/src/CE.Chepeat.API"
RUN dotnet build "./CE.Chepeat.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CE.Chepeat.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:$PORT
ENTRYPOINT ["dotnet", "CE.Chepeat.API.dll"]