﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLimitMVC.DAL;
using UserLimitMVC.IDAL;
using System.Linq.Expressions;

namespace UserLimitMVC.BLL
{

    public abstract class BaseService<T> where T : class, new()
    {

        public IDAL.IBaseRepository<T> CurrentRepository { get; set; }

        //DbSession的存放

        //public DbSession _DbSession = new DbSession();

        public IDbSession _DbSession = DbSessionFactory.GetCurrenntDbSession();

        //基类的构造函数

        public BaseService()
        {

            SetCurrentRepository();  //构造函数里面去调用了，此设置当前仓储的抽象方法

        }
        public abstract void SetCurrentRepository();  //子类必须实现


        //实现对数据库的添加功能

        public T AddEntity(T entity)
        {

            //调用T对应的仓储来做添加工作

            var AddEntity = CurrentRepository.AddEntity(entity);

            _DbSession.SaveChanges();

            return AddEntity;

        }

        //实现对数据的修改功能

        public bool UpdateEntity(T entity)
        {

            CurrentRepository.UpdateEntity(entity);

            return _DbSession.SaveChanges() > 0;

        }
        //实现对数据库的删除功能

        public bool DeleteEntity(T entity)
        {
            CurrentRepository.DeleteEntity(entity);

            return _DbSession.SaveChanges() > 0;
        }

        //实现对数据库的查询  --简单查询

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {

            return CurrentRepository.LoadEntities(whereLambda);

        }
        /// <summary>

        /// 实现对数据的分页查询

        /// </summary>

        /// <typeparam name="S">按照某个类进行排序</typeparam>

        /// <param name="pageIndex">当前第几页</param>

        /// <param name="pageSize">一页显示多少条数据</param>

        /// <param name="total">总条数</param>

        /// <param name="whereLambda">取得排序的条件</param>

        /// <param name="isAsc">如何排序，根据倒叙还是升序</param>

        /// <param name="orderByLambda">根据那个字段进行排序</param>

        /// <returns></returns>

        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda,

                                           bool isAsc, Expression<Func<T, S>> orderByLambda)
        {

            return CurrentRepository.LoadPageEntities(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);

        }

    }

}
