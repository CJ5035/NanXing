using NanXingCangKu.Controller;
using NanXingCangKu.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WinformControlLibraryExtension;

namespace NanXingCangKu
{
    public partial class Form1 : FormExt
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static MainController mainController = null;
        private void Form1_Load(object sender, EventArgs e)
        {

            //初始化菜单栏
            Bind(slideMenuExt1.MenuPanel);

            //this.slideMenuExt1.MenuPanel.SelectedChanged += MenuPanel_SelectedChanged;
            this.slideMenuExt1.MenuPanel.NodeClick += this.MenuPanel_NodeClick;
            this.slideMenuExt1.PatternChanged += this.menuExt1_PatternChanged;
            this.slideMenuExt1.MenuPanel.Drag.Draging += Draw_Drawing;

            //初始化主控制器
            mainController = new MainController(this);
            mainController.Init();
            //mainController.Start();
          
           

           
        }

        private void Draw_Drawing(object sender, SlideMenuPanelExt.DragingEventArgs e)
        {
            this.slideMenuExt1.MenuWidth += e.X;
            this.panel1.Width = this.ClientRectangle.Width - this.slideMenuExt1.Width - this.BorderWidth * 2;
            this.panel1.Location = new Point(this.slideMenuExt1.Right, this.panel1.Location.Y);
        }

        private void menuExt1_PatternChanged(object sender, SlideMenuExt.PatternChangedEventArgs e)
        {
            this.panel1.Width = this.ClientRectangle.Width - this.slideMenuExt1.Width - this.BorderWidth * 2;
            this.panel1.Location = new Point(this.slideMenuExt1.Right, this.panel1.Location.Y);
        }
        Dictionary<string, Form> dic = new Dictionary<string, Form>();
        
        private void MenuPanel_NodeClick(object sender, SlideMenuPanelExt.NodeClickEventArgs e)
        {
            if (e.Node.ItemType == SlideMenuPanelExt.NodeTypes.MenuTab)
            {
                ConstructorInfo _constructor = ((Type)e.Node.Data).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[] {}, null);
                Form _constructor_obj = (Form)_constructor.Invoke(new object[] {});
                _constructor_obj.Dock = DockStyle.Fill;
                if (_constructor_obj is IFormExt)
                {
                    FormExt fe = (FormExt)_constructor_obj;
                    fe.Padding = new Padding(0);
                    fe.BorderEnabled = false;
                    fe.CaptionEnabled = false;
                    fe.ResizeType = ResizeTypes.NoResize;
                    fe.SizeGripStyle = SizeGripStyle.Hide;
                }
                _constructor_obj.TopLevel = false;
                _constructor_obj.FormBorderStyle = FormBorderStyle.None;
                foreach (Form form in this.panel1.Controls)
                {
                    form.Dispose();
                }
                this.panel1.Controls.Clear();
                this.panel1.Controls.Add(_constructor_obj);
                _constructor_obj.Show();
            }
        }

        private void Bind(SlideMenuPanelExt menuPanel)
        {
            SlideMenuPanelExt.Node menuItem1 = new SlideMenuPanelExt.Node(null)
            {
                ItemType = SlideMenuPanelExt.NodeTypes.Menu,
                Text = "仓库管理"
            };
            SlideMenuPanelExt.Node menuItem11 = new SlideMenuPanelExt.Node(null) {
                ItemType = SlideMenuPanelExt.NodeTypes.MenuTab, Text = "标签打印", 
                Data = typeof(PrintForm), 
                Image = Properties.Resources.demomenu_grouppanel
            };
            SlideMenuPanelExt.Node menuItem12 = new SlideMenuPanelExt.Node(null)
            {
                ItemType = SlideMenuPanelExt.NodeTypes.MenuTab,
                Text = "任务管理",
                Data = typeof(ChuRuKuForm),
                Image = Properties.Resources.demomenu_grouppanel
            };

            menuItem1.Children.Add(menuItem11);
            menuItem1.Children.Add(menuItem12);
            //menuItem1.Children.Add(menuItem13);
            //menuItem1.Children.Add(menuItem14);
            menuPanel.Nodes.Add(menuItem1);
            menuPanel.RestMenuNodes();
        }


        #region 异步修改界面
        //更改Form1信息的委托
        public delegate void MyInvoke(int type, string str);
        //控制器更改Form信息
        public void ChangeStatus(int type, string str)
        {
            MyInvoke mi = new MyInvoke(UpdateUI);
            this.BeginInvoke(mi, type, str);
        }

        private void UpdateUI(int type, string str)
        {
            if (type == 1)
            {
                
            }

        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainController.Close();
        }
    }
}
