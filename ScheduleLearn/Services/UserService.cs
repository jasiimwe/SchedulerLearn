using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Models.Responses;
using System.Data.SqlTypes;

namespace ScheduleLearnApi.Services
{
    public class UserService : IUser
    {
        private readonly IUnitOfWork _unit;
        public UserService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<ApiResponse<User>> AddUserAsync(User user)
        {
            var checkUser = await _unit.UserRepository.GetByAccountIdAsync(user.AccountId);
            if (checkUser != null)
                return new ApiResponse<User>("User already exists");
            var _user = new User
            {
                AccountId = user.AccountId,
                WardId = user.WardId,
                CenterId = user.CenterId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Profession = user.Profession,
                Contact = user.Contact,
                Gender = user.Gender,
                MedicalIssues = user.MedicalIssues,
                MaritalStatus = user.MaritalStatus,
                DoB = user.DoB,
                HeighestLvlEducaTION = user.HeighestLvlEducaTION
            };
            try
            {
                await _unit.UserRepository.InsertAsync(_user);
                await _unit.CompleteAsync();
                return new ApiResponse<User>(user, "User created Successfully");
            }catch(Exception ex)
            {
                return new ApiResponse<User>($"Oops, somehting went wrong: {ex.Message}");
            }
        }

        public async Task<ApiResponse<User>> DeleteUserAsync(string id)
        {
            var checkUser = await _unit.UserRepository.GetById(id);
            if (checkUser == null)
                return new ApiResponse<User>("User doesn't already exists");

            try
            {
                _unit.UserRepository.Delete(checkUser);
                await _unit.CompleteAsync();
                return new ApiResponse<User>("Successfully Deleted User");
            }catch(Exception ex)
            {
                return new ApiResponse<User>($"Oops, something happened: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<User>>> GetUserAsync()
        {
            try
            {
                var getUsers = await _unit.UserRepository.GetAll();
                if (!getUsers.Any())
                    return new ApiResponse<IEnumerable<User>>("No Users");
                return new ApiResponse<IEnumerable<User>>(getUsers, "");
            }catch(Exception ex)
            {
                return new ApiResponse<IEnumerable<User>>($"Oops, something happened: {ex.Message}");
            }
        }

        public async Task<ApiResponse<User>> GetUserAsync(string id)
        {
            try
            {
                var getUser = await _unit.UserRepository.GetById(id);
                if (getUser == null)
                    return new ApiResponse<User>("User doesn't exist");
                return new ApiResponse<User>(getUser, "");
            }catch(Exception ex)
            {
                return new ApiResponse<User>($"Oops, something happened: {ex.Message}");
            }
        }

        public async Task<ApiResponse<User>> UpdateUserAsync(string id, User user)
        {
            var getUser = await _unit.UserRepository.GetById(id);
            if (getUser == null)
                return new ApiResponse<User>("User doesn't exist");
            
            getUser.AccountId = user.AccountId;
            getUser.WardId = user.WardId;
            getUser.CenterId = user.CenterId;
            getUser.FirstName = user.FirstName;
            getUser.LastName = user.LastName;
            getUser.Email = user.Email;
            getUser.Address = user.Address;
            getUser.Profession = user.Profession;
            getUser.Contact = user.Contact;
            getUser.Gender = user.Gender;
            getUser.MedicalIssues = user.MedicalIssues;
            getUser.MaritalStatus = user.MaritalStatus;
            getUser.HeighestLvlEducaTION = user.HeighestLvlEducaTION;

            try
            {
                await _unit.CompleteAsync();
                return new ApiResponse<User>(user, "Updated user");
            }
            catch(Exception ex)
            {
                return new ApiResponse<User>($"Oops, something happened {ex.Message}");
            }


        }
    }
}
