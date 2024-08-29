using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
                

            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}










// Класс List в пространстве имен Application.Activities является частью прикладного уровня в архитектуре 
// Clean Architecture. Он отвечает за обработку запросов, 
// связанных с получением списка сущностей Activity из базы данных.


// Компоненты
// Класс Query:

// Назначение: Представляет запрос на получение списка активностей.
// Определение: public class Query : IRequest<List<Activity>>
// Описание: Реализует интерфейс IRequest из библиотеки MediatR, что указывает на то, что этот запрос должен вернуть List<Activity> при обработке.
// Класс Handler:

// Назначение: Содержит логику для обработки запроса Query и возвращения списка активностей.
// Определение: public class Handler : IRequestHandler<Query, List<Activity>>
// Зависимости:
// DataContext: Внедряется через конструктор, используется как контекст Entity Framework Core для доступа к базе данных.
// Метод:
// Handle(Query request, CancellationToken cancellationToken)
// Назначение: Этот метод вызывается MediatR при отправке запроса Query. Он асинхронно извлекает список активностей из базы данных.
// Реализация: Использует метод ToListAsync из Entity Framework Core для получения всех активностей из таблицы Activities.
// Использование
// Этот обработчик обычно используется в сценариях, 
// когда приложению нужно получить и отобразить список всех активностей, хранящихся в базе данных. 
// Он использует библиотеку MediatR для разделения ответственности в процессе запроса/ответа, что делает код более поддерживаемым и тестируемым.


// Заключение
// Обработчик List предоставляет чистый и эффективный способ извлечения данных из базы данных, 
// придерживаясь принципов Clean Architecture. Использование MediatR способствует слабой связности и гарантирует, 
// что бизнес-логика отделена от других аспектов, таких как доступ к данным и пользовательский интерфейс.