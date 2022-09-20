namespace ScheduleLearnApi.Models.Interfaces.Repository
{
    public interface IDirectorRepository : IBaseRepository<Director>
    {
        Task<Director> GetByName(string name);
    }
}
