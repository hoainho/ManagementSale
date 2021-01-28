
namespace ManagementSale
{
    partial class fTable
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTableName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTable = new System.Windows.Forms.Label();
            this.dgvTableDetails = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnMergeTable = new System.Windows.Forms.Button();
            this.btnSwitchFood = new System.Windows.Forms.Button();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.cmbTableChange = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new ePOSOne.btnProduct.Button_WOC();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFood = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableDetails)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.Controls.Add(this.lblTableName);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.txtTable);
            this.panel4.Controls.Add(this.dgvTableDetails);
            this.panel4.Location = new System.Drawing.Point(328, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(475, 171);
            this.panel4.TabIndex = 8;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(194, 19);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(0, 17);
            this.lblTableName.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ManagementSale.Properties.Resources.cafe_eshop_market_shop_store_icon_1320166001182566406;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(154, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(26, 26);
            this.panel1.TabIndex = 2;
            // 
            // txtTable
            // 
            this.txtTable.AutoSize = true;
            this.txtTable.Location = new System.Drawing.Point(212, 15);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(0, 17);
            this.txtTable.TabIndex = 1;
            // 
            // dgvTableDetails
            // 
            this.dgvTableDetails.AllowUserToAddRows = false;
            this.dgvTableDetails.AllowUserToDeleteRows = false;
            this.dgvTableDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTableDetails.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTableDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colFoodName,
            this.colQuantity,
            this.colPrice});
            this.dgvTableDetails.Location = new System.Drawing.Point(6, 45);
            this.dgvTableDetails.Name = "dgvTableDetails";
            this.dgvTableDetails.ReadOnly = true;
            this.dgvTableDetails.RowHeadersWidth = 51;
            this.dgvTableDetails.RowTemplate.Height = 24;
            this.dgvTableDetails.Size = new System.Drawing.Size(466, 123);
            this.dgvTableDetails.TabIndex = 0;
            this.dgvTableDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableDetails_CellClick);
            // 
            // colNo
            // 
            this.colNo.FillWeight = 167.1221F;
            this.colNo.HeaderText = "Tên";
            this.colNo.MinimumWidth = 6;
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            // 
            // colFoodName
            // 
            this.colFoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFoodName.FillWeight = 57.74831F;
            this.colFoodName.HeaderText = "SL";
            this.colFoodName.MinimumWidth = 6;
            this.colFoodName.Name = "colFoodName";
            this.colFoodName.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.FillWeight = 59.11825F;
            this.colQuantity.HeaderText = "Giá";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.FillWeight = 118.3286F;
            this.colPrice.HeaderText = "Tổng cộng";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.linkLabel2);
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.btnMergeTable);
            this.panel3.Controls.Add(this.btnSwitchFood);
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.nmDiscount);
            this.panel3.Controls.Add(this.cmbTableChange);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.btnCheckOut);
            this.panel3.Controls.Add(this.btnSwitchTable);
            this.panel3.Location = new System.Drawing.Point(809, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(353, 167);
            this.panel3.TabIndex = 6;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(227, 21);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(13, 131);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "_______________";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.linkLabel1.Location = new System.Drawing.Point(106, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(13, 131);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "_______________";
            // 
            // btnMergeTable
            // 
            this.btnMergeTable.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMergeTable.Location = new System.Drawing.Point(3, 19);
            this.btnMergeTable.Name = "btnMergeTable";
            this.btnMergeTable.Size = new System.Drawing.Size(97, 58);
            this.btnMergeTable.TabIndex = 6;
            this.btnMergeTable.Text = "Gộp Bàn";
            this.btnMergeTable.UseVisualStyleBackColor = false;
            this.btnMergeTable.Click += new System.EventHandler(this.btnMergeTable_Click);
            // 
            // btnSwitchFood
            // 
            this.btnSwitchFood.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSwitchFood.Location = new System.Drawing.Point(246, 19);
            this.btnSwitchFood.Name = "btnSwitchFood";
            this.btnSwitchFood.Size = new System.Drawing.Size(104, 58);
            this.btnSwitchFood.TabIndex = 6;
            this.btnSwitchFood.Text = "Chuyển Món";
            this.btnSwitchFood.UseVisualStyleBackColor = false;
            this.btnSwitchFood.Click += new System.EventHandler(this.btnSwitchFood_Click);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.Location = new System.Drawing.Point(3, 128);
            this.txtTotalPrice.Multiline = true;
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(97, 22);
            this.txtTotalPrice.TabIndex = 10;
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 9;
            // 
            // nmDiscount
            // 
            this.nmDiscount.Location = new System.Drawing.Point(124, 128);
            this.nmDiscount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmDiscount.Name = "nmDiscount";
            this.nmDiscount.Size = new System.Drawing.Size(100, 22);
            this.nmDiscount.TabIndex = 7;
            this.nmDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbTableChange
            // 
            this.cmbTableChange.FormattingEnabled = true;
            this.cmbTableChange.Location = new System.Drawing.Point(124, 53);
            this.cmbTableChange.Name = "cmbTableChange";
            this.cmbTableChange.Size = new System.Drawing.Size(100, 24);
            this.cmbTableChange.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Location = new System.Drawing.Point(3, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 28);
            this.button3.TabIndex = 6;
            this.button3.Text = "Tổng Tiền";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(124, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = " Giảm Giá";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCheckOut.Location = new System.Drawing.Point(246, 94);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(104, 58);
            this.btnCheckOut.TabIndex = 6;
            this.btnCheckOut.Text = "Thanh Toán";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSwitchTable.Location = new System.Drawing.Point(122, 19);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(100, 28);
            this.btnSwitchTable.TabIndex = 6;
            this.btnSwitchTable.Text = "Chuyển Bàn";
            this.btnSwitchTable.UseVisualStyleBackColor = false;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.nmFoodCount);
            this.panel2.Controls.Add(this.btnAddFood);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbFood);
            this.panel2.Controls.Add(this.cmbCategory);
            this.panel2.Controls.Add(this.lblCategory);
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 171);
            this.panel2.TabIndex = 7;
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(104, 82);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(193, 27);
            this.nmFoodCount.TabIndex = 7;
            this.nmFoodCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFood.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddFood.ButtonColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddFood.FlatAppearance.BorderSize = 0;
            this.btnAddFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFood.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddFood.Location = new System.Drawing.Point(57, 112);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnAddFood.OnHoverButtonColor = System.Drawing.Color.SteelBlue;
            this.btnAddFood.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddFood.Size = new System.Drawing.Size(199, 55);
            this.btnAddFood.TabIndex = 0;
            this.btnAddFood.Text = "Thêm Món";
            this.btnAddFood.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Số Lượng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Món Ăn";
            // 
            // cmbFood
            // 
            this.cmbFood.FormattingEnabled = true;
            this.cmbFood.Location = new System.Drawing.Point(104, 52);
            this.cmbFood.Name = "cmbFood";
            this.cmbFood.Size = new System.Drawing.Size(193, 27);
            this.cmbFood.TabIndex = 0;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(104, 22);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(193, 27);
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            this.cmbCategory.TextChanged += new System.EventHandler(this.cmbCategory_TextChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(27, 25);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(43, 19);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Loại";
            // 
            // flpTable
            // 
            this.flpTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flpTable.AutoScroll = true;
            this.flpTable.BackColor = System.Drawing.Color.Transparent;
            this.flpTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpTable.Location = new System.Drawing.Point(0, 190);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(1162, 461);
            this.flpTable.TabIndex = 9;
            // 
            // fTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 653);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "fTable";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.Text = "Sơ Đồ Quán";
            this.Load += new System.EventHandler(this.fTable_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableDetails)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTableChange;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.ComboBox cmbFood;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.DataGridView dgvTableDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtTable;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnMergeTable;
        private System.Windows.Forms.Button btnSwitchFood;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private ePOSOne.btnProduct.Button_WOC btnAddFood;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    }
}