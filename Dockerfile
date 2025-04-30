# Укажите используемый SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копируем .csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем все файлы и собираем приложение
COPY . ./
RUN dotnet publish -c Release -o out

# Укажите используемое runtime-окружение
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# # Укажите команду для запуска приложения
ENTRYPOINT ["dotnet", "MainAPI.dll"]

# Укажите порт, который будет использован
EXPOSE 8080
