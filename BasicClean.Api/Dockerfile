#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BasicClean.Api/BasicClean.Api.csproj", "BasicClean.Api/"]
COPY ["BasicClean.Infrastructure/BasicClean.Infrastructure.csproj", "BasicClean.Infrastructure/"]
COPY ["BasicClean.Core/BasicClean.Core.csproj", "BasicClean.Core/"]
RUN dotnet restore "BasicClean.Api/BasicClean.Api.csproj"
COPY . .
WORKDIR "/src/BasicClean.Api"
RUN dotnet build "BasicClean.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicClean.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicClean.Api.dll"]