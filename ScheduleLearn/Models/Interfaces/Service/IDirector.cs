using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Models.Interfaces.Service
{
    public interface IDirector
    {
        Task<ApiResponse<Director>> GetAsync(string id);
        Task<ApiResponse<IEnumerable<Director>>> GetAsync();
        Task<ApiResponse<Director>> UpdateAsync(string name, DateTime dob, bool isDeleted);
        Task<ApiResponse<Director>> Delete(string id);

        Task<ApiResponse<Director>> AddAsync(Director director);
    }
}
