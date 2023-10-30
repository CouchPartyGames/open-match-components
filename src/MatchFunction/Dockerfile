FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/MatchFunction/MatchFunction.csproj", "src/MatchFunction/"]
RUN dotnet restore "src/MatchFunction/MatchFunction.csproj"
COPY . .
WORKDIR "/src/src/MatchFunction"
RUN dotnet build "MatchFunction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MatchFunction.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatchFunction.dll"]
