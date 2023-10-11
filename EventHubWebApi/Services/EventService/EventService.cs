using EventHubWebApi.Data;
using EventHubWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace EventHubWebApi.Services.EventService
{
    public class EventService : IEventServicecs
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public EventService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<Event> AddEvent(Event newEvent, int categoryId)
        {

            var eventCategory = await _context.EventCategories.FindAsync(categoryId);
            if (eventCategory == null)
                return null;

            newEvent.EventCategory = eventCategory;

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            return newEvent;
        }

        public async Task<Event> AddReview(int eventId, int userId, EventReview review)
        {
            var @event = await _context.Events.FindAsync(eventId);
            var user = await _context.Users.FindAsync(userId);

            _context.EventReviews.Add(review);

            if (@event == null|| review == null || user == null)
                return null;

            await _context.SaveChangesAsync();
            return @event;


        }
        public async Task<Event?> DeleteEvent(int id)
        {
            var deletEvent = _context.Events.Find(id);

            if (deletEvent == null)
                return null;

            _context.Events.Remove(deletEvent);
            await _context.SaveChangesAsync();

            return deletEvent;
        }

        public async Task<List<Event>> GetAllEvents()
        {
            var result = await _context.Events.ToListAsync();
            return result;
        }

        public async Task<Event> GetSigneEvent(int id)
        {
            var result = await _context.Events.FindAsync(id);

            if(result == null)
                return null;

            return result;
        }

        public async Task<string> RegistrationUser(int eventId)
        {
            var @event = await _context.Events.FindAsync(eventId);
            var userId = _contextAccessor.HttpContext.User
                .Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _context.Users.FindAsync(int.Parse(userId));

            @event.Users.Add(user);

            await _context.SaveChangesAsync();

            return $"User {user.Name} was registred to event {@event.EventName}";
        }

        public async Task<List<Event>> SearchEvent(string eventName)
        {
            var eventList = await _context.Events.ToListAsync();

            var result = eventList.FindAll(e => e.EventName.Contains(eventName));

            if (result == null)
                return null;

            return result;
        }

        public async Task<Event?> UpdateEvent(int id, Event newEvent)
        {
            var @event = await _context.Events.FindAsync(id);

            if(@event == null)
                return null;

            @event.EventCategory = newEvent.EventCategory;
            @event.EventName = newEvent.EventName;
            @event.EventTime = newEvent.EventTime;
            @event.IsOpenEvent = newEvent.IsOpenEvent;
            @event.Description = newEvent.Description;
            @event.Place = newEvent.Place;

            await _context.SaveChangesAsync();

            return @event;
        }
    }
}
