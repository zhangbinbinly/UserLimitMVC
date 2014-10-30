using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLimitMVC.IDAL;
using UserLimitMVC.Model;
using UserLimitMVC.DAL;
using UserLimitMVC.IBLL;
using UserLimitMVC.Common;
using LYZJ.UserLimitMVC.Common.Select;

namespace UserLimitMVC.BLL
{
    /// <summary>

    /// User业务逻辑

    /// </summary>

    public class BaseUserService : BaseService<BaseUser>, IBaseUserService
    {

        public override void SetCurrentRepository()
        {

            CurrentRepository = DAL.RepositoryFactory.UserRepository;

        }

        //完成了对用户的校验

        public BaseUser CheckUser(BaseUser User)
        {

            //在这里会去数据库检查是否有数据，如果没有的话就会返回一个空值

            return _DbSession.BaseUserRepository.LoadEntities(u => u.UserName == User.UserName && u.UserPassword == User.UserPassword).FirstOrDefault();

        }

        public LoginResult CheckUserInfo(BaseUser userInfo)
        {

            //首先判断用户名，密码是否为空

            if (string.IsNullOrEmpty(userInfo.UserName))
            {

                return LoginResult.UserIsNull;

            }

            if (string.IsNullOrEmpty(userInfo.UserPassword))
            {

                return LoginResult.PwdIsNUll;

            }

            //如果不为空的话则去数据库中查询信息

            //在这里会去数据库检查是否有数据，如果没有的话就会返回一个空值

            var LoginUserInfoCheck = _DbSession.BaseUserRepository.LoadEntities(u => u.UserName == userInfo.UserName).FirstOrDefault();

            //对返回的结果进行判断

            if (LoginUserInfoCheck == null)
            {

                return LoginResult.UserNotExist;

            }

            if (LoginUserInfoCheck.UserPassword != userInfo.UserPassword)
            {

                return LoginResult.PwdError;

            }

            else
            {

                return LoginResult.OK;

            }

        }

        /// <summary>
        /// 判断用户名不能重复
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public LoginResult CheckUserNameTest(string UserName)
        {

            //首先判断是否为空

            if (String.IsNullOrEmpty(UserName))
            {

                return LoginResult.UserIsNull;

            }

            var checkUserName = _DbSession.BaseUserRepository.LoadEntities(u => u.UserName == UserName).FirstOrDefault();

            if (checkUserName != null)
            {

                return LoginResult.UserExist;

            }

            else
            {

                return LoginResult.OK;

            }

        }

        /// <summary>
        /// 实现对多条件查询的判断方法的封装
        /// </summary>
        /// <param name="query">引用传递，传递参数的信息</param>
        /// <returns>返回用户类的IQueryable集合</returns>
        public IQueryable<BaseUser> LoadSearchData(UserInfoQuery query)
        {
            var temp = _DbSession.BaseUserRepository.LoadEntities(u => true);
            //首先过滤姓名
            if (!string.IsNullOrEmpty(query.RealName))
            {
                temp = temp.Where<BaseUser>(u => u.RealName.Contains(query.RealName));  //like '%mmm%'
            }
            if (!string.IsNullOrEmpty(query.Telephone))
            {
                temp = temp.Where<BaseUser>(u => u.Telephone.Contains(query.Telephone));
            }
            if (!string.IsNullOrEmpty(query.EMail))
            {
                temp = temp.Where<BaseUser>(u => u.Email.Contains(query.EMail));
            }
            if (query.Enabled != -1)
            {
                temp = temp.Where<BaseUser>(u => u.Enabled == query.Enabled);
            }
            if (!string.IsNullOrEmpty(query.AuditStatus) && query.AuditStatus != "-1")
            {
                temp = temp.Where<BaseUser>(u => u.AuditStatus.Contains(query.AuditStatus));
            }
            temp = query.DeletionStateCod == 1 ? temp.Where<BaseUser>(u => u.DeletionStateCode == query.DeletionStateCod) : temp.Where<BaseUser>(u => u.DeletionStateCode == 0);
            query.Total = temp.Count();
            return temp.OrderBy(u => u.SortCode).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
        }

        /// <summary>
        /// 实现批量删除数据
        /// </summary>
        /// <param name="deleteIds"></param>
        /// <returns></returns>
        public int DeleteUsers(List<int> deleteIds)
        {
            bool deleteResult = true;
            foreach (var deleteID in deleteIds)
            {

                deleteResult = _DbSession.BaseUserRepository.DeleteEntity(new BaseUser()

                  {

                      ID = deleteID

                  });

            }

            //return _DbSession.SaveChanges();
            return deleteResult ? 1 : 0;
        }

        //访问DAL实现CRUD

        //private DAL.UserRepository _UserRepository = new UserRepository();

        //依赖接口编程

        //private IUserRepository _UserRepository = new UserRepository();

        //private IUserRepository _UserRepository = RepositoryFactory.UserRepository;

        //public  User AddUser(User User)

        //{

        //    return _UserRepository.AddEntity(User);

        //}

        //public bool UpdateUser(User User)

        //{

        //    return _UserRepository.UpdateEntity(User);

        //}

    }

}
