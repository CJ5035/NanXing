using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//using 宏正自动赋码打标系统.Entity;

namespace NanXingWMS_old.Utils
{
    class PrintNewUtils
    {
        string barcode = string.Empty;
        //Plan plan = null;
        public void Print(string printbarcode)
        {
            barcode = string.Empty;
           

            barcode = printbarcode;
            

            PrintDocument printDocument1 = new PrintDocument();
            foreach (PaperSize ps in printDocument1.PrinterSettings.PaperSizes)
            {
                //if (ps.PaperName == "50x30")
                if (ps.PaperName == "100X75")
                {
                    printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                    printDocument1.DefaultPageSettings.PaperSize = ps;
                }
            }
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = "TSC TTP-244 Pro";
            //printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = "TSC T-200A";

            printDocument1.PrintController = new System.Drawing.Printing.StandardPrintController();

            printDocument1.Print();


            //var printPriview = new PrintPreviewDialog
            //{
            //    Document = printDocument1,

            //    WindowState = FormWindowState.Maximized
            //};

            //printPriview.ShowIcon = true;
            //printPriview.ShowDialog();
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = GetQRCode(barcode);
            e.Graphics.DrawImage(bmp, 0, 0);

            //SolidBrush mysbrush1 = new SolidBrush(Color.Black);

            //int line1 = 10;
            //int line2 = 35;
            //int line3 = 60;
            //int line4 = 85;
            //int line5 = 110;
            //int xAvg = 25;


            //int liney1 = 10;
            //int liney2 = 120;
            //int liney3 = 190;
            //int yAvg = 110;

            ////TSCLIB_DLL.sendcommand("BAR 30, 10,540, 3");
            ////TSCLIB_DLL.sendcommand("BAR 30, 300, 540, 3");
            ////TSCLIB_DLL.sendcommand("BAR 30, 225, 280, 3");
            ////TSCLIB_DLL.sendcommand("BAR 30, 150, 280, 3");
            ////TSCLIB_DLL.sendcommand("BAR 30, 75, 280, 3");

            //e.Graphics.DrawLine(Pens.Black, liney2, line1, liney3, line1);
            ////e.Graphics.DrawLine(Pens.Black, 10, line1, 270, line1);
            //e.Graphics.DrawLine(Pens.Black, liney2, line2, liney3, line2);
            //e.Graphics.DrawLine(Pens.Black, liney2, line3, liney3, line3);
            //e.Graphics.DrawLine(Pens.Black, liney2, line4, liney3, line4);

            //e.Graphics.DrawLine(Pens.Black, liney2, line5, liney3, line5);


            ////竖线
            ////TSCLIB_DLL.sendcommand("BAR 570, 10, 3, 290");
            ////TSCLIB_DLL.sendcommand("BAR 30,10, 3, 290");
            ////TSCLIB_DLL.sendcommand("BAR 310, 10, 3, 290");

            ////e.Graphics.DrawLine(Pens.Black, liney1, line1, liney1, line5);
            //e.Graphics.DrawLine(Pens.Black, liney2, line1, liney2, line5);

            //e.Graphics.DrawLine(Pens.Black, liney3, line1, liney3, line5);



            ////e.Graphics.DrawString("120482", font, mysbrush1, new Point(liney2+ (yAvg * 4 / 15), line2-(xAvg*4/5)));
            ////e.Graphics.DrawString("1911080043", font, mysbrush1, new Point(liney2 + (yAvg * 2 / 15), line3 - (xAvg * 4/ 5)));
            ////e.Graphics.DrawString("生产日期", font, mysbrush1, new Point(liney2 + (yAvg * 4 / 20), line4 - (xAvg * 4 / 5)));
            ////e.Graphics.DrawString("2019-11-08/24", font, mysbrush1, new Point(liney2 + (yAvg * 1/ 25), line5 - (xAvg * 4 / 5)));


            ////Font font = new Font("宋体", 6F);
            ////Font snFont = new Font("宋体", 6F);
            ////e.Graphics.DrawString(barcode.Substring(0,6), font, mysbrush1, new Point(liney2 + (yAvg * 3 / 15), line2 - (xAvg *3 / 5)));
            ////e.Graphics.DrawString(barcode.Substring(6, barcode.Length-6), font, mysbrush1, new Point(liney2 + (yAvg * 2 / 15), line3 - (xAvg * 3 / 5)));
            ////e.Graphics.DrawString("生产日期", font, mysbrush1, new Point(liney2 + (yAvg * 3 / 20), line4 - (xAvg * 3 / 5)));
            ////string teamNo = plan.ProTeamNo;
            ////while (plan.ProTeamNo.Length < 2)
            ////    teamNo = "0" + plan.ProTeamNo;
            ////string dateLine = "20" + barcode.Substring(6, barcode.Length - 6).Substring(0, 2) + "-" + barcode.Substring(6, barcode.Length - 6).Substring(2, 2)+"-"+ barcode.Substring(6, barcode.Length - 6).Substring(4, 2)+"/"+ teamNo;
            ////e.Graphics.DrawString(dateLine, font, mysbrush1, new Point(liney2 + (yAvg * 6 /100), line5 - (xAvg * 3 / 5)));

            //Font font = new Font("宋体", 8F);
            //Font dateFont = new Font("宋体", 7F);
            //e.Graphics.DrawString(barcode.Substring(0, 6), font, mysbrush1, new Point(liney2 + (yAvg * 2 / 15), line2 - (xAvg * 7 / 10)));
            //e.Graphics.DrawString(barcode.Substring(6, barcode.Length - 6), font, mysbrush1, new Point(liney2 + (yAvg * 1 / 15), line3 - (xAvg * 7 / 10)));
            //e.Graphics.DrawString("生产日期", font, mysbrush1, new Point(liney2 + (yAvg * 2 / 20), line4 - (xAvg * 7 / 10)));
            //string teamNo = plan.ProTeamNo;
            //while (plan.ProTeamNo.Length < 2)
            //    teamNo = "0" + plan.ProTeamNo;
            //string dateLine = "20" + barcode.Substring(6, barcode.Length - 6).Substring(0, 2) + "-" + barcode.Substring(6, barcode.Length - 6).Substring(2, 2) + "-" + barcode.Substring(6, barcode.Length - 6).Substring(4, 2) + "/" + teamNo;
            //e.Graphics.DrawString(dateLine, dateFont, mysbrush1, new Point(liney2 + (yAvg * 3 / 100), line5 - (xAvg * 3 / 5)));


            ////string sn = dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString() + dt.Rows[i][4].ToString() + dt.Rows[i][5].ToString() + (total - a).ToString("D4");
            ////e.Graphics.DrawString("sn:" + sn, snFont, mysbrush1, new Point(180, 37));
            ////e.Graphics.DrawString(dt.Rows[i][3].ToString(), font, mysbrush1, new Point(80, line2 - 25));
            ////e.Graphics.DrawString(dt.Rows[i][1].ToString(), font, mysbrush1, new Point(80, line3 - 25));
            ////e.Graphics.DrawString(dt.Rows[i][4].ToString(), font, mysbrush1, new Point(80, line4 - 25));
            ////e.Graphics.DrawString(dt.Rows[i][5].ToString(), font, mysbrush1, new Point(80, 190 - 25));
            //string sn = "批号:" + barcode + "\r\n名称:" + plan.ProName + "\r\n货号:" + plan.ProNo + "\r\n规格:" + plan.ProSize + "\r\n公司:" +plan.CompanyName;
            //char[] chr = plan.ProName.ToCharArray();
            //int zwcount=GetHanNumFromString(plan.ProName);
            //int littlecount = plan.ProName.Length - zwcount;
            //int totalCount = zwcount + littlecount/2;
            //int aa =Convert.ToInt32(Math.Round(Convert.ToDouble(totalCount) / 5));

            //Bitmap bmp = GetQRCode(sn);

            ////int bb = Convert.ToInt32(Math.Floor(
            ////    Convert.ToDouble(totalCount) * -5 / 12 + Convert.ToDouble(55) / Convert.ToDouble(4)));
            ////e.Graphics.DrawImage(bmp, new System.Drawing.Point(bb+1,bb-1));
            //Console.WriteLine("字节数：" + totalCount);
            //double xx = Convert.ToDouble(totalCount) / 22.4;
            //int bb = Convert.ToInt32(Math.Floor(
            //  (2.65 - xx) / 2 * Convert.ToDouble(180) / Convert.ToDouble(2.65) / 2));
            ////Console.WriteLine("bb:"+bb);
            ////Console.WriteLine(15 - ((Convert.ToDouble(totalCount) - Convert.ToDouble(50)) * 0.05)* Convert.ToDouble(180) / Convert.ToDouble(2.65));
            //e.Graphics.DrawImage(bmp, new System.Drawing.Point(9 + bb/10, 9 + 5 * bb / 60));


            //Console.WriteLine("63");

        }

        //定义一个函数，返回字符串中的汉字个数
        public int GetHanNumFromString(string str)
        {
            int count = 0;
            Regex regex = new Regex(@"^[\u4E00-\u9FA5]{0,}$");
            for (int i = 0; i < str.Length; i++)
            {
                if (regex.IsMatch(str[i].ToString()))
                {
                    count++;
                }
            }
            return count;
        }

        public Bitmap GetQRCode(string content, int moduleSize = 4)
        {
            //ErrorCorrectionLevel 误差校正水平
            //QuietZoneModules     空白区域
            var encoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = encoder.Encode(content);
            GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(moduleSize, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            MemoryStream memoryStream = new MemoryStream();
            render.WriteToStream(qrCode.Matrix, ImageFormat.Jpeg, memoryStream);
            return (Bitmap)Image.FromStream(memoryStream);
        }
    }
}
