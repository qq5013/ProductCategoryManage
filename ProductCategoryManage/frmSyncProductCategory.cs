using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using httpHelper;
using System.Diagnostics;
using ResSync;

namespace ProductCategoryManage
{
    public partial class frmSyncProductCategory : Form
    {
        List<ProductCategory> myCategoryList = new List<ProductCategory>();
        string server_ip = string.Format("http://{0}:{1}", staticClass.rest_ip, staticClass.rest_port);
        //string server_ip = "http://localhost:9002";
        public frmSyncProductCategory()
        {
            InitializeComponent();

            this.dgvProductInfo.CellClick += new DataGridViewCellEventHandler(dgvProductInfo_CellClick);
        }
        string selected_category_id = string.Empty;
        string selected_image_path = string.Empty;
        void dgvProductInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable tb = (DataTable)dgvProductInfo.DataSource;
            if (e.RowIndex >= 0)
            {
                dgvProductInfo.Rows[e.RowIndex].Selected = true;
                selected_image_path = tb.Rows[e.RowIndex][2].ToString();
                selected_category_id = tb.Rows[e.RowIndex][0].ToString();

                this.pictureBox1.ImageLocation = "./res/" + selected_image_path;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.refresh();
        }
        void refresh()
        {
            HttpWebConnect helper = new HttpWebConnect();
            string url = server_ip + "/index.php/Standarder/ProductCategory/get_category_list";
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_get_category_list);
            helper.TryPostData(url, string.Empty);
        }
        void helper_RequestCompleted_get_category_list(object o)
        {
            string strres = (string)o;
            Debug.WriteLine(
                string.Format("helper_RequestCompleted_get_syc_list  ->  = {0}"
                , strres));
            object olist = fastJSON.JSON.Instance.ToObjectList(strres, typeof(List<ProductCategory>), typeof(ProductCategory));
            deleControlInvoke dele = delegate(object ol)
            {
                List<ProductCategory> resList = (List<ProductCategory>)ol;
                myCategoryList.Clear();
                if (resList.Count > 0)
                {
                    myCategoryList.AddRange(resList);
                    for (int i = 0; i < resList.Count; i++)
                    {
                        DataTable dt = null;
                        if (this.dgvProductInfo.DataSource == null)
                        {
                            dt = new DataTable();
                            dt.Columns.Add("产品编号", typeof(string));
                            dt.Columns.Add("产品名称", typeof(string));
                            dt.Columns.Add("产品图片", typeof(string));
                        }
                        else
                        {
                            dt = (DataTable)dgvProductInfo.DataSource;
                        }
                        dt.Rows.Clear();
                        foreach (ProductCategory p in resList)
                        {
                            dt.Rows.Add(new object[]{
                                p.category_id,
                                p.category_name,
                                p.category_image
                    });
                        }
                        dgvProductInfo.DataSource = dt;

                        this.resize_datagrid();
                        //this.listBox1.Items.Add("查询到产品种类：ID： "+resList[i].category_id + "  名称：" + resList[i].category_name+"  图片："+resList[i].category_image);
                    }
                }
            };
            this.Invoke(dele, olist);
            ResSyncer rs = new ResSyncer();
            rs.start_sync("ProductCategory");
        }

        void resize_datagrid()
        {
            this.dgvProductInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvProductInfo.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvProductInfo.Columns;
            columns[0].Width = 100;
            for (int i = 0; i < columns.Count; i++)
            {
                columnsW += columns[i].Width;
            }
            if (columnsW + headerW < this.dgvProductInfo.Width)
            {
                int leftTotalWidht = this.dgvProductInfo.Width - columnsW - headerW;
                int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                for (int i = 1; i < columns.Count; i++)
                {
                    columns[i].Width += eachColumnAddedWidth;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.selected_category_id != string.Empty)
            {
                HttpWebConnect helper = new HttpWebConnect();
                string url = server_ip + "/index.php/Standarder/ProductCategory/delete_category_by_id/id/" + selected_category_id;
                helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_delete_category_by_id);
                helper.TryPostData(url, string.Empty);

                HttpWebConnect helper2 = new HttpWebConnect();
                string url_delete = server_ip + "/index.php/ResSync/resourceSync/delete_file/group/ProductCategory/name/" + selected_image_path;
                //helper2.RequestCompleted += new deleGetRequestObject(helper2_RequestCompleted);
                helper2.TryPostData(url_delete, string.Empty);
            }
        }
        void helper_RequestCompleted_delete_category_by_id(object o)
        {
            string strres = (string)o;
            if (strres == "ok")
            {
                MessageBox.Show("删除成功！", "提示");
                this.refresh();
            }
        }
    }
}
