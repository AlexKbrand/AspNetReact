using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Эти строки добавляют поддержку Swagger — инструмента для документирования и тестирования API.
            // AddEndpointsApiExplorer необходим для отображения информации о маршрутах API, а AddSwaggerGen генерирует спецификацию OpenAPI для API.
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Добавляет DataContext (контекст данных) в контейнер зависимостей, который используется для взаимодействия с базой данных.
            // UseSqlite указывает на использование SQLite в качестве базы данных, а строка подключения берется из конфигурации приложения.
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // Добавляет поддержку CORS (Cross-Origin Resource Sharing) для разрешения запросов от клиента на React, работающего на http://localhost:3000.
            // AllowAnyHeader и AllowAnyMethod позволяют использовать любые заголовки и методы HTTP.
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .WithOrigins("http://localhost:3000");
                });
            });

            // Добавляет MediatR в контейнер зависимостей, что позволяет использовать паттерн Mediator для обработки команд и запросов.
            // RegisterServicesFromAssembly регистрирует все обработчики команд и запросов, находящиеся в сборке, где определен List.Handler.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));

            // Добавляет AutoMapper в контейнер зависимостей, который используется для автоматического маппинга объектов между различными моделями.
            // Регистрирует все профили маппинга, определенные в сборке, где находится класс MappingProfiles.
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}
