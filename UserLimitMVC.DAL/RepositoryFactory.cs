using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLimitMVC.IDAL;

namespace UserLimitMVC.DAL
{
    public static class RepositoryFactory
    {

        public static IBaseUserRepository UserRepository
        {

            get { return new BaseUserRepository(); }

        }

        public static IRoleRepository RoleRepository
        {

            get { return new RoleRepository(); }

        }
    }
}
