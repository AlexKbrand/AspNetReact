
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();
                
            }
        }
    }
}



// Общий ход работы
// Когда создается новая активность, создается объект Command, который включает в себя объект Activity.
// Этот объект команды передается медиатору (MediatR), который находит соответствующий Handler и вызывает его метод Handle.
// Обработчик добавляет новую активность в базу данных и сохраняет изменения.
// Таким образом, код реализует логику создания новой активности и ее сохранения в базе данных, разделяя обязанности между командой и обработчиком.