FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["EchoServer/EchoServer.csproj", "EchoServer/"]
RUN dotnet restore "EchoServer/EchoServer.csproj"
COPY . .
WORKDIR "/src/EchoServer"
RUN dotnet build "EchoServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EchoServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Enterprisecoding.EchoServer.dll"]