using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections;

namespace ScheduleLearnApi.Models.Interfaces.Service
{
    public interface IAccount
    {
        Task<(Account account, string message, bool check)> GetAsync(string id);
        Task<(IEnumerable<Account> accounts, string message, bool check)> GetAsync();
        Task<(Account account, string message, bool check)> UpdateEmailAsync(string id, string email);

        Task<(Account account, string message, bool check)> UpdatePasswordAsync(string id, string password);
        (string message, bool check) Delete(Account account);

        (Account account, string message, bool check) Add(string email, string password, string isadmin);

        Task<(Account account, string message, bool check)> LoginAsync(string email, string password);

        //(Account account, string message, bool check) Login(Account account);

    }
}
