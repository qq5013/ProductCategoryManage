using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProductCategoryManage
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 添加新类别NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddProductCategory frm = new frmAddProductCategory();
            frm.ShowDialog();
        }

        private void 同步产品类别SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSyncProductCategory frm = new frmSyncProductCategory();
            frm.ShowDialog();
        }

        private void 系统参数CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSysSetting frm = new frmSysSetting();
            frm.ShowDialog();
        }
    }
}
