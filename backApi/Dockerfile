FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS pictures_cloud_build
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["BackApi/BackApi.csproj", "BackendApi/"]
RUN dotnet restore "BackApi/BackApi.csproj"
COPY . .

WORKDIR "/src/BackeApi"
RUN dotnet build "BackApi.csproj" -c Release -o /app

FROM build as publish
RUN dotnet publish BackApi.csproj -c Release -o /app

FROM base As final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BackApi.csproj"]