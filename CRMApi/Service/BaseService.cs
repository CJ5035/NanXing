using CRMApi.Interface;
using CRMApi.Models.ModelUtils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRMApi.Service
{
    public class BaseService : IBaseService, IDisposable
    {
        protected IDbContextFactory _ContextFactory = null;
        protected DbContext _Context { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public BaseService(IDbContextFactory contextFactory)
        {
            _ContextFactory = contextFactory;
        }

        #region 读取
        /// <summary>
        /// 返回该表所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetAllEntities<T>() where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Read);
            return this._Context.Set<T>().AsQueryable().AsNoTracking();
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambd"></param>
        /// <returns></returns>
        public bool Any<T>(Expression<Func<T, bool>> whereLambd) where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Read);
            return this._Context.Set<T>().Where(whereLambd).Any();
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <typeparam name="T">表名</typeparam>
        /// <param name="predicate">条件</param>
        /// <returns>数量</returns>
        public long Count<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Read);
            if (predicate == null)
            {
                predicate = c => true;
            }
            return this._Context.Set<T>().LongCount(predicate);
        }
        /// <summary>
        /// 获取数量
        /// </summary>
        /// <typeparam name="T">表名</typeparam>
        /// <param name="predicate">条件</param>
        /// <returns>数量</returns>
        public async Task<long> CountAsync<T>(Expression<Func<T, bool>> predicate = null
            , ReadWriteEnum readWriteEnum = ReadWriteEnum.Read) where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(readWriteEnum);
            if (predicate == null)
            {
                predicate = c => true;
            }
            return await this._Context.Set<T>().LongCountAsync(predicate);
        }



        /// <summary>
        /// 根据ID查询.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="readWriteEnum">主从库  即可以读取也可以增删改；</param>
        /// <returns></returns>
        public T Find<T>(int id, ReadWriteEnum readWriteEnum = ReadWriteEnum.Read) where T : class
        {
            //ReadWriteEnum.Read;
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(readWriteEnum);
            return this._Context.Set<T>().Find(id);
        }

        /// <summary>
        /// 根据条件查询单个数据
        /// </summary>
        /// <typeparam name="T">表类</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="isNoTracking">是否带跟踪信息，是否需要修改</param>
        /// <returns></returns>
        public T Find<T>(Expression<Func<T, bool>> predicate = null, bool isNoTracking = true) where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Read);
            var data = isNoTracking ? this._Context.Set<T>().Where(predicate).AsNoTracking() 
                : this._Context.Set<T>().Where(predicate);
            return data.FirstOrDefault();
        }
        /// <summary>
        /// 根据条件查询单个数据（异步）
        /// </summary>
        /// <typeparam name="T">表类</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="isNoTracking">是否带跟踪信息，是否需要修改</param>
        /// <returns></returns>
        public async Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate = null, bool isNoTracking = true) where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Read);
            var data = isNoTracking ? this._Context.Set<T>().Where(predicate).AsNoTracking() 
                : this._Context.Set<T>().Where(predicate);
            return await data.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 异步获取排序集合
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="ordering">排序的属性，倒序用-号在前面，逗号分割</param>
        /// <param name="isNoTracking">是否带跟踪属性</param>
        /// <returns>返回List()</returns>
        public async Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> predicate = null, 
            string ordering = "", bool isNoTracking = true)  where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Read);
            var data = isNoTracking ? this._Context.Set<T>().Where(predicate).AsNoTracking() 
                : this._Context.Set<T>().Where(predicate);
            if (!string.IsNullOrEmpty(ordering))
            {
                data = ExtensionClass.OrderByBatch(data, ordering);
            }
            return await data.ToListAsync();
        }
        /// <summary>
        /// 获取排序集合
        /// </summary>
        /// <typeparam name="T">类</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="ordering">排序的属性，倒序用-号在前面，逗号分割</param>
        /// <param name="isNoTracking">是否带跟踪属性</param>
        /// <returns>返回List()</returns>
        public List<T> GetList<T>(Expression<Func<T, bool>> predicate = null, 
            string ordering = "", bool isNoTracking = true) where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Read);
            var data = isNoTracking ? this._Context.Set<T>().Where(predicate).AsNoTracking() 
                : this._Context.Set<T>().Where(predicate);
            if (!string.IsNullOrEmpty(ordering))
            {
                data = ExtensionClass.OrderByBatch(data, ordering);
            }
            return data.ToList();
        }

        /// <summary>
        /// 异步获取查询结果IQueryable
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="isNoTracking">是否带跟踪</param>
        /// <returns>IQueryable结果</returns>
        public async Task<IQueryable<T>> QueryAsync<T>(Expression<Func<T, bool>> predicate = null
            , bool isNoTracking = true) where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Read);
            if (predicate == null)
            {
                predicate = c => true;
            }
            return await Task.Run(() => isNoTracking ? this._Context.Set<T>().Where(predicate).AsNoTracking() 
                    : this._Context.Set<T>().Where(predicate));
        }
        /// <summary>
        /// 获取查询结果IQueryable
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="isNoTracking">是否带跟踪</param>
        /// <returns>IQueryable结果</returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate = null,
            bool isNoTracking = true) where T : class
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Read);
            if (predicate == null)
            {
                predicate = c => true;
            }
            return isNoTracking ? this._Context.Set<T>().Where(predicate).AsNoTracking() : this._Context.Set<T>().Where(predicate);
        }

        /// <summary>
        /// 通过sql返回实例
        /// </summary>
        /// <typeparam name="T">实例类名</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="readWriteEnum">读写分离</param>
        /// <param name="parameters">sql条件</param>
        /// <returns></returns>
        public IList<T> SqlQuery<T>(string sql, ReadWriteEnum readWriteEnum = ReadWriteEnum.Read, params object[] parameters)
            where T : new()
        {
            //确定链接---从库
            _Context = _ContextFactory.GetMainOrSlave(readWriteEnum);
            //注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常
            var conn = this._Context.Database.GetDbConnection();
            try
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.AddRange(parameters);
                    var propts = typeof(T).GetProperties();
                    var rtnList = new List<T>();
                    T model;
                    object val;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = new T();
                            foreach (var l in propts)
                            {
                                val = reader[l.Name];
                                if (val == DBNull.Value)
                                {
                                    l.SetValue(model, null);
                                }
                                else
                                {
                                    l.SetValue(model, val);
                                }
                            }
                            rtnList.Add(model);
                        }
                    }
                    return rtnList;
                }
            }
            finally
            {
                conn.Close();
            }
        }


        #endregion

        #region 插入
        public T Insert<T>(T t) where T : class
        {
            //ReadWriteEnum.Read;
            //确定链接---主库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Write);
            this._Context.Set<T>().Add(t);
            this.Commit();//写在这里  就不需要单独commit  不写就需要 
            return t;
        }

        public async Task<T> InsertAsync<T>(T t) where T : class
        {
            //ReadWriteEnum.Read;
            //确定链接---主库
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Write);
            await this._Context.Set<T>().AddAsync(t);
            await this.CommitAsync();//写在这里  就不需要单独commit  不写就需要 
            return t;
        }

        #endregion

        #region 删除

        public void Delete<T>(int Id) where T : class
        {
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Write);
            T t = this.Find<T>(Id);//也可以附加
            if (t == null) throw new Exception("t is null");
            this._Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            _Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Write);
            if (t == null) throw new Exception("t is null");
            this._Context.Set<T>().Attach(t);
            this._Context.Set<T>().Remove(t);
            this.Commit();
        }
        #endregion


        #region Other
        public void Commit()
        {
            this._Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await this._Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (this._Context != null)
            {
                this._Context.Dispose();
            }
        }
        
        #endregion

        #region ADO操作数据库
        /// <summary>
        /// 将实例对象的数据存入新的实例中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="type2"></param>
        /// <returns></returns>
        public object ParseValue<T>(T obj, Type type2)
        {
            object retObj = type2.Assembly.CreateInstance(type2.FullName);
            Type type = typeof(T);

            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(type2);
            PropertyDescriptor pd2 = null;
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(type))
            {
                Type proType = pd.PropertyType.Name == "Nullable`1" ? pd.PropertyType.GenericTypeArguments[0] : pd.PropertyType;
                //Debug.WriteLine(pd.Name);
                if (pdc.Contains(pd))
                {
                    //Debug.WriteLine(pd.GetValue(obj));
                    object value = pd.GetValue(obj);
                    pd2 = pdc.Find(pd.Name, true);
                    if (pd2 != null)
                        pd2.SetValue(retObj, value);
                    pd2 = null;
                }
            }
            return retObj;
        }


        /// <summary>
        /// 批量插入（优先推荐）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool SetDataTableToTable(DataTable source, string tableName, string connStr)
        {
            //DateTime time1 = DateTime.Now;

            SqlTransaction tran = null;//声明一个事务对象  
            try
            {
                //_Context = _ContextFactory.GetMainOrSlave(ReadWriteEnum.Write);
                //string connStr = this._Context.Database.GetDbConnection().ConnectionString;
                //Debug.WriteLine(connStr);
                //this._Context.Database.GetDbConnection().

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();//打开链接  
                    using (tran = conn.BeginTransaction())
                    {
                        using (SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                        {
                            copy.DestinationTableName = tableName;           //指定服务器上目标表的名称
                                                                             //rt.WriteLog(source.Rows.Count.ToString());

                            #region 进行字段映射
                            //if (tableName == "ProductOrderheaders" || tableName == "ProductOrderlists"
                            //    || tableName == "production")
                            //{

                            //}
                            foreach (DataColumn temp in source.Columns)
                            {
                                //rt.WriteLog(temp.ColumnName);
                                //Debug.WriteLine(temp.ColumnName);
                                copy.ColumnMappings.Add(temp.ColumnName, temp.ColumnName);
                            }

                            #endregion

                            copy.BulkCopyTimeout = 360;
                            copy.WriteToServer(source);                      //执行把DataTable中的数据写入DB  
                            tran.Commit();                                      //提交事务  
                            conn.Close();//打开链接 

                            //rt.WriteLog("插入数据库时间：" + rt.ReckonSeconds(time1, time2));
                            return true;                                        //返回True 执行成功！  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                if (null != tran)
                    tran.Rollback();

                return false;//返回False 执行失败！  
            }
        }


        /// <summary>
        /// 将类转换成空的dataTable
        /// </summary>
        /// <param name="t">类</param>
        /// <returns>dataTable</returns>
        public DataTable ClassToDataTable(Type t)
        {
            DataTable dataTable = new DataTable();
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(t))
            {
                Type proType = pd.PropertyType.Name == "Nullable`1" ? pd.PropertyType.GenericTypeArguments[0] : pd.PropertyType;

                //ICollection
                if (!proType.FullName.Contains("ICollection") && proType.FullName.StartsWith("System"))
                {
                    //Debug.WriteLine(pd.PropertyType.GenericTypeArguments[0]);
                    if (pd.Name.StartsWith("_"))
                        dataTable.Columns.Add(pd.Name.Substring(1, pd.Name.Length - 1), proType);
                    else
                        dataTable.Columns.Add(pd.Name, proType);
                }
            }
            return dataTable;
        }
        /// <summary>
        /// 将类转换成空的dataTable
        /// </summary>
        /// <param name="t">类</param>
        /// <returns>dataTable</returns>
        public async Task<DataTable> ClassToDataTableAsync(Type t)
        {
            DataTable dataTable = new DataTable();
            await Task.Factory.StartNew(()=>
            {
                foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(t))
                {
                    Type proType = pd.PropertyType.Name == "Nullable`1" ? pd.PropertyType.GenericTypeArguments[0] : pd.PropertyType;

                    //ICollection
                    if (!proType.FullName.Contains("ICollection") && proType.FullName.StartsWith("System"))
                    {
                        //Debug.WriteLine(pd.PropertyType.GenericTypeArguments[0]);
                        if (pd.Name.StartsWith("_"))
                            dataTable.Columns.Add(pd.Name.Substring(1, pd.Name.Length - 1), proType);
                        else
                            dataTable.Columns.Add(pd.Name, proType);
                    }
                }
            });
            return dataTable;
        }


        /// <summary>
        /// 将对象数据插入DataTable中
        /// </summary>
        /// <param name="dt">原DataTable</param>
        /// <param name="obj">实例</param>
        /// <returns>新的DataTable</returns>
        public DataTable ParsePrintItem<T>(DataTable dt, T obj)
        {
            DataRow dr = dt.NewRow();
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor pd2 = null;
            foreach (DataColumn dc in dt.Columns)
            {
                pd2 = pdc.Find(dc.ColumnName, true);
                if (pd2 != null)
                    dr[dc.ColumnName] = pd2.GetValue(obj);
                else
                    dr[dc.ColumnName] = null;
            }
            dt.Rows.Add(dr);
            return dt;
        }
        #endregion
    }
}
