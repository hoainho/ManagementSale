using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSale.DAO;
using ManagementSale.Models;
using static ManagementSale.fLogin;

namespace ManagementSale
{
    public partial class fTable : Form
    {
        private Button SelectedTable;
        public AccountAccuracy acc;
        public object DataProvider { get; private set; }

        public fTable()
        {
            InitializeComponent();
        }
        public fTable(AccountAccuracy account)
        {
            InitializeComponent();
            this.acc = account;
        }
        private void fTable_Load(object sender, EventArgs e)
        {
            CoffeeContextDB context = new CoffeeContextDB();
            List<FoodCategory> listCategory = context.FoodCategories.ToList();
            List<Food> listFood = context.Foods.ToList();
            List<TableFood> listTable = context.TableFoods.ToList();
            InitTable();
            cmbType(listCategory);
            cmbFoody(listFood);
            cmbTableChanged(listTable);
        }

        private void cmbType(List<FoodCategory> listCategory)
        {
            cmbCategory.DataSource = listCategory;
            cmbCategory.DisplayMember = "name";
            cmbCategory.ValueMember = "id";
        }
        private void cmbFoody(List<Food> listFood)
        {
            cmbFood.DataSource = listFood;
            cmbFood.DisplayMember = "name";
            cmbFood.ValueMember = "id";
        }
        private void cmbTableChanged(List<TableFood> listTable)
        {
            cmbTableChange.DataSource = listTable;
            cmbTableChange.DisplayMember = "name";
            cmbTableChange.ValueMember = "id";
        }
        
        private void InitTable()
        {
            flpTable.Controls.Clear();
            List<TableFood> listTable = TableDAO.Instance.LoadTable();
            foreach (TableFood item in listTable)
            {
                //Init Button = Bàn
                Button btnTable = new Button() {  Width = 100, Height = 100 };
                btnTable.Name = "btnTable" + item.id;
                btnTable.TabIndex = 0;
                btnTable.Text = item.name + Environment.NewLine + item.status;
                btnTable.UseVisualStyleBackColor = false;
                btnTable.Click += BtnTable_Click;
                btnTable.Tag = item;
                switch (item.status)
                {
                    case "Trống":
                        btnTable.BackColor = Color.White;
                        break;
                    default:
                        btnTable.BackColor = Color.DarkGoldenrod;
                        break;
                }

                flpTable.Controls.Add(btnTable);
            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            int btnTable = (btn.Tag as TableFood).id;
            dgvTableDetails.Tag = btn.Tag;
            SelectionTable(btn);
            bindDgvBill(btnTable);
        }
        private void SelectionTable(Button btnTable)
        {
            int btnId = (btnTable.Tag as TableFood).id;
            lblTableName.Text = "Bàn Số " + btnId; //Hien thi so ban
            
            if (btnTable.BackColor != Color.DarkGoldenrod)
            {
                if(this.SelectedTable != null)
                {
                    this.SelectedTable.BackColor = Color.White;
                }
                _ = btnTable.BackColor == Color.White ? btnTable.BackColor = Color.LightGreen : btnTable.BackColor = Color.White;
                this.SelectedTable = btnTable;
            }
        }
        private void bindDgvBill(int id)
        {
            using(CoffeeContextDB _contextDB = new CoffeeContextDB())
            {
                    List<List> listBillInfo = MenuDAO.Instance.GetListMenu(id);
                    dgvTableDetails.Rows.Clear();
                    float total = 0;
                    foreach (List item in listBillInfo)
                    {
                        int index = dgvTableDetails.Rows.Add();
                        dgvTableDetails.Rows[index].Cells[0].Value = item.name;
                        dgvTableDetails.Rows[index].Cells[1].Value = item.count;
                        dgvTableDetails.Rows[index].Cells[2].Value = item.Price;
                        dgvTableDetails.Rows[index].Cells[3].Value = item.Totalprice;
                        total += item.Totalprice;
                    }
                    txtTotalPrice.Text = total.ToString();
                    //CultureInfo culture = new CultureInfo("vi-VN");
                    //txtTotalPrice.Text = string.Format("c",culture);
            }

        }
        private void cmbCategory_TextChanged(object sender, EventArgs e)
        {
            CoffeeContextDB context = new CoffeeContextDB();
            List<Food> listFood = context.Foods.ToList().Where(p => p.FoodCategory.name == cmbCategory.Text).ToList();
            cmbFoody(listFood);
        }
        
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            TableFood table = dgvTableDetails.Tag as TableFood;
            int idBill = BillDAO.Instance.GetIDBillbyIDTable(table.id);
            int FoodID = (cmbFood.SelectedItem as Food).id;
            int count = (int)nmFoodCount.Value;
            if (idBill == -1) //Bill chưa tồn tại
            {
                BillDAO.Instance.InsertBill(table.id);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(),FoodID,count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, FoodID, count);
            }
            bindDgvBill(table.id);
            InitTable();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            TableFood table = dgvTableDetails.Tag as TableFood;
            int billID = BillDAO.Instance.GetIDBillbyIDTable(table.id);
            int Discount = (int)nmDiscount.Value;
            int totalPrice = int.Parse(txtTotalPrice.Text.ToString());
            if (billID != -1)
            {
                if (MessageBox.Show("Sử dụng mã giảm giá "+Discount+"%" + " cho bàn " +table.id +"\n           Xác nhận Thanh Toán ?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) 
                {
                    BillDAO.Instance.CheckOut(billID,Discount, totalPrice);
                    TableDAO.Instance.CheckoutTable(table.id);
                    bindDgvBill(table.id);
                }
            }
            InitTable();
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int table1 = (dgvTableDetails.Tag as TableFood).id; 
            int table2 = (cmbTableChange.SelectedItem as TableFood).id;
            if(MessageBox.Show("Chuyen tu ban" + (dgvTableDetails.Tag as TableFood).name + " sang ban "+ (cmbTableChange.SelectedItem as TableFood).name , "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TableDAO.Instance.SwitchTable(table1, table2);
                
            }
            InitTable();
        }
    }
}

