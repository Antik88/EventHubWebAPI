namespace EventHubWebApi.Services.EventService
{
    public interface IEventServicecs
    {
        Task<List<Event>> GetAllEvents();
        Task<Event> GetSigneEvent(int id);
        Task<Event> AddEvent(Event newEvent, int id);
        Task<Event?> UpdateEvent(int id, Event @event);
        Task<Event?> DeleteEvent(int id);
        Task<string?> RegistrationUser(int eventId);
        Task<List<Event>> SearchEvent(string eventName);
        Task<Event> AddReview(int eventId, int userId, EventReview review);
    }
}
