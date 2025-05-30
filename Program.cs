using DotNetEnv;
using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Загрузка .env файла
Env.Load();
Env.TraversePath();

// Добавление сервисов в контейнер
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Настройка базы данных
var dbType = Environment.GetEnvironmentVariable("DB_TYPE")?.ToLower();
if (dbType == "postgres")
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql($"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
                         $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
                         $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                         $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
                         $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                         $"Timeout={Environment.GetEnvironmentVariable("DB_TIMEOUT")};"));
}
else if (dbType == "mssql")
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        var connectionString = $"Server={Environment.GetEnvironmentVariable("MSSQL_HOST")}," +
                                         $"{Environment.GetEnvironmentVariable("MSSQL_PORT")};" +
                                         $"Database={Environment.GetEnvironmentVariable("MSSQL_DB")};" +
                                         $"User Id={Environment.GetEnvironmentVariable("MSSQL_USER")};" +
                                         $"Password={Environment.GetEnvironmentVariable("MSSQL_PASSWORD")};" +
                                         "TrustServerCertificate=True";
        options.UseSqlServer(connectionString);
    });
}
else
{
    throw new Exception("Unsupported database type");
}

var app = builder.Build();

// Настройка HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

// Создание базы данных при запуске
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();// create if not exists
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Произошла ошибка при создании базы данных.");
    }
}

app.Run();
