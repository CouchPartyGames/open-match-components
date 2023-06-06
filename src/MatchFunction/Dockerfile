

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
LABEL org.opencontainers.image.source https://github.com/couchpartygames/open-match-components
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "tournament-backend.dll"]

