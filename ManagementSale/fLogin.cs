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
    public partial class fLogin : Form
    {
        public delegate void AccountAccuracy(Account acc);
        public event AccountAccuracy accountAccuracy;
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            fSignUp f = new fSignUp();
            fHome home = new fHome();
            
            home.Hide();
            f.ShowDialog();
            
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Tài Khoản hoặc mật khẩu chưa chính xác, Vui lòng nhập lại !", "Thông Báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else
            {
                using( var _dbContext = new CoffeeContextDB())
                {
                    Account checkUser = _dbContext.Accounts.Where(p => p.UserName == UserName ).FirstOrDefault();
                    Account checkPassword = _dbContext.Accounts.Where(p =>  p.PassWord == Password).FirstOrDefault();


                    if (checkUser == null && checkPassword == null)
                    {
                        MessageBox.Show("Tài Khoản Không Tồn Tài !", "Thông Báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else if(checkUser == null )
                    {
                        MessageBox.Show("Sai Tài Khoản !", "Thông Báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else if (checkPassword == null)
                    {
                        MessageBox.Show("Sai Mật Khẩu !", "Thông Báo",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Hide();
                        if (accountAccuracy != null)
                        {
                            accountAccuracy(checkUser);
                        }
                    }
                }
                
            }
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult msgClose = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgClose == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(sender, e);
            }
        }

        
    }
}
