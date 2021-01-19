
namespace ManagementSale
{
    partial class fHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHome));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnsHome = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsManager = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsInfomation = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsHome,
            this.mnsManager,
            this.mnsInfomation,
            this.mnsHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1165, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // mnsHome
            // 
            this.mnsHome.Image = ((System.Drawing.Image)(resources.GetObject("mnsHome.Image")));
            this.mnsHome.Name = "mnsHome";
            this.mnsHome.Size = new System.Drawing.Size(84, 24);
            this.mnsHome.Text = "Home";
            this.mnsHome.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // mnsManager
            // 
            this.mnsManager.Image = ((System.Drawing.Image)(resources.GetObject("mnsManager.Image")));
            this.mnsManager.Name = "mnsManager";
            this.mnsManager.Size = new System.Drawing.Size(93, 24);
            this.mnsManager.Text = "Quản Lí";
            this.mnsManager.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // mnsInfomation
            // 
            this.mnsInfomation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.mnsInfomation.Image = global::ManagementSale.Properties.Resources._707705;
            this.mnsInfomation.Name = "mnsInfomation";
            this.mnsInfomation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mnsInfomation.Size = new System.Drawing.Size(177, 24);
            this.mnsInfomation.Text = "Thông Tin Tài Khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông Tin Cá Nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // mnsHelp
            // 
            this.mnsHelp.Image = ((System.Drawing.Image)(resources.GetObject("mnsHelp.Image")));
            this.mnsHelp.Name = "mnsHelp";
            this.mnsHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.mnsHelp.Size = new System.Drawing.Size(88, 24);
            this.mnsHelp.Text = "Hỗ Trợ";
            this.mnsHelp.Click += new System.EventHandler(this.hỗTrợToolStripMenuItem_Click);
            // 
            // fHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1165, 653);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  7 0 7 - COFFEE";
            this.Load += new System.EventHandler(this.fHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnsManager;
        private System.Windows.Forms.ToolStripMenuItem mnsInfomation;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnsHelp;
        private System.Windows.Forms.ToolStripMenuItem mnsHome;
    }
}