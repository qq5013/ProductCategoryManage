namespace ProductCategoryManage
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加新类别NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步产品类别SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统参数CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem,
            this.设置SToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加新类别NToolStripMenuItem,
            this.同步产品类别SToolStripMenuItem,
            this.退出QToolStripMenuItem});
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            // 
            // 添加新类别NToolStripMenuItem
            // 
            this.添加新类别NToolStripMenuItem.Name = "添加新类别NToolStripMenuItem";
            this.添加新类别NToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.添加新类别NToolStripMenuItem.Text = "添加新类别(&N)";
            this.添加新类别NToolStripMenuItem.Click += new System.EventHandler(this.添加新类别NToolStripMenuItem_Click);
            // 
            // 同步产品类别SToolStripMenuItem
            // 
            this.同步产品类别SToolStripMenuItem.Name = "同步产品类别SToolStripMenuItem";
            this.同步产品类别SToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.同步产品类别SToolStripMenuItem.Text = "同步产品类别(&S)";
            this.同步产品类别SToolStripMenuItem.Click += new System.EventHandler(this.同步产品类别SToolStripMenuItem_Click);
            // 
            // 退出QToolStripMenuItem
            // 
            this.退出QToolStripMenuItem.Name = "退出QToolStripMenuItem";
            this.退出QToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.退出QToolStripMenuItem.Text = "退出(&Q)";
            this.退出QToolStripMenuItem.Click += new System.EventHandler(this.退出QToolStripMenuItem_Click);
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统参数CToolStripMenuItem});
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.设置SToolStripMenuItem.Text = "设置(&S)";
            // 
            // 系统参数CToolStripMenuItem
            // 
            this.系统参数CToolStripMenuItem.Name = "系统参数CToolStripMenuItem";
            this.系统参数CToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.系统参数CToolStripMenuItem.Text = "系统参数(&C)";
            this.系统参数CToolStripMenuItem.Click += new System.EventHandler(this.系统参数CToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 506);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品种类管理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加新类别NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步产品类别SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出QToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统参数CToolStripMenuItem;
    }
}