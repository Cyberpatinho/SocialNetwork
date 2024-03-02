# Use SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 80

# Copy csproj and restore as distinct layers
COPY ["Gateway/Gateway.csproj", "src/Gateway/"]
RUN dotnet restore "src/Gateway/Gateway.csproj"

COPY . src/

WORKDIR /app/src/Gateway
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "Gateway.dll" ]