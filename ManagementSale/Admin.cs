using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSale.Models;
namespace ManagementSale
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

        }
        private void Admin_Load(object sender, EventArgs e)
        {
                //Format Date
                //Init SQL DB
                CoffeeContextDB context = new CoffeeContextDB();
                List<Account> listAcc = context.Accounts.ToList();
                BindGrid_Account(listAcc);
                BindGrid_InCome();
            
        }
        private void BindGrid_Account(List<Account> listAcc)
        {
            dgvAccount.Rows.Clear();
            foreach (var item in listAcc)
            {
                int index = dgvAccount.Rows.Add();
                dgvAccount.Rows[index].Cells[0].Value = item.DisplayName;
                dgvAccount.Rows[index].Cells[1].Value = item.UserName;
                dgvAccount.Rows[index].Cells[2].Value = item.PassWord;
                dgvAccount.Rows[index].Cells[3].Value = item.Type;
            }
        }

        private void BindGrid_InCome()
        {
            using (CoffeeContextDB _contextDB = new CoffeeContextDB())
            {
                List<BillInfo> listBill = _contextDB.BillInfoes.ToList();
                dgvInCome.Rows.Clear();
                foreach (var item in listBill)
                {
                    int index = dgvInCome.Rows.Add();
                    dgvInCome.Rows[index].Cells[0].Value = item.Bill.TableFood.name;
                    dgvInCome.Rows[index].Cells[1].Value = item.Bill.DateCheckIn;
                    dgvInCome.Rows[index].Cells[2].Value = item.Bill.DateCheckOut;
                    dgvInCome.Rows[index].Cells[3].Value = item.Bill.discount;
                    dgvInCome.Rows[index].Cells[4].Value = item.count * item.Food.price;
                }
            }

        }
    }
}
