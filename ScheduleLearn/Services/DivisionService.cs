using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Services
{
    public class DivisionService : IDivision
    { 

        private readonly IUnitOfWork _unit;
        public DivisionService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<ApiResponse<Division>> AddDivisionAsync(Division division)
        {
            var isDivision = await _unit.DivisionRepository.GetByName(division.Name);
            if (isDivision != null)
                return new ApiResponse<Division>("Division already exists");

            var _divsion = new Division
            {
                DivisionId = Guid.NewGuid().ToString(),
                Name = division.Name,
                HealthCenterId = division.HealthCenterId,

            };
            try
            {
                await _unit.DivisionRepository.InsertAsync(_divsion);
                await _unit.CompleteAsync();
                return new ApiResponse<Division>(_divsion, "Successfully created division");
            }catch(Exception ex)
            {
                return new ApiResponse<Division>($"OOps, something went wrong: {ex.Message}");
            }
        }

        public async Task<ApiResponse<Division>> DeleteDivisionAsync(string id)
        {
            var isDivision = await _unit.DivisionRepository.GetById(id);
            if (isDivision == null)
                return new ApiResponse<Division>("Division Doesn't exist");
            try
            {
                _unit.DivisionRepository.Delete(isDivision);
                await _unit.CompleteAsync();
                return new ApiResponse<Division>("successfuly removed division");
            }catch(Exception ex)
            {
                return new ApiResponse<Division>($"Oops, somehting happened: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<Division>>> GetDivisionAsync()
        {
            try
            {
                var division = await _unit.DivisionRepository.GetAll();
                if (!division.Any())
                    return new ApiResponse<IEnumerable<Division>>("No divisions");

                return new ApiResponse<IEnumerable<Division>>(division, "");
            }catch(Exception ex)
            {
                return new ApiResponse<IEnumerable<Division>>($"Oops, something happened: {ex.Message}");
            }
            

        }

        public async Task<ApiResponse<Division>> GetDivisionAsync(string id)
        {
            try
            {
                var division = await _unit.DivisionRepository.GetById(id);
                if (division == null)
                    return new ApiResponse<Division>("Division Doesn't exist");

                return new ApiResponse<Division>(division, "");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Division>($"Oops, something happened: {ex.Message}");
            }
        }

        public async Task<ApiResponse<Division>> UpdateDivisionAsync(string id, Division division)
        {
            var isDivision = await _unit.DivisionRepository.GetById(id);
            if (isDivision == null)
                return new ApiResponse<Division>("Division Doesn't exist");

            isDivision.Name = division.Name;
            isDivision.HealthCenterId = division.HealthCenterId;
            try
            {
                await _unit.CompleteAsync();
                return new ApiResponse<Division>(division, "success update");

            }catch(Exception ex)
            {
                return new ApiResponse<Division>($"Oops, something happened: {ex.Message}");
            }
        }
    }
}
