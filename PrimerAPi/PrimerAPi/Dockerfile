# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app/PrimerAPi

# Copiar los archivos del proyecto
COPY . ./app/PrimerAPi

# Restaurar dependencias
RUN dotnet restore

# Construir la aplicación
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app/PrimerAPi
COPY --from=build /app/out ./

# Comando de inicio
ENTRYPOINT ["dotnet", "PrimerApi.dll"]
