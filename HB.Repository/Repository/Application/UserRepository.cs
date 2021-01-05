using HB.Core.Repository;
using HB.DAL;
using HB.Entity.Application;
using HB.Repository.Interface.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Repository.Repository.Application
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
