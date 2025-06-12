# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiar el archivo .csproj y restaurar las dependencias
COPY src/dotnet-ci.csproj . 
RUN dotnet restore

# Copiar el resto del código y compilar el proyecto
COPY src/. ./ 
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa de build
COPY --from=build /app/publish .

# Copiar los archivos de cobertura y otros generados a la imagen
COPY frontend/public/coverage /app/frontend/public/coverage
COPY src/coverage /app/src/coverage

# Hacer accesibles los archivos estáticos (HTML de cobertura)
# Si usas un servidor web para servir archivos estáticos en el backend
# Asegúrate de que el contenedor pueda acceder a estos archivos estáticos

# Configurar el contenedor para ejecutar la aplicación
ENTRYPOINT ["dotnet", "dotnet-ci.dll"]
