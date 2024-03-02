# Use SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 80

# Copy csproj and restore as distinct layers
COPY ["WebApi/WebApi.csproj", "src/WebApi/"]
COPY ["Application/Application.csproj", "src/Application/"]
COPY ["Domain/Domain.csproj", "src/Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
RUN dotnet restore "src/WebApi/WebApi.csproj"

COPY . src/

WORKDIR /app/src/WebApi
RUN dotnet publish -c Release -o /app/src/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "WebApi.dll" ]