FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Teledoc.API/Teledoc.API.csproj", "Teledoc.API/"]
RUN dotnet restore "Teledoc.API/Teledoc.API.csproj"
COPY . .
WORKDIR "/src/Teledoc.API"
RUN dotnet build "Teledoc.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teledoc.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teledoc.API.dll"]
