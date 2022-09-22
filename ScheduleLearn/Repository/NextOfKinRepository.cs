using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Persistent;

namespace ScheduleLearnApi.Repository
{
    public class NextOfKinRepository : INextOfKinRepository
    {
        private readonly SchedulerContext _context;
        public NextOfKinRepository(SchedulerContext context)
        {
            _context = context;
        }
        public void Delete(NextOfKin entity)
        {
            _context.NextOfKin.Remove(entity);
        }

        public async Task<IEnumerable<NextOfKin>> GetAll() => await _context.NextOfKin.AsNoTracking().ToListAsync();


        public async Task<NextOfKin> GetById(string id) => await _context.NextOfKin.FindAsync(id);
        

        public async Task InsertAsync(NextOfKin entity)
        {
            await _context.NextOfKin.AddAsync(entity);
        }

        public void Update(NextOfKin entity)
        {
            _context.NextOfKin.Update(entity);
        }
    }
}
