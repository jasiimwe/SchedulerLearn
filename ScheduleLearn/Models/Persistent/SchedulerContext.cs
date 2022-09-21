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
        public DbSet<Division> Divisions { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Ward> Wards { get; set; }

    }
}
