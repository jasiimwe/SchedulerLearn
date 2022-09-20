using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Models.Interfaces.Service
{
    public interface IHealthCenter
    {
        Task<ApiResponse<IEnumerable<HealthCenter>>> GetHealthCenterAsync();
        Task<ApiResponse<HealthCenter>> GetHealthCenterAsync(string id);
        Task<ApiResponse<HealthCenter>> UpdateHealthCenterAsync(HealthCenter healthCenter);
        Task<ApiResponse<HealthCenter>> AddHealthCenterAsync(HealthCenter healthCenter);

        Task<ApiResponse<HealthCenter>> DeleteHealthCenterAsync(HealthCenter healthCenter);
        
    }
}
