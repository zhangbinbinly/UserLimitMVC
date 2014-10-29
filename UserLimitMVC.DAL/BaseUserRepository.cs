using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLimitMVC.Model;
using UserLimitMVC.IDAL;

namespace UserLimitMVC.DAL
{
    public class BaseUserRepository : BaseRepository<BaseUser>, IBaseUserRepository
    {

    }
}
