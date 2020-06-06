#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MicroBackend.Authorization.Api/MicroBackend.Authorization.Api.csproj", "MicroBackend.Authorization.Api/"]
RUN dotnet restore "MicroBackend.Authorization.Api/MicroBackend.Authorization.Api.csproj"
COPY . .
WORKDIR "/src/MicroBackend.Authorization.Api"
RUN dotnet build "MicroBackend.Authorization.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroBackend.Authorization.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroBackend.Authorization.Api.dll"]