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
            CoffeeContextDB _contextDB = new CoffeeContextDB();
            List<Food> listFood = _contextDB.Foods.ToList();
            ShowBill();
            ShowCmbCateFood();
            ShowFood(listFood);
        }
        public void ShowBill()
        {
            using ( var _contextDB = new CoffeeContextDB())
            {
                List<Bill> listBill = _contextDB.Bills.ToList();
                dgvInCome.Rows.Clear();
                foreach (Bill item in listBill)
                {
                    string status = item.status == 1 ? "Đã Thanh Toán" : "Chưa Thanh Toán";
                    int index = dgvInCome.Rows.Add();
                    dgvInCome.Rows[index].Cells[0].Value = item.TableFood.name;
                    dgvInCome.Rows[index].Cells[1].Value = item.DateCheckIn;
                    dgvInCome.Rows[index].Cells[2].Value = item.DateCheckOut;
                    dgvInCome.Rows[index].Cells[3].Value = status;
                    dgvInCome.Rows[index].Cells[4].Value = item.discount;
                    dgvInCome.Rows[index].Cells[5].Value = item.totalPrice / 100 * (100 - item.discount );
                }
            }
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<Bill> listBill = _contextDB.Bills.Where
                    (
                    x => x.DateCheckIn >= dtpStart.Value && 
                    x.DateCheckIn <= dtpEnd.Value && x.status ==1
                    ).ToList();
                dgvInCome.Rows.Clear();
                foreach (Bill item in listBill)
                {
                    string status = item.status == 1 ? "Đã Thanh Toán" : "Chưa Thanh Toán";
                    int index = dgvInCome.Rows.Add();
                    dgvInCome.Rows[index].Cells[0].Value = item.TableFood.name;
                    dgvInCome.Rows[index].Cells[1].Value = item.DateCheckIn;
                    dgvInCome.Rows[index].Cells[2].Value = item.DateCheckOut;
                    dgvInCome.Rows[index].Cells[3].Value = status;
                    dgvInCome.Rows[index].Cells[4].Value = item.discount;
                    dgvInCome.Rows[index].Cells[5].Value = item.totalPrice / 100 * (100 - item.discount);
                }
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if(dtpStart.Value > dtpEnd.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc","Cảnh Báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                MessageBox.Show("Ngày kết thúc phải nhỏ hơn ngày bắt đầu", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui Lòng Kết Nối Với Máy In (Error 404)","Nhắc Nhở",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
        }

        public void ShowCmbCateFood()
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<FoodCategory> ListCate = _contextDB.FoodCategories.ToList();
                cmbFilerCateFood.DataSource = ListCate;
                cmbFilerCateFood.DisplayMember = "name";
                cmbFilerCateFood.ValueMember = "id"; 
            }
        }

        public void ShowFood(List<Food> listFood)
        {
             dgvFood.Rows.Clear();
                foreach (Food item in listFood)
                {
                    int index = dgvFood.Rows.Add();
                    dgvFood.Rows[index].Cells[0].Value = item.id;
                    dgvFood.Rows[index].Cells[1].Value = item.name;
                    dgvFood.Rows[index].Cells[2].Value = item.FoodCategory.name;
                    dgvFood.Rows[index].Cells[3].Value = item.price;
                }
            

        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<Food> listFood = _contextDB.Foods.Where(x => x.name.StartsWith(txtSearchFood.Text)).ToList();
                dgvFood.Rows.Clear();
                foreach (Food item in listFood)
                {
                    int index = dgvFood.Rows.Add();
                    dgvFood.Rows[index].Cells[0].Value = item.id;
                    dgvFood.Rows[index].Cells[1].Value = item.name;
                    dgvFood.Rows[index].Cells[2].Value = item.FoodCategory.name;
                    dgvFood.Rows[index].Cells[3].Value = item.price;
                }
            }
        }

        private void cmbFilerCateFood_TextChanged(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<Food> listFood = _contextDB.Foods.Where(p => p.FoodCategory.name == cmbFilerCateFood.Text).ToList();
                ShowFood(listFood);
            }
        }
    }

}
