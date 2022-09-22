using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Models.Interfaces.Service
{
    public interface INextOfKin
    {
        Task<ApiResponse<IEnumerable<NextOfKin>>> GetNextOfKinAsync();
        Task<ApiResponse<NextOfKin>> GetNextOfKinAsync(string id);
        Task<ApiResponse<NextOfKin>> UpdateNextOfKinAsync(string id, NextOfKin nextOfKin);
        Task<ApiResponse<NextOfKin>> AddNextOfKinAsync(NextOfKin nextOfKin);

        Task<ApiResponse<NextOfKin>> DeleteNextOfKinAsync(string id);
    }
}
