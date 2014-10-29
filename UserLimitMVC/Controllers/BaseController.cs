using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLimitMVC.Model;

namespace UserLimitMVC.Controllers
{
    /// <summary>

    /// 基类BaseController，过滤器

    /// </summary>

    public class BaseController : Controller
    {

        //当前登录的用户属性

        public BaseUser CurrentUserInfo { get; set; }



        //重新基类在Action执行之前的事情,在Action执行之前的一个方法

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);

            //得到用户登录的信息

            CurrentUserInfo = Session["UserInfo"] as BaseUser;

            //判断用户是否为空

            if (CurrentUserInfo == null)
            {

                Response.Redirect("/Login/Index");

            }

        }

    }

}