using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fastJSON;
using httpHelper;
using System.Diagnostics;
using ResSync;

namespace ProductCategoryManage
{
    public delegate void deleControlInvoke(object o);
    public partial class frmAddProductCategory : Form
    {
        string server_ip = string.Format("http://{0}:{1}", staticClass.rest_ip, staticClass.rest_port);
        public frmAddProductCategory()
        {
            InitializeComponent();
            this.lblStatus.Text = string.Empty;
        }
        string _filename;
        string file_path = string.Empty;
        private void btnSetImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "PNG图片 (*.png)|*.png";
                DialogResult res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    _filename = dlg.SafeFileName;
                    //_filename = dlg.FileName;
                    this.file_path = dlg.FileName;
                    this.txtImage.Text = _filename;
                }
                else
                    return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtID.Text.Length <= 0)
            {
                return;
            }
            if (this.txtName.Text.Length <= 0)
            {
                return;
            }
            if (this.txtImage.Text.Length <= 0)
            {
                return;
            }
            ProductCategory pc = new ProductCategory(this.txtID.Text, this.txtName.Text, this.txtImage.Text);
            string json = JSON.Instance.ToJSON(pc);
            HttpWebConnect helper = new HttpWebConnect();
            string url = server_ip + "/index.php/Standarder/ProductCategory/add_category";
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_add_category);
            helper.TryPostData(url, json);

            //上传图片
            string uploadfile = this.file_path;
            string url_upload = server_ip + "/index.php/ResSync/resourceSync/upload_file/group/ProductCategory";
            UploadFile.UploadFileEx(uploadfile, url_upload, null, null,
                null, null);
        }
        void helper_RequestCompleted_add_category(object o)
        {
            string strres = (string)o;
            Debug.WriteLine(
                string.Format("helper_RequestCompleted_get_syc_list  ->  = {0}"
                , strres));
            try
            {
                ProductCategory p = (ProductCategory)fastJSON.JSON.Instance.ToObject(strres, typeof(ProductCategory));
                if (p.state == "ok")
                {
                    deleControlInvoke dele = delegate
                    {
                        this.lblStatus.Text = "添加成功";
                    };
                    this.Invoke(dele, o);
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.refresh();
        }
        void refresh()
        {
            deleControlInvoke dele = delegate(object ol)
            {
                this.categoryList.Clear();
                this.listBox1.Items.Clear();

                HttpWebConnect helper = new HttpWebConnect();
                string url = server_ip + "/index.php/Standarder/ProductCategory/get_category_list";
                helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_get_category_list);
                helper.TryPostData(url, string.Empty);
            };
            this.Invoke(dele, new object());
        }
        List<ProductCategory> categoryList = new List<ProductCategory>();
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
                if (resList.Count > 0)
                {
                    for (int i = 0; i < resList.Count; i++)
                    {
                        this.listBox1.Items.Add(resList[i].category_id + "    " + resList[i].category_name);
                        this.categoryList.Add(resList[i]);
                    }
                }
            };
            this.Invoke(dele, olist);
        }
        ProductCategory current_selected_category = null;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listBox1.SelectedIndex;
            if (index >= 0)
            {
                if (categoryList.Count > index)
                {
                    ProductCategory pc = categoryList[index];
                    current_selected_category = pc;
                }
            }
        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            if (current_selected_category != null)
            {
                HttpWebConnect helper = new HttpWebConnect();
                string url = server_ip + "/index.php/Standarder/ProductCategory/delete_category_by_id/id/" + current_selected_category.category_id;
                helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_delete_category_by_id);
                helper.TryPostData(url, string.Empty);

                HttpWebConnect helper2 = new HttpWebConnect();
                string url_delete = server_ip + "/index.php/ResSync/resourceSync/delete_file/group/ProductCategory/name/" + current_selected_category.category_image;
                helper2.RequestCompleted += new deleGetRequestObject(helper2_RequestCompleted);
                helper2.TryPostData(url_delete, string.Empty);
            }
        }

        void helper2_RequestCompleted(object o)
        {
            string s = o as string;
            Debug.WriteLine("helper2_RequestCompleted -> " + s);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
