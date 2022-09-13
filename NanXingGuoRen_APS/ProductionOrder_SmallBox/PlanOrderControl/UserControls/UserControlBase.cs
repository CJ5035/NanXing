using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanXingGuoRen_APS.ProductionOrder_SmallBox.PlanOrderControl.UserControls
{
    public partial class UserControlBase : System.Web.UI.UserControl
    {

        // 排序
        protected IQueryable<T> Sort<T>(IQueryable<T> q, FineUIPro.Grid grid)
        {
            if (!string.IsNullOrEmpty(grid.SortField) && grid.SortField.Length > 0)
            {
                return q.SortBy(grid.SortField + " " + grid.SortDirection);
            }
            else if (grid.SortFieldArray != null && grid.SortFieldArray.Length > 0)
            {
                return q.SortByArray(grid.SortFieldArray);
            }
            else
                return q.SortBy("ID ASC");

        }

        // 排序后分页
        protected IQueryable<T> SortAndPage<T>(IQueryable<T> q, FineUIPro.Grid grid)
        {
            if (grid.PageIndex >= grid.PageCount && grid.PageCount >= 1)
            {
                grid.PageIndex = grid.PageCount - 1;
            }

            return Sort(q, grid).Skip(grid.PageIndex * grid.PageSize).Take(grid.PageSize);
        }

    }
}