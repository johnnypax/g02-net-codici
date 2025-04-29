# COSTRUZIONE
# Fase 1: setup del SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Fase 2: Risoluzione delle dipendenze
COPY 01_MinimalIntro.csproj ./
RUN dotnet restore

# Fase 3: Creazione dell'eseguibile
COPY . ./
RUN dotnet publish -c Release -o /out

# AVVIO
# Fase 4: setup del RUNTIME
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS run
WORKDIR /app

# Fase 5: Copio l'output nella cartella app dello stage run
COPY --from=build /out ./

# Fase 6: Esposizione della porta del servizio in release
EXPOSE 8080

ENTRYPOINT [ "dotnet", "01_MinimalIntro.dll" ]