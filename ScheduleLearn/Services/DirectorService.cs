using NuGet.Protocol.Plugins;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Models.Persistent;
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

        public async Task<(Director director, string message, bool check)> AddAsync(Director director)
        {
            var isdirector = _unitOfWork.DirectorRepository.GetById(director.Id);
            var message = "";
            var _director = new Director();
            var check = false;
            if (isdirector != null)
                message = "Director already exists";
            else
            {
                if (string.IsNullOrEmpty(director.Name))
                    message = "Name is required";

                

                _director = new Director
                {
                    Name = director.Name,
                    Dob = director.Dob,
                    Id = Guid.NewGuid().ToString("N"),
                    isDeleted = false,
                    AccountId = director.AccountId,
                    CreatedOn = DateTime.UtcNow
                };

                try
                {
                    await _unitOfWork.DirectorRepository.InsertAsync(_director);
                    await _unitOfWork.CompleteAsync();
                    check = true;
                    message = "Succesfully created Director";
                }
                catch (Exception)
                {
                    message = "Oops, something happened";
                }
            }
            return (_director, message, check);
        }

        public (string message, bool check) Delete(Director director)
        {
            var _director = _unitOfWork.DirectorRepository.GetById(director.Id);
            var message = "";
            var check = false;
            if (_director is null)
                message = "Oops, Director doesn't exist";
            else
            {
                try
                {
                    _unitOfWork.DirectorRepository.Delete(director);
                    _unitOfWork.CompleteAsync();
                    check = true;
                    message = "Successfully deleted Director";
                }
                catch (Exception)
                {
                    message = "Oops, Somehting went wrong";
                }
            }
            return (message, check);
        }

        public async Task<(Director director, string message, bool check)> GetAsync(string id)
        {
            var _director = await _unitOfWork.DirectorRepository.GetById(id);
            var message = "";
            var check = false;
            if (_director is null)
                message = "Oops, Director doesn't exist";
            else
            {
                check = true;
                message = null;

            }
            return (_director, message, check);
        }

        public async Task<(IEnumerable<Director> directors, string message, bool check)> GetAsync()
        {
            IEnumerable<Director> _directors = new List<Director>();
            var message = "";
            try
            {
                _directors = await _unitOfWork.DirectorRepository.GetAll();
            }
            catch(Exception)
            {
                message = "Oops, Something went wrong";
            }
            return (_directors, message, _directors.Any());
        }

        public async Task<(Director director, string message, bool check)> UpdateAsync(string name, DateTime dob, bool isDeleted)
        {
            var _director = await _unitOfWork.DirectorRepository.GetByName(name);
            var message = "";
            var check = false;
            if (_director is null)
                message = "Director Doesn't exist";
            else
            {
                

                _director.Name = name;
                _director.Dob = dob;
                _director.isDeleted = isDeleted;
                

                
                try
                {
                    _unitOfWork.DirectorRepository.Update(_director);
                    
                    check = true;
                    message = "Succesfully updated Director";
                }
                catch (Exception)
                {
                    message = "Oops, Something happened while updating";
                }
            }
            return (_director, message, check);
        }
    }
}
