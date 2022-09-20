using ScheduleLearnApi.Models.Interfaces.Repository;

namespace ScheduleLearnApi.Models.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IDirectorRepository DirectorRepository { get; }

        IHealthCenterRepository HealthCenterRepository { get; }
        Task CompleteAsync();
    }
}
