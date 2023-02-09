# Research Project .NET Monolith
> The program was prepared for the subject Research Project. 
## Table of contents
* [About The Project](#about-the-project)
* [Technologies](#technologies)
* [Getting Started](#getting-started)
* [Contact](#contact)

## About The Project

The aim of the project was to implement monolith application for graph's operations using ASP.NET Core technology.

## Technologies
* ASP.NET Core
* Docker

## ASP.NET Core

ASP.NET Core is an open-source and cross-platform framework for building modern cloud based internet connected applications, such as web apps, IoT apps and mobile backends. ASP.NET Core apps run on [.NET Core](https://dot.net), a free, cross-platform and open-source application runtime. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET Core apps cross-platform on Windows, Mac and Linux. [Learn more about ASP.NET Core](https://docs.microsoft.com/aspnet/core/).


## Getting Started
Clone the repository  
`git clone https://github.com/ProjektBadawczy/ResearchProjectMonolith.NET`  
  
Run application: `docker compose build --up`

## REST API
Get basic information about graph based on ID: http://localhost:8001/graph?id=53

Get maximum flow in graph - Edmonds-Karp algorithm: http://localhost:8001/edmondsKarpMaxGraphFlow?id=53&source=20&destination=90

Get maximum flow in graph - Push Relabel algorithm: http://localhost:8001/pushRelabelMaxGraphFlow?id=53&source=20&destination=90

## Contact
Weronika Piotrowska - weronika.piotrowska.pl@gmail.com
