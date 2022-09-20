using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Persistent;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;

namespace ScheduleLearnApi.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly SchedulerContext _context;
        public DirectorRepository(SchedulerContext  context)
        {
            _context = context;
        }
        public void Delete(Director entity)
        {
            _context.Directors.Remove(entity);
        }

        public async Task<IEnumerable<Director>> GetAll()
        {
            return await _context.Directors.AsNoTracking().ToListAsync();
        }

        public async Task<Director> GetById(string id)
        {
            return await _context.Directors.FindAsync(id);
        }

        public async Task<Director> GetByName(string name)
        {
            return await _context.Directors.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task InsertAsync(Director entity)
        {
            await _context.Directors.AddAsync(entity);
        }

        public void Update(Director entity)
        {
            _context.Directors.Update(entity);
        }
    }
}
