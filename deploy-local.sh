#!/bin/bash

docker build -t dotnet-ci-app .
docker stop dotnet-ci-container || true
docker rm dotnet-ci-container || true
docker run -d -p 5000:80 --name dotnet-ci-container dotnet-ci-app
