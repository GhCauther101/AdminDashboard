# AdminDashboard
AdminDashboard - client and payment record system designed with ASP.NET Core & React Framework. Usefull to make record of taken payments. Allow to observe and convert currency rates of different countries with [ExchangeRate API](https://www.exchangerate-api.com/).

## Backend
- Microservice achitecture
- ASP.NET Core Web API gateway
- CQRS bus comand/query domain separation
- ASP.NET Core Identity based authentication
- Zero out build ExchangeRate-API SDK
- PostgreSQL database support
- Docker deploy support
- HTTPS (TLS) support for API gateway and services communication (also for gRPC services)

## Frontend
- Backend API gateway data and client support
- Vite React based web client
- Docker deploy support
- HTTPS (TLS) client - API gateway support


# Deploy
There are two ways to deploy AdminDashboard on local machine:
- Local machine based deploy
- Docker based deploy

## 1) Local machine deployment
Make sure that .NET 9.0 SDK is installed on your machine. Use `release.sh` script in `build` folder to prepare deploy executables.

Example:
`rel`