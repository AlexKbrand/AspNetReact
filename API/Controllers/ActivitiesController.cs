
using AppGlobalization.CultureInfoication.Activities;
using Application;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        
        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]//api/activities/fdfdfdfd
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            await Mediator.Send(new Create.Command{Activity = activity});

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
             await Mediator.Send(new Edit.Command{Activity = activity});
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await Mediator.Send(new Delete.Command{Id = id});
            return Ok();
        }
}
}




// Этот контроллер управляет CRUD (Create, Read) операциями для сущности Activity с использованием MediatR. 
// Контроллер разделяет обязанности, поручая бизнес-логику (например, создание и получение активностей) 
// соответствующим обработчикам в слое приложения. 
// Это способствует более чистому коду, лучшей тестируемости и гибкости при развитии приложения.