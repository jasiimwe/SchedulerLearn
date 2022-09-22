using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Models.Persistent;
using ScheduleLearnApi.Models.Responses;
using ScheduleLearnApi.Utils;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using static ScheduleLearnApi.Controllers.AccountController;

namespace ScheduleLearnApi.Services
{
    public class AccountService : IAccount
    {
        //private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unit;
        public AccountService(IUnitOfWork unitOfWork)
        {   
            _unit = unitOfWork;
        }

        public async Task<ApiResponse<Account>> Add(string email, string password, string isadmin)
        {
           
            var isaccount = await _unit.AccountRepository.GetByEmailAsync(email);
            if (isaccount != null)
                return new ApiResponse<Account>("account already exists");
            else
            {
                try
                {
                    var checkBoll = bool.TryParse(isadmin, out bool IsAdmin);

                    if (!checkBoll)
                    {
                        return new ApiResponse<Account>("please submit a proper boolean");
                        //return (account, message, check);
                    }

                    var _account = new Account
                    {
                        Date = DateTime.UtcNow,
                        Email = email,
                        Password = Support.GetMd5(password),
                        AccountId = Guid.NewGuid().ToString(),
                        IsAdmin = IsAdmin
                    };

                    await _unit.AccountRepository.InsertAsync(_account);
                    await _unit.CompleteAsync();
                    return new ApiResponse<Account>(_account, "successfully created account");
                   
                }
                catch (Exception ex)
                {
                    return new ApiResponse<Account>($"account already exists {ex.Message}");
                }

            }
            
        }

        public async Task<ApiResponse<Account>> Delete(string id)
        {
            var _account = await _unit.AccountRepository.GetById(id);
            if (_account is null)
                return new ApiResponse<Account>("Account doesn't exists");
            else
            {
                try
                {
                    _unit.AccountRepository.Delete(_account);
                    await _unit.CompleteAsync();
                    return new ApiResponse<Account>("successfully deleted account");
                    
                }
                catch (Exception ex)
                {
                    return new ApiResponse<Account>($"Oops, something happened: {ex.Message}");
                }
            }
            
        }

        public async Task<ApiResponse<Account>> GetAsync(string id)
        {
            try
            {
                var _account = await _unit.AccountRepository.GetById(id);
                if (_account is null)
                    return new ApiResponse<Account>("account doen't exists");
                else
                {
                    return new ApiResponse<Account>(_account, "");
                }
            }catch(Exception ex)
            {
                return new ApiResponse<Account>($"Oops, something happened: {ex.Message}");
            }
            

            
        }

        public async Task<ApiResponse<IEnumerable<Account>>> GetAsync()
        {
            
            
            try
            {
                var _accounts = await _unit.AccountRepository.GetAll();
                if (_accounts.Any())
                    return new ApiResponse<IEnumerable<Account>>("No record");
                return new ApiResponse<IEnumerable<Account>>(_accounts, "");
                
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Account>>($"Oops, something happened: {ex.Message} ");
            }

            
        }

        public async Task<ApiResponse<Account>> LoginAsync(string email, string password)
        {
            var account = new AccountViewModel
            {
                Email = email,
                Password = password
            };

            
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return new ApiResponse<Account>("All fields are required");
            }
            else
            {
                var _pass = Support.GetMd5(password);
                var _getAccount = await _unit.AccountRepository.GetByUsernameAndPasswordAsync(email, password);
                
                if (_getAccount is null)
                {
                    return new ApiResponse<Account>("wrong username/password");
                }
                else
                {
                    return new ApiResponse<Account>(_getAccount, "Successfully Logged on");
                }
            }
            
        }

        public async Task<ApiResponse<Account>> UpdateEmailAsync(string id, string email)
        {
            var _account = await _unit.AccountRepository.GetById(id);

            if (_account is null)
                return new ApiResponse<Account>("account doesn't exist");
            else
            {
                _account.Email = email;

                try
                {
                    //_unit.AccountRepository.Update(_account);
                    await _unit.CompleteAsync();

                    return new ApiResponse<Account>("successfully updated email");
                }
                catch (Exception ex)
                {
                    return new ApiResponse<Account>($"Oops, something happened: {ex.Message}");
                }
            }
            
        }

        public async Task<ApiResponse<Account>> UpdatePasswordAsync(string id, string password)
        {
            var _account = await _unit.AccountRepository.GetById(id);

            if (_account is null)
                return new ApiResponse<Account>("Account doesn't exist");
            else
            {
                _account.Password = Support.GetMd5(password);

                try
                {
                    //_unit.AccountRepository.Update(_account);
                    await _unit.CompleteAsync();

                    return new ApiResponse<Account>("updated account");
                }
                catch (Exception ex)
                {
                    return new ApiResponse<Account>($"Oops, something happened{ex.Message}");
                }
            }
            
        }
    }
}
