﻿using ExpenseMaster.BusinessLogic.Interfaces;
using ExpenseMaster.DAL.DatabaseContext;
using ExpenseMaster.DAL.Models;

namespace ExpenseMaster.BusinessLogic.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDatabaseContext appContext)
            : base(appContext)
        {

        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            var user = await FindByConditionAsync(u => u.Login == login);
            return user.FirstOrDefault();
        }
    }
}