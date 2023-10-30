FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/GameFrontend/GameFrontend.csproj", "src/GameFrontend/"]
RUN dotnet restore "src/GameFrontend/GameFrontend.csproj"
COPY . .
WORKDIR "/src/src/GameFrontend"
RUN dotnet build "GameFrontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameFrontend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameFrontend.dll"]
