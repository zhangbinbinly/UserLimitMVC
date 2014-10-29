﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLimitMVC.IDAL;
using System.Data.Objects;

namespace UserLimitMVC.DAL
{
    //一次跟数据库交互的会话

    public class DbSession : IDbSession //代表应用程序跟数据库之间的一次会话，也是数据库访问层的统一入口
    {

        public IDAL.IRoleRepository RoleRepository
        {

            get { return new RoleRepository(); }

        }

        public IDAL.IBaseUserRepository BaseUserRepository
        {

            get { return new BaseUserRepository(); }

        }

        //代表：当前应用程序跟数据库的会话内所有的实体的变化，更新会数据库

        public int SaveChanges()
        {

            //调用EF上下文的SaveChanges方法

            return DAL.EFContextFactory.GetCurrentDbContext().SaveChanges();

        }

        //执行Sql脚本的方法

        public int ExcuteSql(string strSql, ObjectParameter[] parameters)
        {

            //Ef4.0的执行方法 ObjectContext

            //封装一个执行SQl脚本的代码

            //return DAL.EFContextFactory.GetCurrentDbContext().ExecuteFunction(strSql, parameters);

            return DAL.EFContextFactory.GetCurrentDbContext().ExecuteStoreCommand(strSql, parameters);

            //throw new NotImplementedException();

        }

    }
}
