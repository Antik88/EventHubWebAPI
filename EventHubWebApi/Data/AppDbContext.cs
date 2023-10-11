using EventHubWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHubWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventImages> EventImages { get; set; }
        public DbSet<EventReview> EventReviews { get; set; }
    }
}
