using NanXingWMS_old.Model;
using NanXingWMS_old.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanXingWMS_old
{
    public partial class NewInStockForm : Form
    {
        Form1 form1;
        public NewInStockForm(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void CB_ProName_DropDown(object sender, EventArgs e)
        {
            DataTable dt = ExcelUtils.ReadExcel(Directory.GetCurrentDirectory() + "/排产工艺名.xls");
            CB_ProName.DataSource = dt;
            CB_ProName.ValueMember = "物料名称";
            CB_ProName.DisplayMember = "物料名称";
        }

        private void Text_Prosn_Leave(object sender, EventArgs e)
        {
            //获取标签条码的品名与批号
            if (Text_Prosn.Text.Trim() != string.Empty)
            {
                //查询条码信息
                TrayState ts = Program.DB2.TrayState.Where(u => u.TrayNO == Text_Prosn.Text.Trim()).FirstOrDefault();
                if (ts != null)
                {
                    ICollection<TrayPro> list = ts.TrayPro;

                    List<TrayPro> list2 = new List<TrayPro>();
                    foreach (var i in list)
                    {
                        TrayPro t = i as TrayPro;
                        if (t != null)
                        {
                            list2.Add(t);
                        }
                    }
                    if (list2.Count > 0)
                    {
                        string ps = list2[0].prosn;
                        Production pd = Program.DB2.Production.Where(u => u.prosn == ps).FirstOrDefault();
                        Text_BatchNo.Text = pd.batchNo;
                        CB_ProName.Text = pd.proname;
                    }
                }
                else
                {
                    Text_BatchNo.Text = string.Empty;
                    CB_ProName.Text = string.Empty;
                }

            }
            else
            {
                Text_BatchNo.Text = string.Empty;
                CB_ProName.Text = string.Empty;
                
            }
        }

        private void Text_Num_KeyPress(object sender, KeyPressEventArgs e)
        {
            int kc = e.KeyChar;
            if ((kc < 48 || kc > 57) && kc != 8)
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Text_Num.Text.Trim().Length > 0 && CB_ProName.Text.Trim().Length > 0 && Text_BatchNo.Text.Trim().Length > 0
             &&   Convert.ToInt32(Text_Num.Text.Trim()) >0)
            {
                form1.ChangeStatus(1, CB_ProName.Text.Trim() + ';' + Text_BatchNo.Text.Trim() + ';' + Text_Num.Text.Trim());
                
                Thread.Sleep(500);
                form1.SetIn(Convert.ToInt32(Text_Num.Text.Trim()));
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("请输入正确的产品信息和计划进仓数量");
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
