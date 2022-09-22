using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Repository;

namespace ScheduleLearnApi.Models.Persistent
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchedulerContext _context;
        public UnitOfWork(SchedulerContext context)
        {
            _context = context;
        }

        public IAccountRepository AccountRepository => new AccountRepository(_context);
        public IDirectorRepository DirectorRepository => new DirectorRepository(_context);

        public IHealthCenterRepository HealthCenterRepository => new HealthCenterRepository(_context);

        public IDivisionRepository DivisionRepository => new DivisionRepository(_context);
        public IWardRepository WardRepository => new WardRepository(_context);
        public IUserRepository UserRepository => new UserRepository(_context);

        public INextOfKinRepository NextOfKinRepository => new NextOfKinRepository(_context);

       
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
