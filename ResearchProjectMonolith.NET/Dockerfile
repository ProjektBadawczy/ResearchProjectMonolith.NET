FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ResearchProjectMonolith.NET/ResearchProjectMonolith.NET.csproj", "ResearchProjectMonolith.NET/"]
RUN dotnet restore "ResearchProjectMonolith.NET/ResearchProjectMonolith.NET.csproj"
COPY . .
WORKDIR "/src/ResearchProjectMonolith.NET"
RUN dotnet build "ResearchProjectMonolith.NET.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResearchProjectMonolith.NET.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResearchProjectMonolith.NET.dll"]
