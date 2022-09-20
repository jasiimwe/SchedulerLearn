using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Persistent;

namespace ScheduleLearnApi.Repository
{
    public class HealthCenterRepository : IHealthCenterRepository
    {
        private readonly SchedulerContext _context;
        public HealthCenterRepository(SchedulerContext context)
        {
            _context = context;
        }
        public void Delete(HealthCenter entity)
        {
            _context.HealthCenters.Remove(entity);
        }

        public async Task<IEnumerable<HealthCenter>> GetAll()
        {
            return await _context.HealthCenters.AsNoTracking().ToListAsync();
        }

        public async Task<HealthCenter> GetById(string id)
        {
            return await _context.HealthCenters.FindAsync(id);
        }

        public async Task<HealthCenter> GetByName(string name)
        {
            return await _context.HealthCenters.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task InsertAsync(HealthCenter entity)
        {
            await _context.HealthCenters.AddAsync(entity);
        }

        public void Update(HealthCenter entity)
        {
            _context.HealthCenters.Update(entity);
        }
    }
}
