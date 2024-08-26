// Определяется пространство имен Domain. 
// Обычно оно содержит классы, описывающие бизнес-логику и модели данных, 
// которые являются частью предметной области приложения.
namespace Domain
{
    // Класс Activity представляет сущность в доменной модели. 
    // В данном случае, он описывает какое-то мероприятие или активность. 
    // Этот класс будет использоваться как модель для хранения и управления данными.
    public class Activity
    {
       public Guid Id { get; set; }
       public string Title { get; set; }
       public DateTime Date { get; set; }
       public string Description { get; set; }
       public string Category { get; set; }
       public string City { get; set; }
       public string Venue { get; set; }
    }
}