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
namespace ManagementSale
{
    public partial class fSignUp : Form
    {
        public fSignUp()
        {
            InitializeComponent();
        }
        private void txtDisplayName_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (temp.Text == "")
            {
                NotificationError.SetError(temp, "Vui lòng không để trống tên !");
            }
            else
            {
                NotificationError.SetError(temp, "");

            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDisplayName.Text == "" || txtUserName.Text == "" || txtPassword.Text == "" || txtPasswordConfirm.Text == "")
            {
                MessageBox.Show("Vui lòng không bỏ trống các trường !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var _dbContext = new CoffeeContextDB())
                {
                    Account acc = new Account();
                    acc.DisplayName = txtDisplayName.Text;
                    acc.UserName = txtUserName.Text;
                    acc.PassWord = txtPassword.Text;
                    acc.Type = 1;
                    _dbContext.Accounts.Add(acc);
                    _dbContext.SaveChanges();
                }
                this.Close();
                MessageBox.Show("Chúc Mừng Bạn Gia Nhập 707 Team !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDisplayName.Text = "";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtPasswordConfirm.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fLogin flogin = new fLogin();
            this.Close();
            flogin.Show();
        }
    }
}
