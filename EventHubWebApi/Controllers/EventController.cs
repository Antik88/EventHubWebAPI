using EventHubWebApi.Services.EventService;
using EventHubWebApi.Services.ImageManagerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace EventHubWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IManageImagecs _iManageImage;
        private readonly IEventServicecs _eventServicecs;
        public EventController(IManageImagecs manageImagecs, IEventServicecs eventServicecs)
        {
            _iManageImage = manageImagecs;
            _eventServicecs = eventServicecs;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            return await _eventServicecs.GetAllEvents();
        }

        [HttpGet("event/{id}")]
        public async Task<ActionResult<Event>> GetSingleEvent(int id)
        {
            var result = _eventServicecs.GetSigneEvent(id);

            if (result == null)
                return NotFound("No event");

            return await result; 
        }

        [HttpPut("upd/{id}")]
        public async Task<ActionResult<Event>> UpdateEvent(int id, Event @event)
        {
            var result = _eventServicecs.UpdateEvent(id, @event);

            if (result == null)
                return NotFound("Event not found");

            return await result;
        }

        [HttpDelete("del/{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var result = await _eventServicecs.DeleteEvent(id);

            if (result == null)
                return NotFound("Event not found");

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Event>> AddEvent(Event newEvent, int categoryId) 
        {
            return await _eventServicecs.AddEvent(newEvent, categoryId);
        }

        [HttpPut("reg"), Authorize]
        public async Task<ActionResult<string>> RegistrationUser(int eventId)
        {
            return await _eventServicecs.RegistrationUser(eventId);
        }

        [HttpGet("serarch")]
        public async Task<ActionResult<List<Event>>> SearchEvent(string eventName)
        {
            return await _eventServicecs.SearchEvent(eventName);
        }

        [HttpPost("addReview")]
        public async Task<ActionResult<EventReview>> AddReview(int eventId, int userId, EventReview review)
        {
            return null;
        }

        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> UploadFile(IFormFile _IFormFile, int eventId)
        {
            var result = await _iManageImage.UploadFile(_IFormFile, eventId);
            return Ok(result);
        }

        [HttpGet]
        [Route("getFile")]
        public async Task<IActionResult> DownloadFile(string FileName)
        {
            var result = await _iManageImage.DownloadFile(FileName);
            return File(result.Item1, result.Item2, result.Item2);
        }
    }
}
