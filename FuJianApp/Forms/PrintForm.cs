using NanXingCangKu.Controller;
using NanXingCangKu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanXingCangKu.Forms
{
    public partial class PrintForm : Form
    {
        //MainController mainController;
        public PrintForm()
        {
            InitializeComponent();
        }
        //public PrintForm(MainController mc)
        //{
        //    InitializeComponent();
        //}

        private async void Btn_Print_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != string.Empty)
            {
                DateTime dt=DateTime.Now;
                int count = int.Parse(textBox3.Text.Trim());
                //无二维码的打印实例
                PrintItem printItem =
                        new PrintItem(CB_Department.Text.Trim(),CB_PRName.Text.Trim(), string.Empty, 
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"), 
                        textBox2.Text.Trim(), Text_BatchNo.Text.Trim()
                        , Text_YLBatchNo.Text.Trim(), CB_guose.Text.Trim(), 
                        CB_biaozhun.Text.Trim(), CB_baocai.Text.Trim()
                        , Text_Remark.Text.Trim(), CB_Spec.Text.Trim());
                try
                {
                    Form1.mainController.Print(printItem, count);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                Trace.WriteLine(Form1.mainController.RecTime(dt, DateTime.Now));
            }
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {

        }
    }
}
