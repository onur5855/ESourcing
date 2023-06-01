#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ESourcing.sourcing/ESourcing.sourcing.csproj", "ESourcing.sourcing/"]
RUN dotnet restore "ESourcing.sourcing/ESourcing.sourcing.csproj"
COPY . .
WORKDIR "/src/ESourcing.sourcing"
RUN dotnet build "ESourcing.sourcing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ESourcing.sourcing.csproj" -c Release -o /app/publish # /p:UseAppHost=false istenen port numarasýndan kalkmasýný engelliyor

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ESourcing.sourcing.dll"]