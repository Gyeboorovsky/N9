
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["N9_Server.csproj", "./"]
RUN dotnet restore "N9_Server.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "N9_Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N9_Server.csproj" -c Release -o /app/publish

# Zbuduj obraz runtime z opublikowaną aplikacją
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N9_Server.dll"]
