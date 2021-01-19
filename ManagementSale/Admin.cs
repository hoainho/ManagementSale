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
        private int idFood = 0;
        private int idCate = 0;
        private int idTable = 0;
        private string acc = "";
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            CoffeeContextDB _contextDB = new CoffeeContextDB();
            List<Food> listFood = _contextDB.Foods.ToList();
            List<FoodCategory> listCate = _contextDB.FoodCategories.ToList();
            List<TableFood> listTable = _contextDB.TableFoods.ToList();
            List<Account> listAccount = _contextDB.Accounts.ToList();
            List<AccountType> listAccountType = _contextDB.AccountTypes.ToList();
            ShowBill();
            ShowFood(listFood);
            ShowCategoryFood(listCate);
            ShowTable(listTable);
            ShowAccount(listAccount);
            ShowCmbCateFood();
            ShowCmbAccountType(listAccountType);
            ShowAddCmbCateFood();
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
        public void ShowAddCmbCateFood()
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<FoodCategory> ListCate = _contextDB.FoodCategories.ToList();
                cmbFoodCate.DataSource = ListCate;
                cmbFoodCate.DisplayMember = "name";
                cmbFoodCate.ValueMember = "id";
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

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            using(var _contextDB = new CoffeeContextDB()) 
            {
                Food item = new Food();
                item.name = txtFoodName.Text;
                item.idCategory = int.Parse(cmbFoodCate.SelectedValue.ToString());
                item.price = int.Parse(txtFoodPrice.Text);
                _contextDB.Foods.Add(item);
                _contextDB.SaveChanges();
                ShowFood(_contextDB.Foods.ToList());
            }
            
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            
            using (var _contextDB = new CoffeeContextDB())
            {
                Food dbFood = _contextDB.Foods.FirstOrDefault(x => x.id == this.idFood);
                if (dbFood != null) 
                {
                    dbFood.name = txtFoodName.Text;
                    dbFood.idCategory = int.Parse(cmbFoodCate.SelectedValue.ToString());
                    dbFood.price = int.Parse(txtFoodPrice.Text);
                }
                _contextDB.SaveChanges();
                ShowFood(_contextDB.Foods.ToList());
            }
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0 )
            {
                this.idCate = int.Parse(dgvFood.Rows[index].Cells[0].Value.ToString());
                txtFoodName.Text = dgvFood.Rows[index].Cells[1].Value.ToString();
                cmbFoodCate.Text = dgvFood.Rows[index].Cells[2].Value.ToString();
                txtFoodPrice.Text = dgvFood.Rows[index].Cells[3].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                Food dbFood = _contextDB.Foods.FirstOrDefault(x => x.id == this.idFood);
                if (dbFood != null)
                {
                    _contextDB.Foods.Remove(dbFood);
                }
                _contextDB.SaveChanges();
                ShowFood(_contextDB.Foods.ToList());
            }
        }
        //------------------------------------Danh Mục------------------------------------//
        public void ShowCategoryFood(List<FoodCategory> listCategory)
        {
            dgvFoodCategory.Rows.Clear();
            foreach (FoodCategory item in listCategory)
            {
                int index = dgvFoodCategory.Rows.Add();
                dgvFoodCategory.Rows[index].Cells[0].Value = item.id;
                dgvFoodCategory.Rows[index].Cells[1].Value = item.name;
            }


        }
        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<FoodCategory> listFood = _contextDB.FoodCategories.Where(x => x.name.StartsWith(txtSearchCategory.Text)).ToList();
                dgvFood.Rows.Clear();
                foreach (FoodCategory item in listFood)
                {
                    int index = dgvFood.Rows.Add();
                    dgvFoodCategory.Rows[index].Cells[0].Value = item.id;
                    dgvFoodCategory.Rows[index].Cells[1].Value = item.name;
                }
            }
        }

        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<FoodCategory> listFood = _contextDB.FoodCategories.Where(p => p.name == txtSearchCategory.Text).ToList();
                ShowCategoryFood(listFood);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                FoodCategory item = new FoodCategory();
                item.name = txtNameCategory.Text;
                item.id = int.Parse(txtIdCategory.Text);
                _contextDB.FoodCategories.Add(item);
                _contextDB.SaveChanges();
                ShowCategoryFood(_contextDB.FoodCategories.ToList());
            }

        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {

            using (var _contextDB = new CoffeeContextDB())
            {
                FoodCategory dbCategory = _contextDB.FoodCategories.FirstOrDefault(x => x.id == this.idCate);
                if (dbCategory != null)
                {
                    dbCategory.name = txtNameCategory.Text;
                    dbCategory.id = int.Parse(txtIdCategory.Text);
                }
                _contextDB.SaveChanges();
                ShowCategoryFood(_contextDB.FoodCategories.ToList());
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                this.idCate = int.Parse(dgvFoodCategory.Rows[index].Cells[0].Value.ToString());
                txtIdCategory.Text = dgvFoodCategory.Rows[index].Cells[0].Value.ToString();
                txtNameCategory.Text = dgvFoodCategory.Rows[index].Cells[1].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                FoodCategory dbCate = _contextDB.FoodCategories.FirstOrDefault(x => x.id == this.idCate);
                if (dbCate != null)
                {
                    _contextDB.FoodCategories.Remove(dbCate);
                }
                _contextDB.SaveChanges();
                ShowCategoryFood(_contextDB.FoodCategories.ToList());
            }
        }
        //------------------------------------Bàn Ăn------------------------------------//
        public void ShowTable(List<TableFood> listTable)
        {
            dgvTable.Rows.Clear();
            foreach (TableFood item in listTable)
            {
                int index = dgvTable.Rows.Add();
                dgvTable.Rows[index].Cells[0].Value = item.id;
                dgvTable.Rows[index].Cells[1].Value = item.name;
                dgvTable.Rows[index].Cells[2].Value = item.status;
            }


        }
        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<TableFood> listTable = _contextDB.TableFoods.Where(x => x.name.StartsWith(txtTableName.Text)).ToList();
                dgvTable.Rows.Clear();
                foreach (TableFood item in listTable)
                {
                    int index = dgvTable.Rows.Add();
                    dgvTable.Rows[index].Cells[0].Value = item.id;
                    dgvTable.Rows[index].Cells[1].Value = item.name;
                }
            }
        }

        private void txtSearchTable_TextChanged(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<TableFood> listTable = _contextDB.TableFoods.Where(p => p.name == txtTableName.Text).ToList();
                ShowTable(listTable);
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                TableFood item = new TableFood();
                item.id = int.Parse(txtTableFood.Text);
                item.name = txtTableFood.Text;
                item.status = txtTableStatus.Text;
                _contextDB.TableFoods.Add(item);
                _contextDB.SaveChanges();
                ShowTable(_contextDB.TableFoods.ToList());
            }

        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {

            using (var _contextDB = new CoffeeContextDB())
            {
                TableFood dbTable = _contextDB.TableFoods.FirstOrDefault(x => x.id == this.idTable);
                if(MessageBox.Show("Không thể đổi trạng thái và ID, Bạn chỉ có thể đổi tên bàn "+ dbTable.name+" thành " + txtTableName.Text + "\n Bạn có đồng ý đổi không ?", "",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (dbTable != null)
                    {
                        dbTable.name = txtTableName.Text;
                    }
                }
                else { return; }
                _contextDB.SaveChanges();
                ShowTable(_contextDB.TableFoods.ToList());
            }
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                this.idTable = int.Parse(dgvTable.Rows[index].Cells[0].Value.ToString());
                txtIDTable.Text = dgvTable.Rows[index].Cells[0].Value.ToString();
                txtTableName.Text = dgvTable.Rows[index].Cells[1].Value.ToString();
                txtTableStatus.Text = dgvTable.Rows[index].Cells[2].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                TableFood dbTable = _contextDB.TableFoods.FirstOrDefault(x => x.id == this.idTable);
                if (dbTable != null)
                {
                    _contextDB.TableFoods.Remove(dbTable);
                }
                _contextDB.SaveChanges();
                ShowTable(_contextDB.TableFoods.ToList());
            }
        }

        //------------------------------------Tài Khoản------------------------------------//
        public void ShowAccount(List<Account> listAccount)
        {
            dgvAccount.Rows.Clear();
            foreach (Account item in listAccount)
            {
                int index = dgvAccount.Rows.Add();
                dgvAccount.Rows[index].Cells[0].Value = item.UserName;
                dgvAccount.Rows[index].Cells[1].Value = item.DisplayName;
                dgvAccount.Rows[index].Cells[2].Value = item.PassWord;
                dgvAccount.Rows[index].Cells[3].Value = item.AccountType.TypeName;
            }
        }
        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<Account> listAccount = _contextDB.Accounts.Where(x => x.UserName.StartsWith(txtUserName.Text)).ToList();
                dgvAccount.Rows.Clear();
                foreach (Account item in listAccount)
                {
                    int index = dgvAccount.Rows.Add();
                    dgvAccount.Rows[index].Cells[0].Value = item.UserName;
                    dgvAccount.Rows[index].Cells[1].Value = item.DisplayName;
                    dgvAccount.Rows[index].Cells[2].Value = item.PassWord;
                    dgvAccount.Rows[index].Cells[3].Value = item.Type;
                }
            }
        }

        private void txtSearchAccount_TextChanged(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<Account> listAccount = _contextDB.Accounts.Where(p => p.UserName == txtUserName.Text).ToList();
                ShowAccount(listAccount);
            }
        }
        public void ShowCmbAccountType(List<AccountType> listAccount)
        {
                cmbAccountType.DataSource = listAccount;
                cmbAccountType.DisplayMember = "TypeName";
                cmbAccountType.ValueMember = "TypeId";
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<Account> listAccount = _contextDB.Accounts.ToList();
                foreach(Account item in listAccount)
                {
                    if(item.UserName != this.acc)
                    {
                        Account acc = new Account();
                        acc.UserName = txtUserName.Text;
                        acc.DisplayName = txtDisplayName.Text;
                        acc.PassWord = txtPassword.Text;
                        _contextDB.Accounts.Add(acc);
                        _contextDB.SaveChanges();
                        ShowAccount(_contextDB.Accounts.ToList());
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại, vui lòng nhập lại !","Yêu Cầu",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {

            using (var _contextDB = new CoffeeContextDB())
            {
                Account dbAccount = _contextDB.Accounts.FirstOrDefault(x => x.UserName == this.acc);
                if (MessageBox.Show("Bạn chắc chắn muốn đổi thông tin trên ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dbAccount != null)
                    {
                        dbAccount.DisplayName = txtDisplayName.Text;
                        dbAccount.PassWord = txtPassword.Text;
                        dbAccount.Type = int.Parse(cmbAccountType.SelectedValue.ToString());
                    }
                }
                else { return; }
                _contextDB.SaveChanges();
                ShowAccount(_contextDB.Accounts.ToList());
            }
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                this.acc = dgvAccount.Rows[index].Cells[0].Value.ToString();
                txtUserName.Text = dgvAccount.Rows[index].Cells[0].Value.ToString();
                txtDisplayName.Text = dgvAccount.Rows[index].Cells[1].Value.ToString();
                txtPassword.Text = dgvAccount.Rows[index].Cells[2].Value.ToString();
                cmbAccountType.Text = dgvAccount.Rows[index].Cells[3].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                Account dbAccount = _contextDB.Accounts.FirstOrDefault(x => x.UserName == this.acc);
                if (dbAccount != null)
                {
                    _contextDB.Accounts.Remove(dbAccount);
                }
                _contextDB.SaveChanges();
                ShowAccount(_contextDB.Accounts.ToList());
            }
        }

    }

}
