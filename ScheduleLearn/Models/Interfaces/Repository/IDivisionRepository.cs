namespace ScheduleLearnApi.Models.Interfaces.Repository
{
    public interface IDivisionRepository : IBaseRepository<Division>
    {
        Task<Division> GetByName(string name);
    }
}
