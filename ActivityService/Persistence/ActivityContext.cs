using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ActivityContext : DbContext
    {
        public ActivityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
