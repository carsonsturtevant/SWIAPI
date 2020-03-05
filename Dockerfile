FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o /app --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["./swiapi"]