﻿using DataModels.Context;
using DataModels.Entities;
using DataModels.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public readonly FerreTechContext _context;

        public AccountRepository(FerreTechContext context)
        {
            _context = context;
        }

        public async Task<Int64> Create(Account entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.State = 1;

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Account> GetById(int id)
        {
            try
            {
                var entity = await _context.Accounts.SingleOrDefaultAsync(u => u.Id == id);

                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Account> Login(string userName, string userPass)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentException("Debe ingresar el usuario");
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentException("Debe ingresar la contraseña");
                var entity = await _context.Accounts.Include(u => u.Role).SingleOrDefaultAsync(u =>u.UserName == userName && u.Password == userPass);
                if (entity == null)
                    throw new ArgumentException("Usuario y/o contraseña incorrecto");
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Account entity)
        {
            var acco = await _context.Accounts.FindAsync(entity.Id);
            if (acco == null)
                throw new Exception("No se pudo actualizar la clave");
            acco.RoleId = entity.RoleId;
            acco.UserName = entity.UserName;
            acco.Password = entity.Password;

            return true;
        }

    }
}
