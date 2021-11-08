#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AzureContainerApps/AzureContainerApps.csproj", "AzureContainerApps/"]
RUN dotnet restore "AzureContainerApps/AzureContainerApps.csproj"
COPY . .
WORKDIR "/src/AzureContainerApps"
RUN dotnet build "AzureContainerApps.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzureContainerApps.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzureContainerApps.dll"]