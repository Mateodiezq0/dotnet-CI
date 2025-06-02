@echo off
echo ==== DEPLOYING LOCAL .NET CONTAINER ====
docker stop dotnet-app
docker rm dotnet-app
docker build -t dotnet-app .
docker run -d -p 5001:80 --name dotnet-app dotnet-app
