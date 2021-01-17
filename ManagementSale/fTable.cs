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
    public partial class fTable : Form
    {
        private const string Format = "dd/mm/yyyy";
        private int ActiveTable = 0;
        private int No = 1;
        private Button SelectedTable;
        private Button btnTable;
        public fTable()
        {
            InitializeComponent();

        }

        private void fTable_Load(object sender, EventArgs e)
        {
            CoffeeContextDB context = new CoffeeContextDB();
            List<FoodCategory> listCategory = context.FoodCategories.ToList();
            List<Food> listFood = context.Foods.ToList();
            List<BillInfo> listBill = context.BillInfoes.ToList();
            cmbType(listCategory);
            cmbFoody(listFood);
            InitTable(4, 5);
            StatusSetting();
            //bindDgvBill(listBill);
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
            cmbFood.ValueMember = "idCategory";
        }
        private void StatusSetting()
        {
            using (var _dbContext = new CoffeeContextDB())
            {
                int indexTable;
                foreach (Button Table in flpTable.Controls.OfType<Button>())
                {
                    indexTable = int.Parse(Table.Text);
                    if (_dbContext.Bills.Any(x => x.idTable == indexTable))
                    {
                        Table.BackColor = Color.DarkGoldenrod;
                    }
                }
            }
        }
        private void InitTable(int row, int col)
        {
            Button btnTable;
            int index = 1;
            int x = 10, y = 10, marginX = 100;
            for (int i = 0; i < row; i++)
            {
                x = 10;
                for (int j = 0; j < col; j++)
                {
                    //Khoi tao doi tuong Button la Ghe
                    btnTable = new Button();
                    btnTable.BackColor = System.Drawing.Color.White;
                    btnTable.Location = new System.Drawing.Point(x, y);
                    btnTable.Name = "btnTable" + index;
                    btnTable.Size = new System.Drawing.Size(100, 100);
                    btnTable.TabIndex = 0;
                    btnTable.Text = index.ToString();
                    btnTable.UseVisualStyleBackColor = false;
                    btnTable.Click += BtnTable_Click;
                    flpTable.Controls.Add(btnTable);
                    index++;
                    x += marginX;
                }
                y += marginX;
            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            this.btnTable = (Button)sender;
            SelectionTable(btnTable);
        }
        private void SelectionTable(Button btnTable)
        {
            lblTableName.Text = "Bàn Số " + btnTable.Text; //Hien thi so ban
            //Chon vi tri them mon
            if (this.ActiveTable >= 1)
            {
                if (btnTable.BackColor == Color.LightGreen)
                {
                    /////////////// xanh 
                    btnTable.BackColor = Color.White;
                    this.ActiveTable = 0;
                    return;
                }
                if (btnTable.BackColor == Color.White)
                {
                    /////////////// trang 
                    MessageBox.Show("Vui lòng hoàn thành Order món cho " + btnTable.Text);
                    return;
                }
                if (btnTable.BackColor == Color.DarkGoldenrod)
                {
                    /////////////// vang 
                    this.ActiveTable = 0;
                    return;
                }
            }
            else if (this.ActiveTable < 1)
            {

                if (btnTable.BackColor == Color.DarkGoldenrod)
                {
                    bindDgvBill(btnTable);
                    this.ActiveTable = 0;
                    return;
                }
                else
                {
                    _ = btnTable.BackColor == Color.White ? btnTable.BackColor = Color.LightGreen : btnTable.BackColor = Color.White;
                    this.ActiveTable++;
                    return;
                }
            }
        }
        private void bindDgvBill(Button btnTable)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<BillInfo> listBill = _contextDB.BillInfoes.AsEnumerable().Where(x => x.Bill.idTable == int.Parse(btnTable.Text)).ToList();
                dgvTableDetails.Rows.Clear();
                foreach (var item in listBill)
                {
                    int index = dgvTableDetails.Rows.Add();
                    dgvTableDetails.Rows[index].Cells[0].Value = this.No;
                    dgvTableDetails.Rows[index].Cells[1].Value = item.Food.name;
                    dgvTableDetails.Rows[index].Cells[2].Value = item.count;
                    dgvTableDetails.Rows[index].Cells[3].Value = item.Food.price;
                    this.No++;
                }
            }
        }
        private void ShowdgvBill()
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<BillInfo> listBill = _contextDB.BillInfoes.ToList();
                dgvTableDetails.Rows.Clear();
                foreach (var item in listBill)
                {
                    int index = dgvTableDetails.Rows.Add();
                    dgvTableDetails.Rows[index].Cells[0].Value = this.No;
                    dgvTableDetails.Rows[index].Cells[1].Value = item.Food.name;
                    dgvTableDetails.Rows[index].Cells[2].Value = item.count;
                    dgvTableDetails.Rows[index].Cells[3].Value = item.Food.price;
                    this.No++;
                }
            }
        }
        private void BtnDatMua_Click(object sender, EventArgs e)
        {
            //MuaVe();
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
                    if (Table.BackColor == Color.LightGreen)
                    {
                        Bill bill = new Bill();
                        BillInfo temp = new BillInfo();
                        bill.DateCheckIn = DateTime.Now;
                        bill.idTable = int.Parse(Table.Text);
                        bill.status = 0;
                        bill.UserName = "user";
                        temp.idBill = bill.id;
                        temp.idFood = int.Parse(cmbFood.SelectedValue.ToString() ) + 1;
                        temp.count = int.Parse(nmFoodCount.Value.ToString());
                        _contextDB.Bills.Add(bill);
                        _contextDB.BillInfoes.Add(temp);
                        _contextDB.SaveChanges();
                    };
                }
              
                
            }
            StatusSetting();
            bindDgvBill(this.btnTable);
        }
    
    
    //////////////////////////////
    }
}

