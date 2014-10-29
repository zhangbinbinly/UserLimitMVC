using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLimitMVC.BLL;
using UserLimitMVC.Model;
using LYZJ.UserLimitMVC.Common.Enum;
using UserLimitMVC.Common;

namespace UserLimitMVC.Controllers
{
    public class UserInfoController : BaseController
    {
        //在这里也需要依赖接口编程

        private IBLL.IBaseUserService _userInfoService = new BaseUserService();


        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {

            //Json格式的要求{total:22,rows:{}}

            //实现对用户分页的查询，rows：一共多少条，page：请求的当前第几页

            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            int pageSize = Request["rows"] == null ? 1 : int.Parse(Request["rows"]);

            int total = 0;

            //调用分页的方法，传递参数,拿到分页之后的数据
            var data = _userInfoService.LoadPageEntities(pageIndex, pageSize, out total, u => true, true, u => u.ID).Select(u => new { ID = u.ID, UserName = u.UserName, RealName = u.RealName, Email = u.Email, Gender = u.Gender, Mobile = u.Mobile, DeletionState = u.DeletionStateCode == 1 ? "已删除" : "正常" });

            //构造成Json的格式传递

            var result = new { total = total, rows = data };

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult RegisterUser(BaseUser userInfo)
        {
            //首先保存一些需要录入数据库的信息
            userInfo.Code = Guid.NewGuid().ToString();  //随机产生的一些数据

            userInfo.QuickQuery = userInfo.UserName;   //获取数据的查询码

            userInfo.UserFrom = "添加";               //用户来源

            userInfo.Lang = "汉语";                   //默认系统识别的是汉语

            userInfo.IsStaff = (Int32?)StaffEnum.OK;         //默认是职员

            userInfo.IsVisible = (Int32?)VisibleEnum.OK;     //默认显示信息

            userInfo.Enabled = (Int32?)EnabledEnum.OK;       //默认用户有效

            userInfo.AuditStatus = "已审核";         //默认添加的用户已经经过审核

            userInfo.DeletionStateCode = (Int32?)DeletionStateCodeEnum.Normal;    //默认没有伪删除

            userInfo.CreateOn = DateTime.Parse(DateTime.Now.ToString());     //默认创建用户日期

            BaseUser user = Session["UserInfo"] as BaseUser;

            userInfo.CreateUserID = user.Code;   //获取添加此用户的管理者的ID

            userInfo.CreateBy = user.UserName;//获取添加此用户的管理者的名称

            //执行添加用户的代码

            _userInfoService.AddEntity(userInfo);

            return Content("OK");

        }


        /// <summary>
        /// 删除用户的信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="ID"></param>
        /// <param name="UserName"></param>
        /// <param name="Not"></param>
        /// <returns></returns>
        public ActionResult DeleteUsers(BaseUser userInfo, string ID, string UserName, string Not)
        {
            //首先判断是那个用户登录进入的，如果此用户正在使用这个系统，则不允许用户删除
            userInfo = Session["UserInfo"] as BaseUser;
            var userName = userInfo.UserName; //登录用户的信息
            var uIDsName = UserName.Split(',');  //将传递过来的用户名分割成一个一个的显示
            List<string> listUserInfo = new List<string>();
            foreach (var Name in uIDsName)
            {
                listUserInfo.Add(Name);
            }
            if (listUserInfo.Contains(userName))
            {
                return Content("含有正在使用的用户，禁止删除");
            }
            //下面我们开始删除用户的信息
            //首先判断确认是否从前台传递过来了信息
            if (string.IsNullOrEmpty(ID))
            {
                return Content("请选择需要删除的数据");
            }
            var idStrs = ID.Split(',');  //截取传递过来的字符串
            List<int> deleteIDList = new List<int>();
            foreach (var idStr in idStrs)
            {
                deleteIDList.Add(int.Parse(idStr));
            }

            if (Not == "not")
            {
                //伪删除,也就是根据用户的ID修改信息，首先查询出实体信息
                foreach (var deleteId in deleteIDList)
                {
                    var EditUserDeleteIsNot = _userInfoService.LoadEntities(c => c.ID == deleteId).FirstOrDefault();
                    EditUserDeleteIsNot.DeletionStateCode = 1;
                    _userInfoService.UpdateEntity(EditUserDeleteIsNot);
                }
                return Content("OK");
            }
            else if (Not == "back")
            {
                foreach (var deleteID in deleteIDList)
                {
                    var BackUserDelete = _userInfoService.LoadEntities(c => c.ID == deleteID).FirstOrDefault();
                    BackUserDelete.DeletionStateCode = 0;
                    _userInfoService.UpdateEntity(BackUserDelete);
                }
                return Content("OK");
            }
            else
            {
                //最后执行批量删除数据的方法
                if (_userInfoService.DeleteUsers(deleteIDList) > 0)
                {
                    return Content("OK");
                }
            }
            return Content("删除失败，请您检查");
        }


        /// <summary>
        /// 验证用户名不能重复
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ActionResult CheckUserName(string UserName)
        {

            var checkUserName = _userInfoService.CheckUserNameTest(UserName);

            if (checkUserName == LoginResult.OK)
            {

                return Content("error");

            }

            return Content("OK");

        }
    }
}
