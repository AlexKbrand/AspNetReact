// Эти строки подключают необходимые пространства имен. 
// Microsoft.EntityFrameworkCore предоставляет функции для работы с Entity Framework Core, 
// а Persistence — это пространство имен, где находится контекст данных DataContext.
using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

// Создается объект builder, который отвечает за настройку и конфигурацию приложения. 
// Он используется для добавления сервисов и настройки различных компонентов приложения.
var builder = WebApplication.CreateBuilder(args);


// Добавляются необходимые сервисы в контейнер зависимостей (Dependency Injection, DI). 
// В данном случае добавляется поддержка контроллеров для обработки HTTP-запросов.
builder.Services.AddControllers();


builder.Services.AddApplicationServices(builder.Configuration);




// Создается экземпляр приложения с учетом всех ранее настроенных сервисов и компонентов.
var app = builder.Build();



// Настраивается конвейер обработки запросов (middleware). 
// Если приложение запущено в режиме разработки, включается Swagger для генерации и отображения документации API.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Добавляется Cors 
app.UseCors("CorsPolicy");

// Добавляется middleware для обработки авторизации. 
// Несмотря на то, что в примере нет настройки аутентификации, 
// этот middleware готов для использования, если будет добавлена авторизация.
app.UseAuthorization();


// Настраивается маршрутизация для контроллеров. 
// Это позволяет приложению сопоставлять входящие HTTP-запросы с методами контроллеров.
app.MapControllers();



// Создается новая область (scope) для разрешения зависимостей. 
// Это необходимо для безопасного использования служб с ограниченной областью видимости, 
// таких как DataContext, в ходе выполнения приложения.
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;




// В блоке try-catch происходит получение контекста данных и выполнение миграций базы данных при запуске приложения. 
// Это автоматически применяет незапущенные миграции, если они существуют. 
// В случае ошибки логируется информация об исключении с использованием встроенного механизма логирования.
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    
   var logger = services.GetRequiredService<ILogger<Program>>();
   logger.LogError(ex, "An error occurred during migrating");
}


// Запускается веб-приложение и начинает обрабатывать входящие запросы.
app.Run();
