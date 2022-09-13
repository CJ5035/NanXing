
namespace NanXingCangKu.Forms
{
    partial class ChuRuKuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Date_End = new WinformControlLibraryExtension.DateExt();
            this.Date_Start = new WinformControlLibraryExtension.DateExt();
            this.Btn_MissionF5 = new WinformControlLibraryExtension.ButtonExt();
            this.label14 = new System.Windows.Forms.Label();
            this.DGV_MissionRecord = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_RunTsj2 = new WinformControlLibraryExtension.ButtonExt();
            this.Btn_RunTsj1 = new WinformControlLibraryExtension.ButtonExt();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MissionRecord)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.Date_End);
            this.panel3.Controls.Add(this.Date_Start);
            this.panel3.Controls.Add(this.Btn_MissionF5);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.DGV_MissionRecord);
            this.panel3.Location = new System.Drawing.Point(16, 13);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1144, 918);
            this.panel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(503, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "起止时间";
            // 
            // Date_End
            // 
            this.Date_End.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_End.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.Date_End.DatePicker.ActivateColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Date_End.DatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_End.DatePicker.BottomBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_End.DatePicker.BottomBarBtnBackNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_End.DatePicker.BottomBarBtnForeNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_End.DatePicker.BottomBarClockDotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Date_End.DatePicker.BottomBarTipForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(171)))), ((int)(((byte)(1)))));
            this.Date_End.DatePicker.DateBackDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Date_End.DatePicker.DateBackNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_End.DatePicker.DateBackSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_End.DatePicker.DateForeDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Date_End.DatePicker.DateForeFutureColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.Date_End.DatePicker.DateForeNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_End.DatePicker.DateForePastColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.Date_End.DatePicker.DateForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_End.DatePicker.DateTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.Date_End.DatePicker.Location = new System.Drawing.Point(0, 0);
            this.Date_End.DatePicker.Name = "";
            this.Date_End.DatePicker.TabIndex = 0;
            this.Date_End.DatePicker.TimeBackSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_End.DatePicker.TimeForeNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_End.DatePicker.TimeForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_End.DatePicker.TopBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_End.DatePicker.TopBarBtnForeNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_End.DateStyle = WinformControlLibraryExtension.DateExt.DateStyles.DataPanel;
            this.Date_End.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Date_End.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.Date_End.Location = new System.Drawing.Point(807, 18);
            this.Date_End.Margin = new System.Windows.Forms.Padding(4);
            this.Date_End.Name = "Date_End";
            this.Date_End.Size = new System.Drawing.Size(173, 24);
            this.Date_End.TabIndex = 41;
            // 
            // Date_Start
            // 
            this.Date_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_Start.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.Date_Start.DatePicker.ActivateColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Date_Start.DatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_Start.DatePicker.BottomBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_Start.DatePicker.BottomBarBtnBackNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_Start.DatePicker.BottomBarBtnForeNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_Start.DatePicker.BottomBarClockDotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Date_Start.DatePicker.BottomBarTipForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(171)))), ((int)(((byte)(1)))));
            this.Date_Start.DatePicker.DateBackDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Date_Start.DatePicker.DateBackNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_Start.DatePicker.DateBackSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_Start.DatePicker.DateForeDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Date_Start.DatePicker.DateForeFutureColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.Date_Start.DatePicker.DateForeNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_Start.DatePicker.DateForePastColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.Date_Start.DatePicker.DateForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_Start.DatePicker.DateTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.Date_Start.DatePicker.Location = new System.Drawing.Point(0, 0);
            this.Date_Start.DatePicker.Name = "";
            this.Date_Start.DatePicker.TabIndex = 0;
            this.Date_Start.DatePicker.TimeBackSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_Start.DatePicker.TimeForeNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_Start.DatePicker.TimeForeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_Start.DatePicker.TopBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(139)))), ((int)(((byte)(192)))));
            this.Date_Start.DatePicker.TopBarBtnForeNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Date_Start.DateStyle = WinformControlLibraryExtension.DateExt.DateStyles.DataPanel;
            this.Date_Start.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Date_Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.Date_Start.Location = new System.Drawing.Point(607, 18);
            this.Date_Start.Margin = new System.Windows.Forms.Padding(4);
            this.Date_Start.Name = "Date_Start";
            this.Date_Start.Size = new System.Drawing.Size(173, 24);
            this.Date_Start.TabIndex = 40;
            // 
            // Btn_MissionF5
            // 
            this.Btn_MissionF5.Animation.Options.AllTransformTime = 250D;
            this.Btn_MissionF5.Animation.Options.Data = null;
            this.Btn_MissionF5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.Btn_MissionF5.FlatAppearance.BorderSize = 0;
            this.Btn_MissionF5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_MissionF5.Location = new System.Drawing.Point(996, 15);
            this.Btn_MissionF5.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_MissionF5.Name = "Btn_MissionF5";
            this.Btn_MissionF5.Size = new System.Drawing.Size(133, 36);
            this.Btn_MissionF5.TabIndex = 38;
            this.Btn_MissionF5.Text = "刷新";
            this.Btn_MissionF5.Click += new System.EventHandler(this.Btn_MissionF5_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(12, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 25);
            this.label14.TabIndex = 36;
            this.label14.Text = "AGV任务管理";
            // 
            // DGV_MissionRecord
            // 
            this.DGV_MissionRecord.AllowUserToAddRows = false;
            this.DGV_MissionRecord.AllowUserToDeleteRows = false;
            this.DGV_MissionRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_MissionRecord.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DGV_MissionRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_MissionRecord.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGV_MissionRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_MissionRecord.Location = new System.Drawing.Point(4, 59);
            this.DGV_MissionRecord.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_MissionRecord.Name = "DGV_MissionRecord";
            this.DGV_MissionRecord.ReadOnly = true;
            this.DGV_MissionRecord.RowHeadersVisible = false;
            this.DGV_MissionRecord.RowHeadersWidth = 51;
            this.DGV_MissionRecord.RowTemplate.Height = 23;
            this.DGV_MissionRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_MissionRecord.Size = new System.Drawing.Size(1133, 855);
            this.DGV_MissionRecord.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Btn_RunTsj2);
            this.panel1.Controls.Add(this.Btn_RunTsj1);
            this.panel1.Location = new System.Drawing.Point(1192, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 494);
            this.panel1.TabIndex = 6;
            // 
            // Btn_RunTsj2
            // 
            this.Btn_RunTsj2.Animation.Options.AllTransformTime = 250D;
            this.Btn_RunTsj2.Animation.Options.Data = null;
            this.Btn_RunTsj2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.Btn_RunTsj2.FlatAppearance.BorderSize = 0;
            this.Btn_RunTsj2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_RunTsj2.Location = new System.Drawing.Point(4, 88);
            this.Btn_RunTsj2.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_RunTsj2.Name = "Btn_RunTsj2";
            this.Btn_RunTsj2.Size = new System.Drawing.Size(200, 36);
            this.Btn_RunTsj2.TabIndex = 44;
            this.Btn_RunTsj2.Text = "开启提升机2线程";
            this.Btn_RunTsj2.Click += new System.EventHandler(this.Btn_RunTsj2_Click);
            // 
            // Btn_RunTsj1
            // 
            this.Btn_RunTsj1.Animation.Options.AllTransformTime = 250D;
            this.Btn_RunTsj1.Animation.Options.Data = null;
            this.Btn_RunTsj1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.Btn_RunTsj1.FlatAppearance.BorderSize = 0;
            this.Btn_RunTsj1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_RunTsj1.Location = new System.Drawing.Point(4, 30);
            this.Btn_RunTsj1.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_RunTsj1.Name = "Btn_RunTsj1";
            this.Btn_RunTsj1.Size = new System.Drawing.Size(200, 36);
            this.Btn_RunTsj1.TabIndex = 43;
            this.Btn_RunTsj1.Text = "开启提升机1线程";
            this.Btn_RunTsj1.Click += new System.EventHandler(this.Btn_RunTsj1_Click);
            // 
            // ChuRuKuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1840, 946);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChuRuKuForm";
            this.Text = "ChuRuKuForm";
            this.Load += new System.EventHandler(this.ChuRuKuForm_Load);
            this.Shown += new System.EventHandler(this.ChuRuKuForm_Shown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_MissionRecord)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView DGV_MissionRecord;
        private WinformControlLibraryExtension.ButtonExt Btn_MissionF5;
        private WinformControlLibraryExtension.DateExt Date_Start;
        private System.Windows.Forms.Label label1;
        private WinformControlLibraryExtension.DateExt Date_End;
        private System.Windows.Forms.Panel panel1;
        private WinformControlLibraryExtension.ButtonExt Btn_RunTsj2;
        private WinformControlLibraryExtension.ButtonExt Btn_RunTsj1;
    }
}