namespace ScheduleLearnApi.Models.Interfaces.Repository
{
    public interface IHealthCenterRepository : IBaseRepository<HealthCenter>
    {
        Task<HealthCenter> GetByName(string name);
    }
}
