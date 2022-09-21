using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Services
{
    public class WardService : IWard
    {
        private readonly IUnitOfWork _unit;
        public WardService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<ApiResponse<Ward>> AddWardAsync(Ward ward)
        {
            var isWard = await _unit.WardRepository.GetByName(ward.Name);
            if (isWard != null)
                return new ApiResponse<Ward>("Ward already exists");

            var newWard = new Ward
            {
                Id = Guid.NewGuid().ToString(),
                Name = ward.Name,
                DivisionId = ward.DivisionId,
                CenterId = ward.CenterId,
                InchargeId = ward.InchargeId,
                Description = ward.Description,
                NumberOfWorkers = ward.NumberOfWorkers,
                MaximumHoursAday = ward.MaximumHoursAday,
                MinimunHoursAday = ward.MinimunHoursAday,
            };

            try
            {
                await _unit.WardRepository.InsertAsync(newWard);
                await _unit.CompleteAsync();
                return new ApiResponse<Ward>(newWard, "Successfully Created ward");

            }catch(Exception ex)
            {
                return new ApiResponse<Ward>($"Opps, something happed: {ex.Message}");
            }
        }

        public async Task<ApiResponse<Ward>> DeleteWardAsync(string id)
        {
            var isWard = await _unit.WardRepository.GetById(id);
            if (isWard == null)
                return new ApiResponse<Ward>("Ward doesn't exist");
            try
            {
                _unit.WardRepository.Delete(isWard);
                await _unit.CompleteAsync();
                return new ApiResponse<Ward>("Ward deleted successfully");
            }catch(Exception ex)
            {
                return new ApiResponse<Ward>($"Oops, something happened: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<Ward>>> GetWardAsync()
        {
            try
            {
                var wards = await _unit.WardRepository.GetAll();
                if (!wards.Any())
                    return new ApiResponse<IEnumerable<Ward>>("No wards");
                return new ApiResponse<IEnumerable<Ward>>(wards,"");
            }
            catch (Exception)
            {
                return new ApiResponse<IEnumerable<Ward>>("opps, something happened");
            }
        }

        public async Task<ApiResponse<Ward>> GetWardAsync(string id)
        {
            try
            {
                var ward = await _unit.WardRepository.GetById(id);
                if (ward == null)
                    return new ApiResponse<Ward>("Ward doesn't exist");
                return new ApiResponse<Ward>(ward, "");
            }
            catch (Exception)
            {
                return new ApiResponse<Ward>("Oops, something happened ");
            }
        }

        public async Task<ApiResponse<Ward>> UpdateWardAsync(string id, Ward ward)
        {
            var _ward = await _unit.WardRepository.GetById(id);
            if (_ward == null)
                return new ApiResponse<Ward>("Ward doesn't exist");

            _ward.Name = ward.Name;
            _ward.NumberOfWorkers = ward.NumberOfWorkers;
            _ward.Description = ward.Description;
            _ward.DivisionId = ward.DivisionId;
            _ward.CenterId = ward.CenterId;
            _ward.InchargeId = ward.InchargeId;
            _ward.MaximumHoursAday = ward.MaximumHoursAday;
            _ward.MinimunHoursAday = ward.MinimunHoursAday;

            try
            {
                await _unit.CompleteAsync();
                return new ApiResponse<Ward>(ward, "Successfully updated ward");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Ward>($"Oops, something happened: {ex.Message}");
            }
        }
    }
}
