using CRMApi.Models.ModelUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace CRMApi.Interface
{
    public interface IBaseService : IDisposable
    {
        #region Query
        /// <summary>
        /// 返回该表所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetAllEntities<T>() where T : class;

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambd"></param>
        /// <returns></returns>
        public bool Any<T>(Expression<Func<T, bool>> whereLambd) where T : class;

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <typeparam name="T">表名</typeparam>
        /// <param name="predicate">条件</param>
        /// <returns>数量</returns>
        public long Count<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <typeparam name="T">表名</typeparam>
        /// <param name="predicate">条件</param>
        /// <returns>数量</returns>
        public Task<long> CountAsync<T>(Expression<Func<T, bool>> predicate = null
            , ReadWriteEnum readWriteEnum = ReadWriteEnum.Read) where T : class;

        /// <summary>
        /// 根据ID查询.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="readWriteEnum">主从库  即可以读取也可以增删改；</param>
        /// <returns></returns>
        public T Find<T>(int id, ReadWriteEnum readWriteEnum = ReadWriteEnum.Read) where T : class;

        /// <summary>
        /// 根据条件查询单个数据
        /// </summary>
        /// <typeparam name="T">表类</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="isNoTracking">是否带跟踪信息，是否需要修改</param>
        /// <returns></returns>
        public T Find<T>(Expression<Func<T, bool>> predicate = null, bool isNoTracking = true) where T : class;

        /// <summary>
        /// 根据条件查询单个数据（异步）
        /// </summary>
        /// <typeparam name="T">表类</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="isNoTracking">是否带跟踪信息，是否需要修改</param>
        /// <returns></returns>
        public Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate = null, bool isNoTracking = true) where T : class;

        /// <summary>
        /// 获取排序集合
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="ordering">排序的属性，倒序用-号在前面，逗号分割</param>
        /// <param name="isNoTracking">是否带跟踪属性</param>
        /// <returns>返回List()</returns>
        public List<T> GetList<T>(Expression<Func<T, bool>> predicate = null,
            string ordering = "", bool isNoTracking = true) where T : class;
        /// <summary>
        /// 异步获取排序集合
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="ordering">排序的属性，倒序用-号在前面，逗号分割</param>
        /// <param name="isNoTracking">是否带跟踪属性</param>
        /// <returns>返回List()</returns>
        public Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> predicate = null,
            string ordering = "", bool isNoTracking = true) where T : class;

        /// <summary>
        /// 获取查询结果IQueryable
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="isNoTracking">是否带跟踪</param>
        /// <returns>IQueryable结果</returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate = null,
            bool isNoTracking = true) where T : class;

        /// <summary>
        /// 异步获取查询结果IQueryable
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="isNoTracking">是否带跟踪</param>
        /// <returns>IQueryable结果</returns>
        public Task<IQueryable<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate = null
            , bool isNoTracking = true) where T : class;

        /// <summary>
        /// 通过sql返回实例
        /// </summary>
        /// <typeparam name="T">实例类名</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="readWriteEnum">读写分离</param>
        /// <param name="parameters">sql条件</param>
        /// <returns></returns>
        public IList<T> SqlQuery<T>( string sql, ReadWriteEnum readWriteEnum = ReadWriteEnum.Read, params object[] parameters)
           where T : new();
        #endregion

        #region Add
            /// <summary>
            /// 新增数据，即时Commit
            /// </summary>
            /// <param name="t"></param>
            /// <returns>返回带主键的实体</returns>
        public T Insert<T>(T t) where T : class;

        public Task<T> InsertAsync<T>(T t) where T : class;
        #endregion

        #region Delete
        /// <summary>
        /// 根据主键删除数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        public void Delete<T>(int Id) where T : class;

        public void Delete<T>(T t) where T : class;

        #endregion

        #region Other
        /// <summary>
        /// 立即保存全部修改
        /// 把增/删的savechange给放到这里，是为了保证事务的
        /// </summary>
        public void Commit();
        public Task<int> CommitAsync();

        public object ParseValue<T>(T obj, Type type2);

        public bool SetDataTableToTable(DataTable source, string tableName, string connStr);
        public DataTable ClassToDataTable(Type t);
        public Task<DataTable> ClassToDataTableAsync(Type t);
        public DataTable ParsePrintItem<T>(DataTable dt, T obj);
        
        #endregion
    }
}
