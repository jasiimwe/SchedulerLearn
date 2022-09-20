using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace ScheduleLearnApi.Models.Persistent
{
    public class SchedulerContext : DbContext
    {
        public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Director> Directors { get; set; }

        public DbSet<HealthCenter> HealthCenters { get; set; }

    }
}
