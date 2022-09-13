using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingWMS_old.Entity
{
    class ShowMission
    {
        public string 任务单号 { get; set; }
        public DateTime 任务时间 { get; set; }
        public string 任务起点 { get; set; }
        public string 任务终点 { get; set; }
        public string 发送结果 { get; set; }
        public string 执行结果 { get; set; }
        public string 执行设备 { get; set; }

        /// <summary>
        /// Linq结果转DataTable 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">Linq结果</param>
        /// <returns>DataTable</returns>
        public static DataTable ConvertToDataTable<T>(IEnumerable<T> enumerable)
        {
            var dataTable = new DataTable();
            if (string.Empty.GetType() != typeof(T))
            {
                foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(T)))
                {
                    Type proType = pd.PropertyType.Name == "Nullable`1" ? pd.PropertyType.GenericTypeArguments[0] : pd.PropertyType;
                    //ICollection
                    if (!proType.FullName.Contains("Collection") && proType.FullName.StartsWith("System"))
                    {
                        //Debug.WriteLine(pd.PropertyType.GenericTypeArguments[0]);
                        if (pd.Name.StartsWith("_"))
                            dataTable.Columns.Add(pd.Name.Substring(1, pd.Name.Length - 1), proType);
                        else
                            dataTable.Columns.Add(pd.Name, proType);
                    }
                }
                foreach (T item in enumerable)
                {
                    var Row = dataTable.NewRow();

                    foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(T)))
                    {
                        Row[pd.Name] = pd.GetValue(item);
                    }
                    dataTable.Rows.Add(Row);
                }
            }
            else
            {
                dataTable.Columns.Add("column1", string.Empty.GetType());
                foreach (T item in enumerable)
                {
                    var Row = dataTable.NewRow();
                    Row[0] = item;
                    dataTable.Rows.Add(Row);
                }
            }
            return dataTable;
        }
    }
}
