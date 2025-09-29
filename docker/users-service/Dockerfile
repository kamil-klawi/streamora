ARG DOTNET_VERSION=8.0

# Build
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

WORKDIR /src

COPY apps/UsersService/UsersService.sln ./
COPY apps/UsersService/src/UsersService.API/UsersService.API.csproj ./src/UsersService.API/
COPY apps/UsersService/src/UsersService.Application/UsersService.Application.csproj ./src/UsersService.Application/
COPY apps/UsersService/src/UsersService.Domain/UsersService.Domain.csproj ./src/UsersService.Domain/
COPY apps/UsersService/src/UsersService.Infrastructure/UsersService.Infrastructure.csproj ./src/UsersService.Infrastructure/

RUN dotnet restore UsersService.sln

COPY apps/UsersService/ ./

WORKDIR /src/src/UsersService.API

EXPOSE 5002

CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5002"]
