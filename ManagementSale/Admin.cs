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
            try
            {
                //Format Date
                //Init SQL DB
                CoffeeContextDB context = new CoffeeContextDB();
                List<Account> listAcc = context.Accounts.ToList();
                List<Bill> listInCome = context.Bills.ToList();
                List<Food> listFood = context.Foods.ToList();
                List<FoodCategory> listCategory = context.FoodCategories.ToList();
                List<TableFood> listTable = context.TableFoods.ToList();
                BindGrid_Account(listAcc);
                BindGrid_InCome(listInCome);
                BindGrid_Food(listFood);
                BindGrid_Category(listCategory);
                BindGrid_TableFood(listTable);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông Báo");
            }
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

        private void BindGrid_InCome(List<Bill> listInCome)
        {
            dgvInCome.Rows.Clear();
            foreach (var item in listInCome)
                {
                    int index = dgvInCome.Rows.Add();
                    dgvInCome.Rows[index].Cells[0].Value = item.TableFood.name;
                    dgvInCome.Rows[index].Cells[1].Value = item.DateCheckIn;
                    dgvInCome.Rows[index].Cells[2].Value = item.DateCheckOut;
                    dgvInCome.Rows[index].Cells[3].Value = item.TableFood.status;
                    dgvInCome.Rows[index].Cells[4].Value = item.totalPrice;
            }
        }
        private void BindGrid_Food(List<Food> listFood)
        {
            dgvFood.Rows.Clear();
            foreach (var item in listFood)
            {
                int index = dgvFood.Rows.Add();
                dgvFood.Rows[index].Cells[0].Value = item.id;
                dgvFood.Rows[index].Cells[1].Value = item.name;
                dgvFood.Rows[index].Cells[2].Value = item.FoodCategory.name;
                dgvFood.Rows[index].Cells[3].Value = item.price;
            }
        }
        private void BindGrid_Category(List<FoodCategory> listCategory)
        {
            dgvFoodCategory.Rows.Clear();
            foreach (var item in listCategory)
            {
                int index = dgvFoodCategory.Rows.Add();
                dgvFoodCategory.Rows[index].Cells[0].Value = item.id;
                dgvFoodCategory.Rows[index].Cells[1].Value = item.name;
            }
        }
        private void BindGrid_TableFood(List<TableFood> listTable)
        {
            dgvTable.Rows.Clear();
            foreach (var item in listTable)
            {
                int index = dgvTable.Rows.Add();
                dgvTable.Rows[index].Cells[0].Value = item.id;
                dgvTable.Rows[index].Cells[1].Value = item.name;
                dgvTable.Rows[index].Cells[2].Value = item.status;
            }
        }
        private void panel7_Click(object sender, EventArgs e)
        {

            fHome home = new fHome();
            this.Hide();
            home.Show();
        }
    }
}
