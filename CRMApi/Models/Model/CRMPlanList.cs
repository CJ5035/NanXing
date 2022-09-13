using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.Model
{
	[Table("CRMPlanList")]
	public class CRMPlanList
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[StringLength(30)]
		public string CRMApplyNo_Xuhao { get; set; }
		[StringLength(20)]
		public string ItemNo { get; set; }
		[StringLength(100)]
		public string ItemName { get; set; }
		[StringLength(20)]
		public string Spec { get; set; }

		public DateTime? DeliveryTime { get; set; }
		public int OrderCount { get; set; }
		[StringLength(10)]
		public string Unit { get; set; }

		[StringLength(20)]
		public string InventoryCount { get; set; }

		
		public int OrderCountONkg { get; set; }

		[StringLength(10)]
		public string BoxNo { get; set; }

		[StringLength(10)]
		public string BoxName { get; set; }

		[StringLength(10)]
		public string Biaozhun { get; set; }

		[StringLength(255)]
		public string ProductRecipe { get; set; }

		[StringLength(20)]
		public string ApplyNoState { get; set; }

		[StringLength(20)]
		public string EmergencyDegree { get; set; }

		[StringLength(255)]
		public string Remark { get; set; }

		[StringLength(50)]
		public string Reserve1 { get; set; }

		[StringLength(50)]
		public string Reserve2 { get; set; }

		[StringLength(50)]
		public string Reserve3 { get; set; }
		[StringLength(50)]
		public string Reserve4 { get; set; }
		[StringLength(50)]
		public string Reserve5 { get; set; }
		[StringLength(50)]
		public string Reserve6 { get; set; }
		[StringLength(50)]
		public string Reserve7 { get; set; }

		public int CRMPlanHead_Id { get; set; }
		[ForeignKey("CRMPlanHead_Id")]
		public CRMPlanHead crmph { get; set; }
	}
}
