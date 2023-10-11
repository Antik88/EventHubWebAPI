namespace EventHubWebApi.Services.EventCategoryService
{
    public interface IEventCategoryService 
    {
        Task<List<EventCategory>> GetAllCategoreis();

        Task<EventCategory> GetSingleCategory(int id);

        Task<EventCategory> AddCategory(EventCategory eventCategory);
    }
}
