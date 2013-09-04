using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using nsConfigDB;

namespace ProductCategoryManage
{
    public partial class frmSysSetting : Form
    {
        public frmSysSetting()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmSysSetting_Load);
        }

        void frmSysSetting_Load(object sender, EventArgs e)
        {
            this.txtIP.Text = staticClass.rest_ip;
            this.txtPort.Text = staticClass.rest_port;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool checkValidation()
        {
            bool bR = true;
            int tcpPort = 9002;
            try
            {
                tcpPort = int.Parse(this.txtPort.Text);

            }
            catch 
            {
                MessageBox.Show("端口设置不正确，请重新设置！");
                return false;
            }
            string ip = string.Empty;
            try
            {
                ip = txtIP.Text;
                IPAddress address = IPAddress.Parse(ip);
            }
            catch 
            {
                MessageBox.Show("IP设置不正确，请重新设置！");
                return false;
            }
            return bR;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.checkValidation())
            {
                //string portName = this.cmbPortName.Text;
                string ip = this.txtIP.Text;
                string tcpPort = this.txtPort.Text;
                //ConfigDB.saveConfig("comportName", portName);
                ConfigDB.saveConfig("ip", ip);
                ConfigDB.saveConfig("tcp_port", tcpPort);

                staticClass.rest_ip = ip;
                //sysConfig.comportName = portName;
                staticClass.rest_port = tcpPort;

                this.Close();
            }
        }
    }
}
