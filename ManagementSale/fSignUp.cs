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
            CoffeeContextDB context = new CoffeeContextDB();
            List<Account> listAcc = context.Accounts.ToList();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void FillTypeAccount( List<Account> listAcc )
        {
            this.cmbAccountType.DataSource = listAcc;
            this.cmbAccountType.DisplayMember = "Type";
            this.cmbAccountType.ValueMember = "Type";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDisplayName.Text == "")
            {
                MessageBox.Show("Vui lòng không bỏ trống !","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Account acc = new Account();

            }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            DialogResult msgClose = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình ?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(msgClose == DialogResult.Yes)
            {
                Application.Exit();
            }
            
            
        }
    }
}
