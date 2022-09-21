using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Models.Interfaces.Service
{
    public interface IWard
    {
        Task<ApiResponse<IEnumerable<Ward>>> GetWardAsync();
        Task<ApiResponse<Ward>> GetWardAsync(string id);
        Task<ApiResponse<Ward>> UpdateWardAsync(string id, Ward ward);
        Task<ApiResponse<Ward>> AddWardAsync(Ward ward);

        Task<ApiResponse<Ward>> DeleteWardAsync(string id);
    }
}
