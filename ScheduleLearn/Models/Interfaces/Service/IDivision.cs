using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Models.Interfaces.Service
{
    public interface IDivision
    {
        Task<ApiResponse<IEnumerable<Division>>> GetDivisionAsync();
        Task<ApiResponse<Division>> GetDivisionAsync(string id);
        Task<ApiResponse<Division>> UpdateDivisionAsync(string id, Division division);
        Task<ApiResponse<Division>> AddDivisionAsync(Division division);

        Task<ApiResponse<Division>> DeleteDivisionAsync(string id);
    }
}
