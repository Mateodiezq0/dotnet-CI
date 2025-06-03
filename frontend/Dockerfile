# Etapa 1: build del frontend
FROM node:18 AS build
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build

# Etapa 2: server estático con `serve`
FROM node:18 AS runner
WORKDIR /app

RUN npm install -g serve
COPY --from=build /app/dist .

EXPOSE 3000
CMD ["serve", "-s", ".", "-l", "3000"]
