using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Models.Entity
{
	/// <summary>
	/// CRM排产申请单写入类
	/// </summary>
	public class CRMPlanWriter
    {
		/// <summary>
		/// 排产申请单号
		/// </summary>
		public string CRMApplyNo { get; set; }
		/// <summary>
		/// 客户编码
		/// </summary>
		public string ClientNo { get; set; }
		/// <summary>
		/// 客户名称
		/// </summary>
		public string ClientName { get; set; }
		/// <summary>
		/// 申请人工号
		/// </summary>
		public string ApplicantId { get; set; }
		/// <summary>
		/// 申请人姓名
		/// </summary>
		public string ApplicantName { get; set; }

		/// <summary>
		/// 申请人电话
		/// </summary>
		public string ApplicantPhone { get; set; }
		/// <summary>
		/// 申请人部门
		/// </summary>
		public string ApplicantDept { get; set; }

		/// <summary>
		/// 申请人岗位
		/// </summary>
		public string ApplicantJob { get; set; }

		/// <summary>
		/// 申请时间
		/// </summary>
		public DateTime? ApplyTime { get; set; }

		/// <summary>
		/// 客户下单日期
		/// </summary>
		public DateTime? OrderDate { get; set; }

		/// <summary>
		/// 销售组
		/// </summary>
		public string SaleGroup { get; set; }
		/// <summary>
		/// 单据来源
		/// </summary>
		public string OrderSource { get; set; }
		/// <summary>
		/// 单据备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 备用字段1
		/// </summary>
		public string Reserve1 { get; set; }
		/// <summary>
		/// 备用字段2
		/// </summary>
		public string Reserve2 { get; set; }
		/// <summary>
		/// 备用字段3
		/// </summary>
		public string Reserve3 { get; set; }

		/// <summary>
		/// CRM排产申请单 子单
		/// </summary>
		public List<CRMPlanListWriter> CRMPlanLists { get; set; }
	}

	/// <summary>
	/// CRM排产申请单 子单 写入类
	/// </summary>

	public class CRMPlanListWriter
    {
		/// <summary>
		/// 排产申请单行号
		/// </summary>
		public string CRMApplyNo_Xuhao { get; set; }
		/// <summary>
		/// 产品编码
		/// </summary>
		public string ItemNo { get; set; }
		/// <summary>
		/// 产品名称
		/// </summary>
		public string ItemName { get; set; }
		/// <summary>
		/// 包装规格
		/// </summary>
		public string Spec { get; set; }

		/// <summary>
		/// 订货数量
		/// </summary>
		public int OrderCount { get; set; }

		/// <summary>
		/// 订货单位
		/// </summary>
		public string Unit { get; set; }
		/// <summary>
		/// 库存情况(件)
		/// </summary>
		public string InventoryCount { get; set; }

		/// <summary>
		/// 订货数量(Kg)
		/// </summary>
		public int OrderCountONkg { get; set; }

		/// <summary>
		/// 包装箱号
		/// </summary>
		public string BoxNo { get; set; }

		/// <summary>
		/// 包装箱名
		/// </summary>
		public string BoxName { get; set; }

		/// <summary>
		/// 执行标准
		/// </summary>
		public string Biaozhun { get; set; }

		/// <summary>
		/// 生产配方
		/// </summary>
		public string ProductRecipe { get; set; }

		/// <summary>
		/// 单据状态
		/// </summary>
		public string ApplyNoState { get; set; }

		/// <summary>
		/// 紧急程度
		/// </summary>
		public string EmergencyDegree { get; set; }

		/// <summary>
		/// 申请备注
		/// </summary>
		public string Remark { get; set; }

		/// <summary>
		/// 备用字段1
		/// </summary>
		public string Reserve1 { get; set; }
		/// <summary>
		/// 备用字段2
		/// </summary>
		public string Reserve2 { get; set; }

		/// <summary>
		/// 备用字段3
		/// </summary>
		public string Reserve3 { get; set; }
		/// <summary>
		/// 备用字段4
		/// </summary>
		public string Reserve4 { get; set; }
		/// <summary>
		/// 备用字段5
		/// </summary>
		public string Reserve5 { get; set; }
		/// <summary>
		/// 备用字段6
		/// </summary>
		public string Reserve6 { get; set; }
		/// <summary>
		/// 备用字段7
		/// </summary>
		public string Reserve7 { get; set; }
	}
}
