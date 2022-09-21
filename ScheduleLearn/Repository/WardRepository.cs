using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Persistent;

namespace ScheduleLearnApi.Repository
{
    public class WardRepository : IWardRepository
    {
        private readonly SchedulerContext _context;
        public WardRepository(SchedulerContext context)
        {
            _context = context;
        }
        public void Delete(Ward entity)
        {
            _context.Wards.Remove(entity);
        }

        public async Task<IEnumerable<Ward>> GetAll() => await _context.Wards.AsNoTracking().ToListAsync();


        public async Task<Ward> GetById(string id) => await _context.Wards.FindAsync(id);

        public async Task<Ward> GetByName(string name) => await _context.Wards.FirstOrDefaultAsync(x => x.Name == name);
        

        public async Task InsertAsync(Ward entity)
        {
           await _context.Wards.AddAsync(entity);
        }

        public void Update(Ward entity)
        {
            _context.Wards.Update(entity);
        }
    }
}
