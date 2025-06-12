# Etapa 1: Construcción del backend (.NET)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY . .
RUN dotnet publish src/dotnet-ci.csproj -c Release -o /app/publish

# Etapa 2: Runtime (Ejecutar la aplicación .NET)
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copiar el backend publicado
COPY --from=build /app/publish .

# Exponer el puerto que usa la aplicación .NET
EXPOSE 80

# Configurar el entrypoint para la aplicación .NET
ENTRYPOINT ["dotnet", "dotnet-ci.dll"]
