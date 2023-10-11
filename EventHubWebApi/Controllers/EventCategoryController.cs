using EventHubWebApi.Services.EventCategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventHubWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryController : ControllerBase
    {
        private readonly IEventCategoryService _eventCategoryService;
        public EventCategoryController(IEventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }

        [HttpGet("eventcategories")]
        public async Task<ActionResult<List<EventCategory>>> GetAllCategories()
        {
            return await _eventCategoryService.GetAllCategoreis();
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<EventCategory>> GetSingleCategory(int id)
        {
            return await _eventCategoryService.GetSingleCategory(id);
        }

        [HttpPost("create")]
        public async Task<ActionResult<EventCategory>> AddEventCategory(EventCategory eventCategory)
        {
            return await _eventCategoryService.AddCategory(eventCategory);
        }
    }
}
