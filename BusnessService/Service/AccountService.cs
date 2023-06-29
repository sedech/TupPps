using AutoMapper;
using BusnessService.Encryption;
using BusnessService.IService;
using BussnessEntities;
using DataModels.Entities;
using DataModels.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.Service
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _repo;
        private readonly IMapper _maapper;

        public AccountService(IAccountRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }

        public async Task<Int64> Create(AccountWithoutRoleBe entity)
        {
            string encryptedPassword = Encrypt.GetMD5(entity.Password);

            entity.Password = encryptedPassword;
            var result = _maapper.Map<Account>(entity);
            return await _repo.Create(result);
        }

        public async Task<AccountBe> GetById(int id)
        {
            return _maapper.Map<AccountBe>(await _repo.GetById(id));
        }

        public async Task<AccountWithoutRoleWithUsersBe?> Login(string email, string password)
        {
            string passencryp = Encrypt.GetMD5(password);
            AccountWithoutRoleWithUsersBe account = new AccountWithoutRoleWithUsersBe()
            {
                Email = email,
                Password = passencryp
            };

            var loginResult = await _repo.Login(account.Email, account.Password);
            if (loginResult == null)
            {
                return null;
            }

            account.RoleId = loginResult.RoleId;
            return _maapper.Map<AccountWithoutRoleWithUsersBe>(loginResult);
        }


        public async Task<bool> Update(AccountBe entity)
        {
            var result = _maapper.Map<Account>(entity);
            return await _repo.Update(result);

        }
    }
}
