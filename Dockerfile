# Imagen base para compilar
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Directorio de trabajo
WORKDIR /src

# Copia solo el archivo .csproj primero (para aprovechar el cache de Docker)
COPY ["ApiSincinaty/ApiSincinaty.csproj", "ApiSincinaty/"]
RUN dotnet restore "ApiSincinaty/ApiSincinaty.csproj"

# Copia el resto del código
COPY . .

# Establecer el directorio de trabajo donde está el proyecto
WORKDIR "/src/ApiSincinaty"

# Compilar la aplicación en modo Release
RUN dotnet publish "ApiSincinaty.csproj" -c Release -o /app/publish

# Imagen final, más liviana para ejecutar
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .

# Comando de inicio
ENTRYPOINT ["dotnet", "ApiSincinaty.dll"]
