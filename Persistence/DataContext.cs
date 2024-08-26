// Эти пространства имен подключаются для использования сущностей домена 
// (Domain) и функциональности Entity Framework Core (Microsoft.EntityFrameworkCore), 
// который обеспечивает работу с базой данных.
using Domain;
using Microsoft.EntityFrameworkCore;


// Определяется пространство имен Persistence, в котором будет находиться класс DataContext. 
// Обычно в этом пространстве имен находятся все классы, связанные с доступом к данным, например, контексты и репозитории.
namespace Persistence
{

    // Класс DataContext наследуется от DbContext, предоставляемого Entity Framework Core. 
    // DbContext управляет подключением к базе данных и выполняет операции с данными (CRUD).
    public class DataContext : DbContext
    {
        // Конструктор класса DataContext принимает параметры конфигурации (DbContextOptions) и передает их в базовый класс DbContext. 
        // Это позволяет настроить контекст, например, указать тип базы данных и строку подключения.
        public DataContext(DbContextOptions options): base(options)
        {

        }

        // Свойство DbSet<Activity> представляет собой коллекцию сущностей типа Activity, 
        // которые будут храниться в базе данных. DbSet используется для выполнения операций с таблицей базы данных, 
        // соответствующей сущности Activity.csharp
        public DbSet<Activity> Activities { get; set; }
        
        
    }
}