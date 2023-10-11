using EventHubWebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventHubWebApi.Services.EventCategoryService
{
    public class EventCteoryService : IEventCategoryService
    {
        private readonly AppDbContext _context;

        public EventCteoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EventCategory> AddCategory(EventCategory eventCategory)
        {
            _context.EventCategories.Add(eventCategory);
            await _context.SaveChangesAsync();

            return eventCategory;
        }

        public async Task<List<EventCategory>> GetAllCategoreis()
        {
            return await _context.EventCategories.ToListAsync();
        }

        public async Task<EventCategory> GetSingleCategory(int id)
        {
            var result = await _context.EventCategories.FindAsync(id);

            if (result == null)
                return null;

            return result;
        }
    }
}
