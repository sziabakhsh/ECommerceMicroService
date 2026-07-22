1- Project Structure

MicroservicePractice
│
├── docker-compose.yml
│
├── ProductService
│   ├── Dockerfile
│   ├── ProductService.csproj
│   └── ...
│
├── OrderService
│   ├── Dockerfile
│   ├── OrderService.csproj
│   └── ...
│
└── README.md



2- Create DockerFile (For each web api project)
# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish
# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet","ProductService.dll"]

3- Docker commands
a- docker build -t productservice .
b- docker images      (for test and see the docker in the list)
c- docker run -p 5001:8080 productservice
then open the swagger in the browser
http://localhost:5001/swagger
4- Repeat steps 2 and 3 for all services

5- Create docker-compose.yml  side of solution

version: '3.8'

services:

  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    container_name: sqlserver
    environment:
      ACCEPT_EULA: "Y"
      SA_PASSWORD: "Sa@12345"
    ports:
      - "1433:1433"
    volumes:
      - sqlserver_data:/var/opt/mssql

  productservice:
    build:
      context: ./ProductService
    container_name: productservice
    depends_on:
      - sqlserver
    ports:
      - "5001:8080"

  orderservice:
    build:
      context: ./OrderService
    container_name: orderservice
    depends_on:
      - sqlserver
    ports:
      - "5002:8080"

volumes:
  sqlserver_data:
  


docker compose up -d --build
docker compose up -d sqlserver

docker ps -a
