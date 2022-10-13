#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClearBank.DeveloperTest.WebApi/ClearBank.DeveloperTest.WebApi.csproj", "ClearBank.DeveloperTest.WebApi/"]
RUN dotnet restore "ClearBank.DeveloperTest.WebApi/ClearBank.DeveloperTest.WebApi.csproj"
COPY . .
WORKDIR "/src/ClearBank.DeveloperTest.WebApi"
RUN dotnet build "ClearBank.DeveloperTest.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClearBank.DeveloperTest.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClearBank.DeveloperTest.WebApi.dll"]