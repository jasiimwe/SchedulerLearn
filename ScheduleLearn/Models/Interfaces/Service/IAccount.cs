using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ScheduleLearnApi.Models.Responses;
using System.Collections;

namespace ScheduleLearnApi.Models.Interfaces.Service
{
    public interface IAccount
    {
        Task<ApiResponse<Account>> GetAsync(string id);
        Task<ApiResponse<IEnumerable<Account>>> GetAsync();
        Task<ApiResponse<Account>> UpdateEmailAsync(string id, string email);

        Task<ApiResponse<Account>> UpdatePasswordAsync(string id, string password);
        Task<ApiResponse<Account>> Delete(string id);

        Task<ApiResponse<Account>> Add(string email, string password, string isadmin);

        Task<ApiResponse<Account>> LoginAsync(string email, string password);

        //(Account account, string message, bool check) Login(Account account);

    }
}
