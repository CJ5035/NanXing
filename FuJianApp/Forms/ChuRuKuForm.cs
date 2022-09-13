using NanXingCangKu.Entity;
using NanXingService_WMS.Utils.RedisUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanXingCangKu.Forms
{
    public partial class ChuRuKuForm : Form
    {
        RedisHelper redisHelper = new RedisHelper();
        public ChuRuKuForm()
        {
            InitializeComponent();
        }

        private void ChuRuKuForm_Load(object sender, EventArgs e)
        {
            Date_Start.DatePicker.DateValue = DateTime.Now.AddDays(-7);
            Date_End.DatePicker.DateValue = DateTime.Now;

        }
        private void ChuRuKuForm_Shown(object sender, EventArgs e)
        {
            Btn_MissionF5_Click(null, null);
        }

        private void Btn_MissionF5_Click(object sender, EventArgs e)
        {
            DateTime sdt = Date_Start.DatePicker.DateValue ?? DateTime.Now.AddDays(-7);
            DateTime edt = Date_End.DatePicker.DateValue?? DateTime.Now;
            DateTime dt = DateTime.Parse("2000-01-01");
            Debug.WriteLine(sdt.ToString("yyyy-MM-dd"));

            DataTable cDt = Form1.mainController.ShowMission(sdt,edt.AddDays(1));

            DGV_MissionRecord.DataSource = cDt;
            DGV_MissionRecord.CurrentCell = null;
        }

        private void Btn_CancelMission_Click(object sender, EventArgs e)
        {

        }


        private void Btn_RunTsj1_Click(object sender, EventArgs e)
        {
            if (redisHelper.StringGet<int>($"IsFloorTaskStop:1#提升机","BackService") != 0)
                redisHelper.StringSet($"IsFloorTaskStop:1#提升机",0,null, "BackService");
        }

        private void Btn_RunTsj2_Click(object sender, EventArgs e)
        {
            if(redisHelper.StringGet<int>($"IsFloorTaskStop:2#提升机", "BackService") != 0)
                redisHelper.StringSet($"IsFloorTaskStop:2#提升机", 0, null, "BackService");
        }
    }
}
