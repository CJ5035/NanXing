using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanXingData_WMS.Dao
{
    [Table("WareLoactionLockHis")]
    public class WareLoactionLockHis
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string WareLocaNo { get; set; }
        [StringLength(20)]
        public string PreState { get; set; }
        [StringLength(20)]
        public string Locker { get; set; }
        public DateTime? LockTime { get; set; }
        public DateTime? UnLockTime { get; set; }

        public int? MissionID { get; set; }
        [ForeignKey("MissionID")]
        public virtual AGVMissionInfo AGVMissionInfo { get; set; }  

    }
}
