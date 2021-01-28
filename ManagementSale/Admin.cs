using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSale.Models;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
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
            OpenFileDialog uploadFileSteam = new OpenFileDialog();

            uploadFileSteam.InitialDirectory = "D:\\";
            uploadFileSteam.Filter = "Excel|*.xls;*.xlsx";

            if (uploadFileSteam.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dgvInCome, Directory.GetCurrentDirectory(), uploadFileSteam.FileName, "Báo Cáo Bán Hàng");
            }
            
        }

        private void ExportToExcel(DataGridView dgv, string LinkSave,string fileName,string NameReport)
        {
            //Tạo các đối tượng Excel
            app obj = new app();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            obj.Visible = true;

            obj.DisplayAlerts = false;

            obj.Application.SheetsInNewWorkbook = 1;

            oBooks = obj.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(obj.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = fileName;

            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "C1");

            head.MergeCells = true;

            head.Value2 = NameReport;

            head.Font.Bold = true;

            head.Font.Name = "Tahoma";

            head.Font.Size = "18";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Số Bàn";

            cl1.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Thời Gian Vào";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Thời Gian Ra";

            cl3.ColumnWidth = 50.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = " Trạng Thái";

            cl4.ColumnWidth = 50.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Giảm Giá";

            cl5.ColumnWidth = 50.0;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = " Tổng Cộng";

            cl6.ColumnWidth = 50.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "G3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            
            obj.Application.Workbooks.Add(Type.Missing);
            // Tạo phần đầu nếu muốn

            for(int i = 1; i < dgv.Rows.Count + 1; i++)
            {
                obj.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if(dgv.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(LinkSave + fileName + ".xlsx");
            obj.ActiveWorkbook.Saved = true;

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
                item.name = txtTableName.Text;
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
        private void btnOutput_Click_1(object sender, EventArgs e)
        {
            fReport fReport = new fReport();
            fReport.Show();
        }
    }

}
