using NanXingPengMaServices.Model;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingPengMaServices.Utils
{
    class InOutUtils
    {
        /// <summary>
        /// 获取入库库位
        /// </summary>
        public WareLocation InStockLocation(Production pd)
        {
            //1、获取产品种类
            WareLocation wl = null;
            //2、获取所有库区-产品种类 
            //3、筛选入库区
            //4、入库区筛选未使用的列
            var q1 = Program.DB2.WareArea.Where(u => u.protype == pd.protype);
            if (q1.Count() > 0)
            {
                //1、找已有的列有没有空位
                //1-2有空位的列的数据是否一致
                //1-3一致则插入数据
                //1-4不一致则换列插入数据

                //拿到列
                wl = GetIn2(pd);
            }
            else
            {
                wl = GetIn(pd.protype);
            }
            return wl;
        }

        private WareLocation GetIn2(Production pd)
        {
            //获取改
            DataTable dt = GetWLStates(pd);
            if (dt!=null &&dt.Rows.Count>0)
            {
                string wn = dt.Rows[0]["WareArea"].ToString();
                WareArea wa = Program.DB2.WareArea.Where(u => u.WareNo == wn).OrderBy(u => u.WareNo).FirstOrDefault();
                WareLocation wl = null;
                if (wa.InstockRule == "优先使用小的仓位号")
                {
                    DataTable dt2 = Wl(dt.Rows[0]["kuLie"].ToString(), "asc");
                    string wln = dt2.Rows[0]["lie"].ToString() + dt2.Rows[0]["xuhao"].ToString();
                    wl = Program.DB2.WareLocation.Where(u => u.WareLocaNo == wln).FirstOrDefault();
                }
                else
                {
                    DataTable dt2 = Wl(dt.Rows[0]["kuLie"].ToString(), "desc");
                    string wln = dt2.Rows[0]["lie"].ToString()  + dt2.Rows[0]["xuhao"].ToString();
                    wl = Program.DB2.WareLocation.Where(u => u.WareLocaNo == wln).FirstOrDefault();
                }
                return wl;
            }
            return null;

        }
        private DataTable Wl(string kuLie,string sort)
        {
            string sql = string.Format(@"SELECT ID,LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) lie
		 ,Right(WareLocaNo,len(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) xuhao,
		 a.WareNo,
		 SUBSTRING(WareLocaNo,charindex('-',WareLocaNo)+1,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)-charindex('-',WareLocaNo)-1) lieHao
		  FROM 
		  (select A.*,B.WareNo  from WareLocation A,WareArea B where a.WareArea_ID=B.ID)A
		  WHERE NOT EXISTs(SELECT * FROM TrayState b WHERE A.ID=B.WareLocation_ID)
		  and len(LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))>0
		   and LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))='{0}'
		  order by a.WareNo,
		  CONVERT(int,SUBSTRING(WareLocaNo,charindex('-',WareLocaNo)+1,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)-charindex('-',WareLocaNo)-1))
		   ,CONVERT(int,Right(WareLocaNo,len(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))) {1}", kuLie, sort);
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            return dt;
        }

        private DataTable GetWLStates(Production pd) {
            string sql = string.Format(@" select ID,WareLocaNo,WareArea_ID,header_ID,WareLocaState,AGVPosition into #table1
                 from WareLocation A where  not exists(SELECT location FROM (
                select EndLocation location from  AGVMissionInfo  where SendState='成功'  and RunState is null or (RunState !='已完成' and RunState!='已取消') UNION 
                SELECT StartLocation location from  AGVMissionInfo where SendState='成功'  and RunState is null or (RunState !='已完成' and RunState!='已取消'))B
                where A.AGVPosition=B.location)

            select a.kuLie,a.areaType,a.WareArea,a.xuhao,a.LieCount,a.kuMax,a.kuMin,a.emptyCount,a.lieOnlineCount,batchNo,probiaozhun,spec,protype,color from (
            select a.*,b.lieOnlineCount,LieCount-b.lieOnlineCount emptyCount from
                 ( SELECT LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) kuLie,
                 A.protype areaType,
                left(WareLocaNo,charindex('-',WareLocaNo)-1)WareArea,
                 SUBSTRING(WareLocaNo,charindex('-',WareLocaNo)+1,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)-charindex('-',WareLocaNo)-1) xuhao
                          ,MIN(RIGHT(WareLocaNo,LEN(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))  kuMin
                          ,MAX( RIGHT(WareLocaNo,LEN(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))) kuMax
                          ,convert(int,MAX( RIGHT(WareLocaNo,LEN(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))))-convert(int,MIN(RIGHT(WareLocaNo,LEN(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))))+1 
                          LieCount
                          FROM (select A.*,warearea.protype from [NanXingGuoRen_WMS].[dbo].[WareLocation] A ,WareArea where a.WareArea_ID=WareArea.ID) A 
                         WHERE LEN(LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))>0 and
                          A.WareLocaNo LIKE LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))+'%'
                         GROUP BY LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)),
                         left(WareLocaNo,charindex('-',WareLocaNo)-1),
                 SUBSTRING(WareLocaNo,charindex('-',WareLocaNo)+1,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)-charindex('-',WareLocaNo)-1),A.protype
                         )a
                         left join 
                         (select a.kuLie,ISNULL(b.lieCount,0) lieOnlineCount from
                  (select LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) kuLie from #table1 E 
             group by LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))a left join
                 (
                 select LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) lie,count(*) lieCount from
                 #table1 d ,  (
                 select TrayNO,WareLocation_ID,max(b.prosn) prosn,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color
                  from [NanXingGuoRen_WMS].[dbo].traystate a,[NanXingGuoRen_WMS].[dbo].TrayPro b
                 ,[NanXingGuoRen_WMS].[dbo].Production c
                 where a.ID=b.TrayStateID and b.prosn=c.prosn 
                 group by TrayNO,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,WareLocation_ID)a
                 where a.WareLocation_ID=d.ID group by LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))b
                 on a.kuLie=b.lie)b on a.kuLie=b.kuLie  )a
                 left join (
                    select lie,isnull(batchNo,'') batchNo,isnull(probiaozhun,'') probiaozhun,isnull(spec,'') spec,isnull(protype,'') protype,isnull(color,'') color from   (         
     select TrayNO,WareLocation_ID,
     LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) lie
    --,Right(WareLocaNo,len(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) xuhao
    ,max(b.prosn) prosn,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color
      from [NanXingGuoRen_WMS].[dbo].traystate a,[NanXingGuoRen_WMS].[dbo].TrayPro b
     ,[NanXingGuoRen_WMS].[dbo].Production c,#table1 d 
     where a.ID=b.TrayStateID and b.prosn=c.prosn and len(WareLocation_ID )>0 and a.WareLocation_ID=d.ID
     group by TrayNO,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,WareLocation_ID,
     LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)),
      Right(WareLocaNo,len(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))a)b
      on a.kuLie=b.lie
    where areaType='{3}' and( (lieOnlineCount=0 and emptyCount>0) or
    (lieOnlineCount>0 and emptyCount>0 and ( batchNo ='{0}' and probiaozhun='{1}' and spec='{2}' and protype='{3}' and color='{4}')))
        order by WareArea,convert(int,xuhao)
        drop table #table1 ", pd.batchNo,pd.probiaozhun,pd.spec,pd.protype,pd.color);
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            return dt;
        }

        private WareLocation GetIn(string type)
        {
            DataTable dt = GetLieMaxMin();
            WareArea wa= Program.DB2.WareArea.Where(u => u.protype ==null).OrderBy(u=>u.WareNo).FirstOrDefault();
            WareLocation wl = null; 
            DataRow[] drs = dt.Select("WareArea='" + wa.WareNo + "'");
            //正常入仓
            if (wa.InstockRule== "优先使用小的仓位号")
            {
                string wn = drs[0]["kuLie"].ToString()+ drs[0]["kuMin"].ToString();
                wl = Program.DB2.WareLocation.Where(u => u.WareLocaNo== wn).FirstOrDefault();
            }
            else
            {
                string wn = drs[0]["kuLie"].ToString()+ drs[0]["kuMax"].ToString();
                wl = Program.DB2.WareLocation.Where(u => u.WareLocaNo == wn).FirstOrDefault();
            }
            wa.protype = type;
            Program.DB2.SaveChanges();
            return wl;
        }

        /// <summary>
        /// 获取所有列有没有满，有没有空列
        /// </summary>
        private void GetLieState(List<WareArea> wa, string type)
        {
            //1、获取所有列的最大值、最小值
          
            //


            //2、筛选出所有库区所有空的仓位
            //||a.WareArea.protype==null
          
            List<WareLocation> list = Program.DB2.WareLocation.Where(u => u.WareArea.protype == type && u.TrayState == null).ToList();

            //List<WareArea> list = Program.DB2.WareArea.Where(u => u.protype == type && u.TrayState == null).ToList();
            //筛选出所有已有货物列的匹配值

            //0、获取符合该种类的库区中的仓库不为空的列
            var q = from a in Program.DB2.WareLocation
                    where a.WareArea.protype == type &
                    a.TrayState != null
                    select new
                    {
                        a.WareLocaNo
                    };

            //1、获取所有库区的进出规则
            //2、根据进出规则获取所有列的边界货物，并获取边界外是否有空的仓位
           

        }

        /// <summary>
        /// 获取列的边界、列的最大数量、列的货物数量
        /// </summary>
        /// <returns></returns>
        private DataTable GetLieMaxMin()
        {
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();
            string sql = @"  select a.*,b.lieOnlineCount from
                 ( SELECT LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) kuLie,
                left(WareLocaNo,charindex('-',WareLocaNo)-1)WareArea,
                 SUBSTRING(WareLocaNo,charindex('-',WareLocaNo)+1,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)-charindex('-',WareLocaNo)-1) xuhao
                          ,MIN(RIGHT(WareLocaNo,LEN(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))  kuMin
                          ,MAX( RIGHT(WareLocaNo,LEN(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))) kuMax
                          ,convert(int,MAX( RIGHT(WareLocaNo,LEN(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))))-convert(int,MIN(RIGHT(WareLocaNo,LEN(WareLocaNo)-charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))))+1 
                          LieCount
                          FROM [NanXingGuoRen_WMS].[dbo].[WareLocation] A 
                         WHERE LEN(LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))>0 and
                          A.WareLocaNo LIKE LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1))+'%'
                         GROUP BY LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)),
                         left(WareLocaNo,charindex('-',WareLocaNo)-1),
                 SUBSTRING(WareLocaNo,charindex('-',WareLocaNo)+1,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)-charindex('-',WareLocaNo)-1)
                         )a
                         left join 
                         (select a.kuLie,ISNULL(b.lieCount,0) lieOnlineCount from
                  (select LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) kuLie from [NanXingGuoRen_WMS].[dbo].WareLocation 
             group by LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))a left join
                 
                 select LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) lie,count(*) lieCount from
                 [NanXingGuoRen_WMS].[dbo].WareLocation d ,  (
                 select TrayNO,WareLocation_ID,max(b.prosn) prosn,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color
                  from [NanXingGuoRen_WMS].[dbo].traystate a,[NanXingGuoRen_WMS].[dbo].TrayPro b
                 ,[NanXingGuoRen_WMS].[dbo].Production c
                 where a.ID=b.TrayStateID and b.prosn=c.prosn 
                 group by TrayNO,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,WareLocation_ID)a
                 where a.WareLocation_ID=d.ID group by LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))b
                 on a.kuLie=b.lie)b on a.kuLie=b.kuLie order by WareArea,CONVERT(INT ,xuhao) 
             ";
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 获取列的货物类型数量（保证一列最多两种物料）
        /// </summary>
        /// <returns></returns>
        private DataTable GetLieOnline()
        {
            DbHelperSQL.connectionString = ConfigurationManager.ConnectionStrings["Default"].ToString();

            string sql = @"select a.kuLie,ISNULL(b.classCount,0) lieClassCount from
             (select LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) kuLie from [NanXingGuoRen_WMS].[dbo].WareLocation 
             group by LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)))a left join
             (
             select lie,COUNT(*) classCount from (
             select LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)) lie,batchNo,proname,probiaozhun,spec,protype,color from
             [NanXingGuoRen_WMS].[dbo].WareLocation d ,  (
             select TrayNO,WareLocation_ID,max(b.prosn) prosn,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color
              from [NanXingGuoRen_WMS].[dbo].traystate a,[NanXingGuoRen_WMS].[dbo].TrayPro b
             ,[NanXingGuoRen_WMS].[dbo].Production c
             where a.ID=b.TrayStateID and b.prosn=c.prosn 
             group by TrayNO,c.batchNo,c.proname,c.probiaozhun,c.spec,c.protype,color,WareLocation_ID)a
             where a.WareLocation_ID=d.ID 
             group by LEFT(WareLocaNo,charindex('-',WareLocaNo,charindex('-',WareLocaNo)+1)),batchNo,proname,probiaozhun,spec,protype,color)
             a group by lie
             )b
             on a.kuLie=b.lie where len(kuLie)>0";
            DataTable dt = DbHelperSQL.ReturnDataTable(sql);
            return dt;
        }
    }
}
