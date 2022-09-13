using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.ModelUtils
{
    public class DbContextFactory : IDbContextFactory
    {
       
        private DbContext _Context = null;

        public DBConnectionOption _readAndWrite = null;

        //private static int _iSeed = 0;//应该long

        /// <summary>
        ///能把链接信息也注入进来
        ///需要IOptionsMonitor
        /// </summary>
        /// <param name="context"></param>
        public DbContextFactory(DbContext context, IOptionsMonitor<DBConnectionOption> options)
        {
            _readAndWrite = options.CurrentValue;
            this._Context = context;
        }
        public DbContext GetMainOrSlave(ReadWriteEnum readWriteEnum)
        {
            //判断枚举，不同的枚举可以创建不同的Context 或者更换Context链接；
            switch (readWriteEnum)
            {
                case ReadWriteEnum.Write:
                    SetMainConnnectionString();
                    break;  //选择链接//更换_Context链接   //选择链接
                case ReadWriteEnum.Read:
                    SetSlaveConnectionString();
                    break;  //选择链接//更换_Context链接
                default:
                    break;
            }
            return _Context;
        }

        /// <summary>
        /// 更换成主库连接
        /// </summary>
        /// <returns></returns>
        private void SetMainConnnectionString()
        {
            string conn = _readAndWrite.MainConnectionString;
            _Context.SetCurrentConnString(conn);
        }


        private static int _iSeed = 0;

        /// <summary>
        /// 更换成主库连接
        /// 
        /// ///策略---数据库查询的负载均衡
        /// </summary>
        /// <returns></returns>
        private void SetSlaveConnectionString()
        {
            string conn = string.Empty;
            {
                // //随机
                //int Count=  _readAndWrite.ReadConnectionList.Count;
                //int index=  new Random().Next(0, Count);
                //conn = _readAndWrite.ReadConnectionList[index];
            }
            {
                //来一个轮询
                conn = this._readAndWrite.SlaveConnectionStringList[_iSeed++ % this._readAndWrite.SlaveConnectionStringList.Count];//轮询;  
            }
            {
                ///是不是可以直接配置到配置文件里面
            }
            _Context.SetCurrentConnString(conn);
        }
    }
}
