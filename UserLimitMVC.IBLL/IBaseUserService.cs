using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLimitMVC.Model;
using UserLimitMVC.Common;
using LYZJ.UserLimitMVC.Common.Select;

namespace UserLimitMVC.IBLL
{
    public interface IBaseUserService : IBaseService<BaseUser>
    {
        //在这里添加一个用户登录信息的约束

        BaseUser CheckUser(BaseUser userInfo);

        LoginResult CheckUserInfo(BaseUser userInfo);

        LoginResult CheckUserNameTest(string UserName);

        int DeleteUsers(List<int> deleteIDList);

        IQueryable<BaseUser> LoadSearchData(UserInfoQuery query);
    }

}
