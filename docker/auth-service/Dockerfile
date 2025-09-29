ARG DOTNET_VERSION=8.0

# Build
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

WORKDIR /src

COPY apps/AuthService/AuthService.sln ./
COPY apps/AuthService/src/AuthService.API/AuthService.API.csproj ./src/AuthService.API/
COPY apps/AuthService/src/AuthService.Application/AuthService.Application.csproj ./src/AuthService.Application/
COPY apps/AuthService/src/AuthService.Domain/AuthService.Domain.csproj ./src/AuthService.Domain/
COPY apps/AuthService/src/AuthService.Infrastructure/AuthService.Infrastructure.csproj ./src/AuthService.Infrastructure/

RUN dotnet restore AuthService.sln

COPY apps/AuthService/ ./

WORKDIR /src/src/AuthService.API

EXPOSE 5001

CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5001"]
