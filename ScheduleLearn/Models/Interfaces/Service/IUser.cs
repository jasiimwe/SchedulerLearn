using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Models.Interfaces.Service
{
    public interface IUser
    {
        Task<ApiResponse<IEnumerable<User>>> GetUserAsync();
        Task<ApiResponse<User>> GetUserAsync(string id);
        Task<ApiResponse<User>> UpdateUserAsync(string id, User user);
        Task<ApiResponse<User>> AddUserAsync(User user);

        Task<ApiResponse<User>> DeleteUserAsync(string id);
    }
}
