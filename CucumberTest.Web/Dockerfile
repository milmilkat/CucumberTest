#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CucumberTest.Web/CucumberTest.Web.csproj", "CucumberTest.Web/"]
COPY ["CucumberTest.Services/CucumberTest.Services.csproj", "CucumberTest.Services/"]
COPY ["CucumberTest.Business/CucumberTest.Business.csproj", "CucumberTest.Business/"]
RUN dotnet restore "CucumberTest.Web/CucumberTest.Web.csproj"
COPY . .
WORKDIR "/src/CucumberTest.Web"
RUN dotnet build "CucumberTest.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CucumberTest.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CucumberTest.Web.dll"]