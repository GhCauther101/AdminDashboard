# AdminDashboard
AdminDashboard - client and payment management system designed with ASP.NET Core & React Framework. Usefull to make record of taken payments. Allow to observe and convert currency rates of different countries with [ExchangeRate API](https://www.exchangerate-api.com/).

![Login](/assets/img/1.png)

![Login](/assets/img/5.png)

![Login](/assets/img/2.png)

## Backend
- Microservice achitecture
- ASP.NET Core Web API gateway
- CQRS bus comand/query domain separation
- ASP.NET Core Identity based authentication
- Docker deploy support
- HTTPS (TLS) support for API gateway and services communication (also for gRPC services)
- PostgreSQL database support
- Built from scratch [ExchangeRate-API](https://www.exchangerate-api.com/) SDK

## Frontend
- Backend API gateway data and client support
- Vite React based web client
- Docker deploy support
- HTTPS (TLS) client - API gateway support


# Deploy
There are two ways to deploy AdminDashboard:
- Local machine based deploy
- Docker based deploy

## 1) Local machine deployment
### ⚠️ Technical requirements 
Before deploying app on your machine make sure the technical requirements are been complyed:

- Windows: [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0), [Git Bash](https://git-scm.com/downloads)
- Linux: [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

1. Clone git repository: `git clone https://github.com/ggghosthat31/AdminDashboard`

2. Launch `build/local_release.sh <win-x64/linux-x64>` script for compilling app to deploy (win-x64 for Windows, linux-x64 for Linux deployment).

3. Copy executable from `out` folder to your deployment environment. (local machine, Azure, AWS, Google Cloud, self hosted cloud, etc)

4. To visit web app open `https://localhost:8000`. App working only with HTTS protocol.

## 2) Docker deployment
### ⚠️ Technical requirements 
Before deploying app in Docker containers make sure that [Docker](https://www.docker.com/) installed on your machine:

1. Clone git repository: `git clone https://github.com/ggghosthat31/AdminDashboard`

2. Launch `build/docker_deploy.sh` script to build images and run docker container.

3. To visit web app open `https://localhost:8000`. App working only with HTTS protocol.
