using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLimitMVC.Common
{
    /// <summary>

    /// 枚举出当用户登录的时候出现的各种错误

    /// </summary>

    public enum LoginResult
    {

        PwdError,       //密码错误

        UserNotExist,   //用户不存在

        UserExist,      //用户已存在

        UserIsNull,     //用户名为空

        PwdIsNUll,      //密码为空

        OK,             //登录成功

    }
}
