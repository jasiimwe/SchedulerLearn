using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ScheduleLearnApi.Models;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Models.Interfaces.Repository;
using ScheduleLearnApi.Models.Interfaces.Service;
using ScheduleLearnApi.Models.Persistent;
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

        public (Account account, string message, bool check) Add(string email, string password, string isadmin)
        {
            var check = false;
            var message = "";
            var account = new Account();
            var isaccount = _unit.AccountRepository.GetByEmailAsync(email);
            if (isaccount != null)
                message = "The account with this email already exists";
            else
            {
                try
                {
                    var checkBoll = bool.TryParse(isadmin, out bool IsAdmin);

                    if (!checkBoll)
                    {
                        account = null;
                        message = "isadmin should be a proper boolean";
                        check = false;
                        //return (account, message, check);
                    }

                    var _account = new Account
                    {
                        Date = DateTime.UtcNow,
                        Email = email,
                        Password = Support.GetMd5(password),
                        Id = Guid.NewGuid().ToString(),
                        IsAdmin = IsAdmin
                    };

                    _unit.AccountRepository.InsertAsync(_account);
                    _unit.CompleteAsync();
                    account = _account;
                    check = true;
                    message = "Successfully saved account";
                    // return (account, message, check);
                }
                catch (Exception)
                {
                    message = "Oops, Something went wrong, please try again";
                }

            }
            return (account, message, check);
        }

        public (string message, bool check) Delete(Account account)
        {
            var _account = _unit.AccountRepository.GetById(account.Id);
            var message = "";
            var check = false;
            if (_account is null)
            {
                message = "Oops, it appears this client doesn't exist";
            }
            else
            {
                try
                {
                    _unit.AccountRepository.Delete(account);
                    _unit.CompleteAsync();
                    check = true;
                    message = null;
                }
                catch (Exception)
                {
                    message = "Oops, something went wrong, couldn't delete account";
                }
            }
            return (message, check);
        }

        public async Task<(Account account, string message, bool check)> GetAsync(string id)
        {
            var _account = await _unit.AccountRepository.GetById(id);
            var message = "";
            var account = new Account();
            var check = false;
            if (_account is null)
                message = "Oops, it appears that this is account doesn't exist";
            else
            {
                check = true;
                message = null;
                account = _account;
            }

            return (_account, message, check);
        }

        public async Task<(IEnumerable<Account> accounts, string message, bool check)> GetAsync()
        {
            IEnumerable<Account> _accounts = new List<Account>();
            var message = "";
            
            try
            {
                _accounts = await _unit.AccountRepository.GetAll();
                
            }
            catch (Exception)
            {
                message = "Oops, Something went wrong please try again later!";
                
                
            }

            return (_accounts, message, _accounts.Any());
        }

        public async Task<(Account account, string message, bool check)> LoginAsync(string email, string password)
        {
            var account = new AccountViewModel
            {
                Email = email,
                Password = password
            };

            var message = "";
            var check = false;
            var data = new Account();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                data = null;
                message = "Please, fill in all fields";
            }
            else
            {
                var _pass = Support.GetMd5(password);
                var _getAccount = await _unit.AccountRepository.GetByUsernameAndPasswordAsync(email, password);
                
                if (_getAccount is null)
                {
                    data = null;
                    message = "Wrong username or password";
                    
                }
                else
                {
                    data = _getAccount;
                    message = "successfully logged in";
                    check = true;
                }
            }
            return (data, message, check);
        }

        public async Task<(Account account, string message, bool check)> UpdateEmailAsync(string id, string email)
        {
            var _account = await _unit.AccountRepository.GetById(id);
            var message = "";
            var check = false;
            if (_account is null)
                message = "Account doesn't exists";
            else
            {
                _account.Email = email;

                try
                {
                    _unit.AccountRepository.Update(_account);
                    //await _unit.CompleteAsync();

                    check = true;
                    message = "Successfully Updated Account";
                }
                catch (Exception)
                {
                    message = "Oops, something went wrong couldn't please try again";
                }
            }
            return (_account, message, check);
        }

        public async Task<(Account account, string message, bool check)> UpdatePasswordAsync(string id, string password)
        {
            var _account = await _unit.AccountRepository.GetById(id);
            var message = "";
            var check = false;
            if (_account is null)
                message = "Account doesn't exists";
            else
            {
                _account.Password = Support.GetMd5(password);

                try
                {
                    _unit.AccountRepository.Update(_account);
                    //await _unit.CompleteAsync();

                    check = true;
                    message = "Successfully Updated Account";
                }
                catch (Exception)
                {
                    message = "Oops, something went wrong couldn't please try again";
                }
            }
            return (_account, message, check);
        }
    }
}
