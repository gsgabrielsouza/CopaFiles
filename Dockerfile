FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app
EXPOSE 80


# Copy csproj and restore as distinct layers
# COPY src/MovieCup.API/*.csproj ./
COPY src/MovieCup.API/MovieCup.API.csproj src/MovieCup.API/
COPY src/MovieCup.Application/MovieCup.Application.csproj src/MovieCup.Application/
COPY src/MovieCup.Domain/MovieCup.Domain.csproj src/MovieCup.Domain/
COPY src/MovieCup.Infra.IoC/MovieCup.Infra.IoC.csproj src/MovieCup.Infra.IoC/
COPY src/MovieCup.Infra.Integration.Filmes/MovieCup.Infra.Integration.Filmes.csproj src/MovieCup.Infra.Integration.Filmes/

RUN dotnet restore src/MovieCup.API 

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o /app 

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.0
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "MovieCup.API.dll"]
