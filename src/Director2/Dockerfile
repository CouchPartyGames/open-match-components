FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Director2/Director2.csproj", "src/Director2/"]
RUN dotnet restore "src/Director2/Director2.csproj"
COPY . .
WORKDIR "/src/src/Director2"
RUN dotnet build "Director2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Director2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Director2.dll"]
