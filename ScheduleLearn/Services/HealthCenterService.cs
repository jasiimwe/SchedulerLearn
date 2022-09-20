using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Services
{
    public class HealthCenterService : IHealthCenter
    {
        private readonly IUnitOfWork _unit;
        public HealthCenterService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<ApiResponse<HealthCenter>> AddHealthCenterAsync(HealthCenter healthCenter)
        {
            //check if it exists
            var isHealthCenter = await _unit.HealthCenterRepository.GetByName(healthCenter.Name);
            if (isHealthCenter != null)
                return new ApiResponse<HealthCenter>("Health Center Already Exists");

            if(string.IsNullOrEmpty(healthCenter.Name))
                return new ApiResponse<HealthCenter>("Field is required");

            var _healthCenter = new HealthCenter
            {
                Id = Guid.NewGuid().ToString(),
                Name = healthCenter.Name,
                Address = healthCenter.Address,
                Director = healthCenter.Director,
                CreatedOn = DateTime.UtcNow
            };

            try
            {
                await _unit.HealthCenterRepository.InsertAsync(_healthCenter);
                await _unit.CompleteAsync();

                return new ApiResponse<HealthCenter>(_healthCenter, "Health Center created");
            }
            catch (Exception)
            {
                return new ApiResponse<HealthCenter>("Oops, Something went wrong");
            }

            
        }

        public async Task<ApiResponse<HealthCenter>> DeleteHealthCenterAsync(HealthCenter healthCenter)
        {
            var isHealthCenter = await _unit.HealthCenterRepository.GetById(healthCenter.Id);
            if (isHealthCenter != null)
                return new ApiResponse<HealthCenter>("Health Center Already Exists");
            try
            {
                _unit.HealthCenterRepository.Delete(healthCenter);
                await _unit.CompleteAsync();
                return new ApiResponse<HealthCenter>("Successfuly deleted health center");
            }
            catch (Exception)
            {
                return new ApiResponse<HealthCenter>("Oops, something went wrong");
            }
        }

        public async Task<ApiResponse<IEnumerable<HealthCenter>>> GetHealthCenterAsync()
        {
            try
            {
                var facilities = await _unit.HealthCenterRepository.GetAll();
                if (!facilities.Any())
                    return new ApiResponse<IEnumerable<HealthCenter>>("nothing to show");

                return new ApiResponse<IEnumerable<HealthCenter>>(facilities, "");
            }
            catch (Exception)
            {
                return new ApiResponse<IEnumerable<HealthCenter>>("Oops, something went wrong!");
            }
            
            

        }

        public async Task<ApiResponse<HealthCenter>> GetHealthCenterAsync(string id)
        {
            try
            {
                var facility = await _unit.HealthCenterRepository.GetById(id);
                return new ApiResponse<HealthCenter>(facility, "");
            }
            catch (Exception)
            {
                return new ApiResponse<HealthCenter>("Oops, something went wrong");
            }
        }

        public async Task<ApiResponse<HealthCenter>> UpdateHealthCenterAsync(HealthCenter healthCenter)
        {
            var isHealthCenter = await _unit.HealthCenterRepository.GetById(healthCenter.Id);
            if (isHealthCenter == null)
                return new ApiResponse<HealthCenter>("Health Center Doesn't Exist");

            isHealthCenter.Name = healthCenter.Name;
            isHealthCenter.Address = healthCenter.Address;
            isHealthCenter.Director = healthCenter.Director;
            try
            {
                _unit.HealthCenterRepository.Update(healthCenter);
                return new ApiResponse<HealthCenter>(healthCenter, "successfully updated");
            }
            catch (Exception)
            {
                return new ApiResponse<HealthCenter>("Oops, something went wrong");
            }
        }
    }
}
