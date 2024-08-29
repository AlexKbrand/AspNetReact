
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}


// Использование в наследниках
// Контроллеры, наследующиеся от BaseApiController, получают доступ к медиатору через свойство Mediator, 
// что позволяет им отправлять запросы и команды через MediatR. 
// Это уменьшает дублирование кода, так как не нужно явно определять и внедрять IMediator в каждый контроллер.

// 5. Заключение
// BaseApiController служит для упрощения работы с MediatR и обеспечивает стандартизацию маршрутизации для всех контроллеров, 
// которые наследуются от него. Это позволяет сократить дублирование кода и централизовать доступ к медиатору, что делает код более чистым и поддерживаемым.