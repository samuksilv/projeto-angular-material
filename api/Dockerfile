FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["Portal.Api/Portal.Api.csproj", "Portal.Api/"]
COPY ["Portal.Domain/Portal.Domain.csproj", "Portal.Domain/"]
COPY ["Portal.Infra/Portal.Infra.csproj", "Portal.Infra/"]
RUN dotnet restore "Portal.Api/Portal.Api.csproj"
COPY . .
WORKDIR "/src/Portal.Api"
RUN dotnet build "Portal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Portal.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Portal.Api.dll"]
