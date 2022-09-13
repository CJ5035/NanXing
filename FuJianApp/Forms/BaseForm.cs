using NanXingCangKu.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanXingCangKu.Forms
{
    public partial class BaseForm : Form
    {
        protected MainController mainController;
        protected BaseForm()
        {

        }
        protected BaseForm(MainController mainController)
        {
            InitializeComponent();
            this.mainController= mainController;
        }
    }
}
