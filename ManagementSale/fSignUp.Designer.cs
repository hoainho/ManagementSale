
namespace ManagementSale
{
    partial class fSignUp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSignUp));
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.NotificationError = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPasswordConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordConfirm.Location = new System.Drawing.Point(479, 453);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.Size = new System.Drawing.Size(246, 22);
            this.txtPasswordConfirm.TabIndex = 5;
            this.txtPasswordConfirm.UseSystemPasswordChar = true;
            this.txtPasswordConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisplayName_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(479, 404);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(246, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisplayName_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(479, 307);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(246, 22);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisplayName_Validating);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayName.Location = new System.Drawing.Point(479, 261);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(246, 22);
            this.txtDisplayName.TabIndex = 1;
            this.txtDisplayName.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisplayName_Validating);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(301, 453);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nhập Lại Mật Khẩu :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(332, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Loại Tài Khoản :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(373, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mật Khẩu :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên Hiển Thị :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(328, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên Đăng Nhập :";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(496, 167);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 45);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "ĐĂNG KÝ";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(614, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 58);
            this.button1.TabIndex = 6;
            this.button1.Text = "ĐĂNG KÝ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBack.Location = new System.Drawing.Point(452, 536);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(87, 58);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "TRỞ LẠI";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // NotificationError
            // 
            this.NotificationError.ContainerControl = this;
            // 
            // txtAccountType
            // 
            this.txtAccountType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAccountType.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtAccountType.Enabled = false;
            this.txtAccountType.Location = new System.Drawing.Point(479, 357);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(246, 22);
            this.txtAccountType.TabIndex = 2;
            this.txtAccountType.Text = "User";
            this.txtAccountType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAccountType.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisplayName_Validating);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel2.BackgroundImage")));
            this.flowLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(434, 137);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(66, 75);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel1.BackgroundImage")));
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(452, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(221, 142);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // fSignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1165, 653);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAccountType);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fSignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Kí";
            this.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisplayName_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.NotificationError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ErrorProvider NotificationError;
        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}