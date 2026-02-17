#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0-focal AS base

WORKDIR /app
EXPOSE 80
ENV TZ America/Santiago
RUN apt-get update && apt-get install tzdata apt-utils libgdiplus libc6-dev -y
#ENV ASPNETCORE_URLS=http://+:80

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
#RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
#USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0-focal AS build
WORKDIR /src
COPY ["./API/Backend.Payroll.API/Backend.Payroll.API.csproj", "./API/Backend.Payroll.API/"]
RUN dotnet restore "./API/Backend.Payroll.API/Backend.Payroll.API.csproj"
COPY . .
WORKDIR "/src/API/Backend.Payroll.API/"
RUN dotnet build "Backend.Payroll.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.Payroll.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.Payroll.API.dll"]
