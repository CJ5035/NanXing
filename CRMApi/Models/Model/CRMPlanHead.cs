using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.Model
{
	[Table("CRMPlanHead")]
	public class CRMPlanHead
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[StringLength(30)]
		public string CRMApplyNo { get; set; }
		[StringLength(20)]
		public string ClientNo { get; set; }
		[StringLength(50)]
		public string ClientName { get; set; }
		[StringLength(20)]
		public string ApplicantId { get; set; }
		[StringLength(20)]
		public string ApplicantName { get; set; }
		[StringLength(15)]
		public string ApplicantPhone { get; set; }
		[StringLength(20)]
		public string ApplicantDept { get; set; }
		[StringLength(20)]
		public string ApplicantJob { get; set; }
		/// <summary>
		/// 排产申请时间
		/// </summary>
		public DateTime? ApplyTime { get; set; }
		/// <summary>
		/// 客户下单时间
		/// </summary>
		public DateTime? OrderDate { get; set; }
		[StringLength(20)]
		public string SaleGroup { get; set; }
		[StringLength(10)]
		public string OrderSource { get; set; }
		
		[Column(TypeName = "varbinary") ]
		[StringLength(4000)]
		public byte? Photo { get; set; }
		[StringLength(255)]
		public string Remark { get; set; }
		[StringLength(50)]
		public string Reserve1 { get; set; }
		[StringLength(50)]
		public string Reserve2 { get; set; }
		[StringLength(50)]
		public string Reserve3 { get; set; }

		public List<CRMPlanList> CRMPlanLists { get; set; }

	}
}
