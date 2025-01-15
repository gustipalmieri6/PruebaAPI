# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar los archivos del proyecto
COPY . ./

# Restaurar dependencias y publicar la aplicación
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Comando de inicio
ENTRYPOINT ["dotnet", "TuProyecto.dll"]
