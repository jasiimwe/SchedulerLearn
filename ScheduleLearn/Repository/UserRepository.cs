using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Persistent;

namespace ScheduleLearnApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SchedulerContext _context;
        public UserRepository(SchedulerContext context)
        {
            _context = context;
        }
        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
        }

        public async Task<IEnumerable<User>> GetAll() => await _context.Users.AsNoTracking().ToListAsync();


        public async Task<User> GetById(string id) => await _context.Users.FindAsync(id);


        public async Task<User> GetByAccountIdAsync(string accountId) => await _context.Users.FirstOrDefaultAsync(x => x.AccountId == accountId);
        

        public async Task InsertAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }
    }
}
