namespace ScheduleLearnApi.Models.Interfaces.Repository
{
    public interface IUserRepository :IBaseRepository<User>
    {
        Task<User> GetByAccountIdAsync(string accountId);
    }
}
