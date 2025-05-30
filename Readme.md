# Employee API

Веб-приложение для управления сотрудниками с использованием .NET и Entity Framework Core.

## Требования

- .NET 8.0 SDK
- Docker и Docker Compose
- PostgreSQL или MSSQL (запускается через Docker)

## Настройка

1. Создайте файл `.env` в корневой директории проекта со следующим содержимым:

```env
# Тип базы данных (postgres или mssql)
DB_TYPE=postgres

# Настройки PostgreSQL
DB_HOST=192.168.9.23
DB_PORT=5432
DB_NAME=employeedb
DB_USER=postgres
DB_PASSWORD=postgres

# Настройки MSSQL
MSSQL_HOST=192.168.9.23
MSSQL_PORT=1433
MSSQL_DB=employeedb
MSSQL_USER=sa
MSSQL_PASSWORD=YourStrong@Passw0rd
```

## Запуск

### 1. Запуск баз данных

```bash
# Запуск контейнеров с базами данных
docker-compose up -d

# Проверка статуса контейнеров
docker-compose ps
```

### 2. Запуск приложения

```bash
# Переход в директорию проекта
cd EmployeeApi

# Восстановление зависимостей
dotnet restore

# Запуск приложения
dotnet run
```

После запуска приложение будет доступно по адресам:
- https://localhost:5001
- http://localhost:5000

## API Endpoints

- GET /api/employee - получить список всех сотрудников
- GET /api/employee/{id} - получить сотрудника по ID
- POST /api/employee - создать нового сотрудника
- PUT /api/employee/{id} - обновить сотрудника
- DELETE /api/employee/{id} - удалить сотрудника

## Swagger UI

Документация API доступна через Swagger UI:
- https://localhost:5001/swagger
- http://localhost:5000/swagger
