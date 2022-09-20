using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Persistent;

namespace ScheduleLearnApi.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SchedulerContext _context;
        public AccountRepository(SchedulerContext context)
        {
            _context = context;
        }
        public void Delete(Account entity)
        {
            _context.Accounts.Remove(entity);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _context.Accounts.AsNoTracking().ToListAsync();
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            return await _context.Accounts.FirstOrDefaultAsync(y => y.Email == email);
        }

        public async Task<Account> GetById(string id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> GetByUsernameAndPasswordAsync(string email, string password)
        {
            return await _context.Accounts.FirstOrDefaultAsync(y => y.Email == email && y.Password == password);
        }

        public async Task InsertAsync(Account entity)
        {
            await _context.Accounts.AddAsync(entity);
        }

        public void Update(Account entity)
        {
            _context.Accounts.Update(entity);
        }
    }
}
