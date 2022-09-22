

using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Models.Responses;

namespace ScheduleLearnApi.Services
{
    public class NextOfKinService : INextOfKin
    {
        private readonly IUnitOfWork _unit;
        public NextOfKinService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<ApiResponse<NextOfKin>> AddNextOfKinAsync(NextOfKin nextOfKin)
        {
            var getNexOfKin = await _unit.NextOfKinRepository.GetById(nextOfKin.Contact);
            if (getNexOfKin != null)
                return new ApiResponse<NextOfKin>("Details already exist");

            var _newKin = new NextOfKin
            {
                Contact = nextOfKin.Contact,
                FirstName = nextOfKin.FirstName,
                LastName = nextOfKin.LastName,
                UserID = nextOfKin.UserID,
                Relationship = nextOfKin.Relationship,
            };

            try
            {
                await _unit.NextOfKinRepository.InsertAsync(_newKin);
                await _unit.CompleteAsync();
                return new ApiResponse<NextOfKin>(_newKin, "Succesfully created new next of kin");
            }catch(Exception ex)
            {
                return new ApiResponse<NextOfKin>($"Oops, something happened: {ex.Message}");
            }
        }

        public async Task<ApiResponse<NextOfKin>> DeleteNextOfKinAsync(string id)
        {
            var getNexOfKin = await _unit.NextOfKinRepository.GetById(id);
            if (getNexOfKin != null)
                return new ApiResponse<NextOfKin>("Details already exist");
            try
            {
                _unit.NextOfKinRepository.Delete(getNexOfKin);
                await _unit.CompleteAsync();
                return new ApiResponse<NextOfKin>("Deleted successfully");
            }catch(Exception ex)
            {
                return new ApiResponse<NextOfKin>($"Oops, something happened{ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<NextOfKin>>> GetNextOfKinAsync()
        {
            try
            {
                var _getKins = await _unit.NextOfKinRepository.GetAll();
                if (!_getKins.Any())
                    return new ApiResponse<IEnumerable<NextOfKin>>("No Data");

                return new ApiResponse<IEnumerable<NextOfKin>>(_getKins, "");
            }catch(Exception ex)
            {
                return new ApiResponse<IEnumerable<NextOfKin>>($"Oops, something happened: {ex.Message}");
            }
            
        }

        public async Task<ApiResponse<NextOfKin>> GetNextOfKinAsync(string id)
        {
            try
            {
                var _getKin = await _unit.NextOfKinRepository.GetById(id);
                if (_getKin == null)
                    return new ApiResponse<NextOfKin>("Next of Kin doesn't exist");
                return new ApiResponse<NextOfKin>(_getKin, "");
            }catch(Exception ex)
            {
                return new ApiResponse<NextOfKin>($"Opps something happened :{ex.Message}");
            }
            
        }

        public async Task<ApiResponse<NextOfKin>> UpdateNextOfKinAsync(string id, NextOfKin nextOfKin)
        {
            var _getKin = await _unit.NextOfKinRepository.GetById(id);
            if (_getKin == null)
                return new ApiResponse<NextOfKin>("Next of Kin doesn't exist");
            _getKin.FirstName = nextOfKin.FirstName;
            _getKin.LastName = nextOfKin.LastName;
            _getKin.Relationship = nextOfKin.Relationship;
            _getKin.Contact = nextOfKin.Contact;

            try
            {
                await _unit.CompleteAsync();
                return new ApiResponse<NextOfKin>(nextOfKin, "updated next of kin details");
            }catch(Exception ex)
            {
                return new ApiResponse<NextOfKin>($"Oops, something happened: {ex.Message}");
            }
            
        }
    }
}
