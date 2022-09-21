namespace ScheduleLearnApi.Models.Interfaces.Repository
{
    public interface IWardRepository : IBaseRepository<Ward>
    {
        Task<Ward> GetByName(string name);
    }
}
