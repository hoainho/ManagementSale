using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSale.Models;
using static ManagementSale.fLogin;

namespace ManagementSale
{
    public partial class fAccountDetails : Form
    {
        private Account temp;
        public fAccountDetails()
        {
            InitializeComponent();
        }
        public fAccountDetails(Account acc)
        {
            InitializeComponent();
            this.temp = acc;
        }
        private void fAccountDetails_Load(object sender, EventArgs e)
        {
            txtUserName.Text = temp.UserName;
            txtAccountName.Text = temp.DisplayName;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using(var _contextDB = new CoffeeContextDB())
            {
                temp.UserName = txtUserName.Text;
                temp.DisplayName = txtAccountName.Text;
                if (txtPasswordNew.Text == txtPasswordConfirm.Text)
                {
                    temp.PassWord = txtPasswordConfirm.Text;
                    MessageBox.Show("Cập Nhật Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mật khẩu chưa trùng khớp, vui lòng kiểm tra lại !", "Thông Báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                _contextDB.SaveChanges();
            } 
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPasswordConfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPasswordNew_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAccountName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
