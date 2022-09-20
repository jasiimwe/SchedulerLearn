namespace ScheduleLearnApi.Models.Interfaces.Repository
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account> GetByEmailAsync(string email); 

        Task<Account> GetByUsernameAndPasswordAsync(string email, string password);
    }
}
