using NuGet.Protocol.Plugins;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Models.Persistent;
using ScheduleLearnApi.Models.Responses;
using System.IO;
using System.Security.Principal;

namespace ScheduleLearnApi.Services
{
    public class DirectorService : IDirector
    {
        private readonly IUnitOfWork _unitOfWork;

        public DirectorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<Director>> AddAsync(Director director)
        {
            var isdirector = _unitOfWork.DirectorRepository.GetById(director.DirectorId);

            if (isdirector != null)
                return new ApiResponse<Director>("director already exists");
            else
            {
                if (string.IsNullOrEmpty(director.Name))
                    return new ApiResponse<Director>("Name already exists");



                var _director = new Director
                {
                    Name = director.Name,
                    Dob = director.Dob,
                    DirectorId = Guid.NewGuid().ToString("N"),
                    isDeleted = false,
                    AccountId = director.AccountId,
                    CreatedOn = DateTime.UtcNow
                };

                try
                {
                    await _unitOfWork.DirectorRepository.InsertAsync(_director);
                    await _unitOfWork.CompleteAsync();
                    return new ApiResponse<Director>(_director, "successfully added director");
                }
                catch (Exception)
                {
                    return new ApiResponse<Director>("Oops, something happened");
                }
            }
            
        }

        public async Task<ApiResponse<Director>> Delete(string id)
        {
            var _director = await _unitOfWork.DirectorRepository.GetById(id);
            
            if (_director is null)
                return new ApiResponse<Director>("director already exists");
            else
            {
                try
                {
                    _unitOfWork.DirectorRepository.Delete(_director);
                    await _unitOfWork.CompleteAsync();
                    return new ApiResponse<Director>("director deleted");
                }
                catch (Exception ex)
                {
                    return new ApiResponse<Director>($"director already exist: {ex.Message}");
                }
            }
            
        }

        public async Task<ApiResponse<Director>> GetAsync(string id)
        {
            var _director = await _unitOfWork.DirectorRepository.GetById(id);
            
            if (_director is null)
                return new ApiResponse<Director>("director doesn't exist");
            else
            {
                return new ApiResponse<Director>(_director, "");

            }
            
        }

        public async Task<ApiResponse<IEnumerable<Director>>> GetAsync()
        {
            
            try
            {
                var _directors = await _unitOfWork.DirectorRepository.GetAll();
                if(!_directors.Any())
                    return new ApiResponse<IEnumerable<Director>>("No data");
                return new ApiResponse<IEnumerable<Director>>(_directors, "");
            }
            catch(Exception ex)
            {
                return new ApiResponse<IEnumerable<Director>>($"Oops, something happened: {ex.Message}");
            }
            
        }

        public async Task<ApiResponse<Director>> UpdateAsync(string name, DateTime dob, bool isDeleted)
        {
            var _director = await _unitOfWork.DirectorRepository.GetByName(name);
            if (_director is null)
                return new ApiResponse<Director>("director doesn't exist");
            else
            {
                

                _director.Name = name;
                _director.Dob = dob;
                _director.isDeleted = isDeleted;
                

                
                try
                {
                    await _unitOfWork.CompleteAsync();
                    return new ApiResponse<Director>("updated successfully");

                }
                catch (Exception)
                {
                    return new ApiResponse<Director>("director doesn't exist");
                }
            }
           
        }
    }
}
