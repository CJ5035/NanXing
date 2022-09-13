using NanXingWMS_old.Entity;
using NanXingWMS_old.Model;
using NanXingWMS_old.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanXingWMS_old
{
    public partial class OutStockForm : Form
    {
       
        public OutStockForm(OutStockItem osi)
        {
            InitializeComponent();
            CB_ProName.Text = osi.proName;
            Text_CPBatchNo.Text = osi.batchNo;
            Text_ProBiaoZhun.Text = osi.probiaozhun;
            Text_Spec.Text = osi.spec;
            Text_KuCunCount.Text = osi.count.ToString();
            Text_UsableCount.Text = osi.usableCount.ToString();
            Text_Color.Text= osi.color;
        }

        private void Btn_SureOut_Click(object sender, EventArgs e)
        {
            //写入任务单号在
            if (!string.IsNullOrEmpty(Text_OutCount.Text.Trim()))
            {
                StockPlan sp = new StockPlan();
                //执行存储过程，返回流水号
                Type t = typeof(string);
                SqlParameter[] sqlParms = new SqlParameter[1];
                sqlParms[0] = new SqlParameter("@MaintainCate", "Out");

                var result = Program.DB2.Database.SqlQuery(t, "exec GetSeq @MaintainCate", sqlParms).Cast<string>().First();

                sp.PlanNo = result;
                sp.batchNo = Text_CPBatchNo.Text.Trim();
                sp.count = Convert.ToInt32(Text_OutCount.Text.Trim());
                sp.probiaozhun = Text_ProBiaoZhun.Text.Trim();
                sp.spec = Text_Spec.Text.Trim();
                sp.proname = CB_ProName.Text.Trim();
                sp.color= Text_Color.Text.Trim();
                sp.plantime = DateTime.Now;
                sp.states = "0";
                sp.mark = "03";
                sp.position = ConfigurationManager.AppSettings["position"];

                Program.DB2.StockPlan.Add(sp);
                Program.DB2.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入出仓数量");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OutStockForm_Load(object sender, EventArgs e)
        {

        }

        private void Text_OutCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            int kc = e.KeyChar;
            if ((kc < 48 || kc > 57) && kc != 8)
                e.Handled = true;
            //Console.WriteLine(kc);
            if (kc >= 48 && kc <= 57)
            {
                //Console.WriteLine(Text_OutCount.Text + e.KeyChar);
                if (int.Parse(Text_OutCount.Text + e.KeyChar) > int.Parse(Text_UsableCount.Text))
                {
                    e.Handled = true;
                    Text_OutCount.Text = Text_UsableCount.Text;
                }
            }
            else if (kc == 8)
            {
                if (Text_OutCount.Text.Length == 1)
                {
                    Text_OutCount.Text = "0";

                }
            }
            
        }
    }
}
