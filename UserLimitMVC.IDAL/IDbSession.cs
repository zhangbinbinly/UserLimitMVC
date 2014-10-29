using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace UserLimitMVC.IDAL
{
    public interface IDbSession
    {

        //每个表对应的实体仓储对象

        IDAL.IRoleRepository RoleRepository { get; }

        IDAL.IBaseUserRepository BaseUserRepository { get; }

        //将当前应用程序跟数据库的会话内所有实体的变化更新会数据库

        int SaveChanges();

        //执行Sql语句的方法

        //EF4.0的写法

        int ExcuteSql(string strSql, ObjectParameter[] parameters);

        //EF5.0的写法

        //int ExcuteSql(string strSql, DbParameter[] parameters);

    }

}
