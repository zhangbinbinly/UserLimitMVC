using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLimitMVC.Model;
using UserLimitMVC.IBLL;

namespace UserLimitMVC.BLL
{
    public class RoleService : BaseService<BaseRole>, IRoleService
    {

        //重写抽象方法，设置当前仓储为Role仓储

        public override void SetCurrentRepository()
        {

            //设置当前仓储为Role仓储

            CurrentRepository = DAL.RepositoryFactory.RoleRepository;
        }
    }
}
