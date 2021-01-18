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
namespace ManagementSale
{
    public partial class fTable : Form
    {
        private int ActiveTable = 0;
        private Button SelectedTable;
        private Button btnTable;

        public object DataProvider { get; private set; }

        public fTable()
        {
            InitializeComponent();
        }

        private void fTable_Load(object sender, EventArgs e)
        {
            CoffeeContextDB context = new CoffeeContextDB();
            List<FoodCategory> listCategory = context.FoodCategories.ToList();
            List<Food> listFood = context.Foods.ToList();
            List<TableFood> listTable = context.TableFoods.ToList();
            cmbType(listCategory);
            cmbFoody(listFood);
            cmbTableChanged(listTable);
            InitTable(listTable);
            //StatusSetting();
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
            cmbFood.DisplayMember = "id";
            cmbFood.ValueMember = "id";
        }
        private void cmbTableChanged(List<TableFood> listTable)
        {
            cmbTableChange.DataSource = listTable;
            cmbTableChange.DisplayMember = "name" + 1;
            cmbTableChange.ValueMember = "id";
        }
        
        private void InitTable(List<TableFood> listTable)
        {
            //List<TableFood> listTableee = TableDAO.Instance.LoadTable();
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
            SelectionTable(btn);
            bindDgvBill(btnTable);
        }
        private void SelectionTable(Button btnTable)
        {
            lblTableName.Text = "Bàn Số " + btnTable.Text; //Hien thi so ban
            //Chon vi tri them mon
            if (this.ActiveTable == 1 && btnTable.BackColor == Color.LightGreen)
            {
                this.ActiveTable = 0;
                btnTable.BackColor = Color.White;
                return;
            }
            else if (this.ActiveTable < 1)
            {

                if (btnTable.BackColor == Color.DarkGoldenrod)
                {
                    return;
                }

                else
                {
                    _ = btnTable.BackColor == Color.White ? btnTable.BackColor = Color.LightGreen : btnTable.BackColor = Color.White;
                    this.SelectedTable = btnTable;
                    this.ActiveTable++;
                    return;
                }
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
                CultureInfo culture = new CultureInfo("vi-VN");
                txtTotalPrice.Text = total.ToString("c", culture);
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
            using (var _contextDB = new CoffeeContextDB())
            {
                foreach (Button Table in flpTable.Controls.OfType<Button>())
                {
                    int TableID = int.Parse(Table.Text);
                    int FoodID = int.Parse(cmbFood.Text);
                    int count = (int)nmFoodCount.Value;
                    int IDBILL = BillDAO.Instance.GetIDBillbyIDTable(TableID);
                    if (IDBILL != -1) //Bill chưa tồn tại
                    {
                        BillDAO.Instance.InsertBill(TableID);
                        BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(),FoodID,count);
                    }
                    else
                    {
                        BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), FoodID, count);
                    }
                }
            }
            this.ActiveTable = 0;   

        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            if (this.btnTable != null && btnTable.BackColor == Color.DarkGoldenrod)
            {
                if (cmbTableChange.Text != btnTable.Text)
                {
                    using (CoffeeContextDB _contextDB = new CoffeeContextDB())
                    {
                        List<Bill> listEmptyTable = _contextDB.Bills.AsEnumerable().Where(x => x.idTable == int.Parse(cmbTableChange.Text)).ToList();
                        List<Bill> listIsActive = _contextDB.Bills.AsEnumerable().Where(x => x.idTable == int.Parse(btnTable.Text)).ToList();
                        MessageBox.Show(cmbTableChange.Text.ToString());
                        MessageBox.Show(btnTable.Text.ToString());
                        foreach (Bill itemIA in listIsActive)
                        {
                            foreach (Bill itemEmpty in listEmptyTable)
                            {
                                itemEmpty.id = itemIA.id;
                                itemEmpty.DateCheckIn = itemIA.DateCheckIn;
                                itemEmpty.DateCheckOut = itemIA.DateCheckOut;
                                itemEmpty.idTable = itemIA.idTable;
                                itemEmpty.status = itemIA.status;
                                itemEmpty.discount = itemIA.discount;
                                itemEmpty.totalPrice = itemIA.totalPrice;
                                itemEmpty.UserName = itemIA.UserName;
                                listEmptyTable.Clear();
                                _contextDB.Bills.Add(itemEmpty);
                                _contextDB.SaveChanges();
                            }
                        }
                    }
                }
                else if (this.btnTable != null && btnTable.BackColor == Color.LightGreen)
                {
                    MessageBox.Show("Vui lòng chọn bàn đã có khách để chuyển !", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn bàn muốn chuyển !", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
         
        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

