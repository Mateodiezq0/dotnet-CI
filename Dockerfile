# Etapa 1: Construcción del frontend (Svelte + Node.js)
FROM node:16 AS frontend

WORKDIR /frontend

# Copiar los archivos de Node.js (frontend)
COPY frontend/package*.json ./
RUN npm install
COPY frontend/ ./

# Construir el frontend
RUN npm run build

# Etapa 2: Construcción del backend (.NET)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

# Copiar los archivos del proyecto .NET
COPY . . 

# Publicar la aplicación .NET
RUN dotnet publish src/dotnet-ci.csproj -c Release -o /app/publish

# Etapa 3: Servir el backend y frontend
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

# Copiar la aplicación .NET desde la etapa de construcción
COPY --from=build /app/publish .

# Copiar el frontend (archivos estáticos generados por Svelte) al directorio público del servidor .NET
COPY --from=frontend /frontend/public /app/wwwroot

# Exponer el puerto de la aplicación .NET
EXPOSE 80

# Ejecutar la aplicación .NET
ENTRYPOINT ["dotnet", "dotnet-ci.dll"]
