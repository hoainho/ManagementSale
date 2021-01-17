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
            int row = 5, col = 5;
            InitTable(row, col);
            StatusSetting();
            bindDgvBill(listBill);
        }
        private void cmbType(List<FoodCategory> listCategory )
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
                x =10;
                for (int j = 0; j < col; j++)
                {
                    //Khoi tao doi tuong Button la Ghe
                    btnTable = new Button();
                    btnTable.BackColor = System.Drawing.Color.White;
                    btnTable.Location = new System.Drawing.Point(x, y);
                    btnTable.Name = "btnTable" + index;
                    btnTable.Size = new System.Drawing.Size(100,100);
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
            Button btnTable = (Button)sender;
            ChangeStatus(btnTable);
        }
        private void ChangeStatus(Button btnTable)
        {
            if (this.ActiveTable == 1 && btnTable.BackColor == Color.LightGreen)
            {
                this.ActiveTable = 0;
                btnTable.BackColor = Color.White;
                return;
            }
            if (this.ActiveTable == 1 && btnTable.BackColor != Color.LightGreen)
            {
                MessageBox.Show("Vui lòng hoàn thành Order món cho " + this.SelectedTable.Text);
                return;
            }
            else if (this.ActiveTable < 1)
            {
               
                if (btnTable.BackColor == Color.DarkGoldenrod)
                {
                    MessageBox.Show("BAN DA DUOC DAT");
                    return;
                }
                
                else
                {
                    _ = btnTable.BackColor == Color.White ? btnTable.BackColor = Color.LightGreen : btnTable.BackColor = Color.White;
                    this.SelectedTable = btnTable;
                    this.ActiveTable ++;
                    return;
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

        //private void btnAddFood_Click(object sender, EventArgs e)
        //{
        //    using (var _contextDB = new CoffeeContextDB())
        //    {
        //        using (var _dbContext = new CoffeeContextDB())
        //        {
        //            int indexTable;
        //            foreach (Button Table in flpTable.Controls.OfType<Button>())
        //            {
        //                Bill bill = new Bill();
        //                bill.idTable = 1;// table
        //                bill.DateCheckIn = DateTime.Now;
        //                indexTable = int.Parse(Table.Text + 1);
        //                if (_dbContext.TableFoods.Any(x => x.id == indexTable))
        //                {
        //                    bill.idTable = indexTable + 1;
        //                    MessageBox.Show(indexTable.ToString());
        //                }

        //            }
        //        }
        //    }

        //}

        private void dgvTableDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void bindDgvBill(List<BillInfo> listBill)
        {
            dgvTableDetails.Rows.Clear();
            foreach(var item in listBill)
            {
                int index = dgvTableDetails.Rows.Add();
                dgvTableDetails.Rows[index].Cells[0].Value = this.No;
                dgvTableDetails.Rows[index].Cells[1].Value = item.Food.name;
                dgvTableDetails.Rows[index].Cells[2].Value = item.count;
                dgvTableDetails.Rows[index].Cells[3].Value = item.Food.price;
                this.No++;
            }
        }
        //private void btnAddFood_Click(object sender, EventArgs e)
        //{
        //    if()
        //    int i = 0;
        //    using (var _contextDB = new CoffeeContextDB())
        //    {
        //        Bill bill = new Bill();
        //        bill.TableFood.name = txtTable.Text ;
        //        bill.id = i + 1;
        //        bill.idTable = 1;// table

        //        bill.DateCheckIn = DateTime.Parse(DateTime.Now.ToString());
        //    }            
        //}



        //private void MuaVe()
        //{
        //    List<Button> danhSachChon = new List<Button>();
        //    double tongTien = 0;
        //    foreach (Button ghe in flpTable.Controls.OfType<Button>())
        //    {
        //        if (ghe.BackColor == Color.LightGreen)
        //        {
        //            danhSachChon.Add(ghe);
        //            tongTien += TinhTien(ghe);
        //            ghe.BackColor = Color.DarkGoldenrod;
        //        }
        //    }
        //    if (danhSachChon.Count == 0)
        //    {
        //        MessageBox.Show("Vui long chon GHE");
        //        return;
        //    }
        //    else
        //    {
        //        txtThanhTien.Text = tongTien.ToString();
        //        //Tao hoa don
        //        HoaDon hoaDon = new HoaDon();
        //        hoaDon.TongTien = tongTien;
        //        hoaDon.NgayLap = DateTime.Now;
        //        using (var _dbContext = new RapChieuPhimContext())
        //        {
        //            //Luu hoa don
        //            _dbContext.HoaDons.Add(hoaDon);
        //            _dbContext.SaveChanges();
        //            //Tao danh sach chi tiet hoa don
        //            ChiTietHoaDon chiTietHoaDon;
        //            foreach (Button gheChon in danhSachChon)
        //            {
        //                //khoi tao chi tiet hoa don
        //                chiTietHoaDon = new ChiTietHoaDon();
        //                chiTietHoaDon.IdHoaDon = hoaDon.Id;
        //                chiTietHoaDon.SoThuTuGhe = int.Parse(gheChon.Text);
        //                _dbContext.ChiTietHoaDons.Add(chiTietHoaDon);
        //            }
        //            _dbContext.SaveChanges();
        //            //Hien thi danh sach hoa don
        //            HienThiDanhSachHoaDon();
        //        }
        //    }
        //}

    }
}
