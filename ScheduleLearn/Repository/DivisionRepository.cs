using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Persistent;

namespace ScheduleLearnApi.Repository
{
    public class DivisionRepository : IDivisionRepository
    {
        private readonly SchedulerContext _context;
        public DivisionRepository(SchedulerContext context)
        {
            _context = context;
        }
        public void Delete(Division entity)
        {
            _context.Divisions.Remove(entity);
        }

        public async Task<IEnumerable<Division>> GetAll() => await _context.Divisions.AsNoTracking().ToListAsync();


        public async Task<Division> GetById(string id) => await _context.Divisions.FindAsync(id);

        public async Task<Division> GetByName(string name) => await _context.Divisions.FirstOrDefaultAsync(x => x.Name == name);
        

        public async Task InsertAsync(Division entity)
        {
            await _context.Divisions.AddAsync(entity);
        }

        public void Update(Division entity)
        {
            _context.Divisions.Remove(entity);
        }
    }
}
