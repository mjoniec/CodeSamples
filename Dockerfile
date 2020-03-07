#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Test2.Api/Test2.Api.csproj", "Test2.Api/"]
COPY ["Test2.Model/Test2.Model.csproj", "Test2.Model/"]
RUN dotnet restore "Test2.Api/Test2.Api.csproj"
COPY . .
WORKDIR "/src/Test2.Api"
RUN dotnet build "Test2.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test2.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test2.Api.dll"]