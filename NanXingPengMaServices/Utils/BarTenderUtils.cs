using NanXingWMS_old.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ZigBeePrint.Utils
{
    public class BarTenderUtils
    {
        private BarTender.Application btAPP;
        private BarTender.Format btFormat1;
        public BarTenderUtils()
        {
            btAPP = new BarTender.Application();
            //Console.WriteLine(File.Exists(ConfigurationManager.AppSettings["LabelFormat1"].Trim()));

            if (File.Exists(ConfigurationManager.AppSettings["LabelFormat1"].Trim()))
                btFormat1 = btAPP.Formats.Open(ConfigurationManager.AppSettings["LabelFormat1"].Trim(), false, "");
            
        }

        public void PrintLabel(PrintItem printItem)
        {
           
            Print(ConfigurationManager.AppSettings["PrinterName"].Trim(), printItem, 1);
        }

        private void Print(string Printer,PrintItem printItem,int index)
        {
            try
            {
                BarTender.Format btFormat = null;
                //if (index == 1)
                    btFormat = btFormat1;
                //else if (index == 2)
                //    btFormat = btFormat2;
                DateTime dt1 = DateTime.Now;
                //"TSC T-200A"
                btFormat.PrintSetup.Printer = Printer;
                btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;//打印份数
                btFormat.PrintSetup.NumberSerializedLabels = 1;//序列标签数

                btFormat.SetNamedSubStringValue("ProName", printItem.ProName.Trim());
                btFormat.SetNamedSubStringValue("ProDate", printItem.ProDate.Trim());
                btFormat.SetNamedSubStringValue("count", printItem.Num.Trim());
                
                btFormat.SetNamedSubStringValue("batchNo", printItem.BatchNo.Trim());

                btFormat.SetNamedSubStringValue("color", printItem.color.Trim());
                btFormat.SetNamedSubStringValue("biaoZhun", printItem.biaoZhun.Trim());
                btFormat.SetNamedSubStringValue("spec", printItem.spec.Trim());
                btFormat.SetNamedSubStringValue("boxName", printItem.boxName.Trim());
                btFormat.SetNamedSubStringValue("remark", printItem.remark.Trim());

                btFormat.SetNamedSubStringValue("yuanliaoBatchNo", printItem.YuanLiaoBatchNo.Trim());
                btFormat.SetNamedSubStringValue("QRCode", printItem.QRCode.Trim());

                //btFormat.SetNamedSubStringValue("MAC", printItem.MAC.Trim());

                btFormat.PrintOut(true, false);//第二个false设置打印时是否跳出打印属性
                Console.WriteLine("打印时间："+ReckonSeconds(DateTime.Now, dt1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void PrintLabel2(string qrCode)
        {
            if (ConfigurationManager.AppSettings["IsPrint1"].Trim() == "true"
                 && ConfigurationManager.AppSettings["PrinterName1"].Trim() != "")
            {
                Print2(ConfigurationManager.AppSettings["PrinterName1"].Trim(), qrCode, 1);
            }
            //if (ConfigurationManager.AppSettings["IsPrint2"].Trim() == "true"
            //     && ConfigurationManager.AppSettings["PrinterName2"].Trim() != "")
            //{
            //    Print2(ConfigurationManager.AppSettings["PrinterName2"].Trim(), qrCode, 2);
            //}
        }
        private void Print2(string Printer, string qrCode, int index)
        {
            try
            {
                BarTender.Format btFormat = null;
                //if (index == 1)
                    btFormat = btFormat1;
                //else if (index == 2)
                //    btFormat = btFormat2;
                DateTime dt1 = DateTime.Now;
                //"TSC T-200A"
                btFormat.PrintSetup.Printer = Printer;
                btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;//打印份数
                btFormat.PrintSetup.NumberSerializedLabels = 1;//序列标签数
                btFormat.SetNamedSubStringValue("QRCode", qrCode.Trim());
                //btFormat.SetNamedSubStringValue("MAC", printItem.MAC.Trim());

                btFormat.PrintOut(true, false);//第二个false设置打印时是否跳出打印属性
                Console.WriteLine("打印时间：" + ReckonSeconds(DateTime.Now, dt1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClosePrint()
        {
            if(btFormat1!=null)
                btFormat1.Close(BarTender.BtSaveOptions.btSaveChanges); //退出时是否保存标签
            //if (btFormat2 != null)
            //    btFormat2.Close(BarTender.BtSaveOptions.btSaveChanges); //退出时是否保存标签
            btAPP.Quit(BarTender.BtSaveOptions.btSaveChanges);//界面退出时同步退出bartender进程
        }

        private string ReckonSeconds(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = (dt2 - dt1).Duration();

            double second = 0;
            if (ts.Hours > 0)
            {
                second += ts.Hours * 3600;
            }
            if (ts.Minutes > 0)
            {
                second += ts.Minutes * 60;
            }
            second += ts.Seconds;
            second += (ts.Milliseconds * 0.001);

            return second.ToString();

        }
    }
}
