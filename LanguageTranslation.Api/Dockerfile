FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["LanguageTranslation.Api/LanguageTranslation.Api.csproj", "LanguageTranslation.Api/"]
COPY ["LanguageTranslation.Infastructure/LanguageTranslation.Infastructure.csproj", "LanguageTranslation.Infastructure/"]
COPY ["LanguageTranslation.Domain/LanguageTranslation.Domain.csproj", "LanguageTranslation.Domain/"]
RUN dotnet restore "LanguageTranslation.Api/LanguageTranslation.Api.csproj"
COPY . .
WORKDIR "/src/LanguageTranslation.Api"
RUN dotnet build "LanguageTranslation.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LanguageTranslation.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LanguageTranslation.Api.dll"]
