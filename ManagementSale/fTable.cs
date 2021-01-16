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

        public fTable()
        {
            InitializeComponent();
            
        }
        
        private void fTable_Load(object sender, EventArgs e)
        {
            CoffeeContextDB context = new CoffeeContextDB();
            List<FoodCategory> listCategory = context.FoodCategories.ToList();
            List<Food> listFood = context.Foods.ToList();
            cmbType(listCategory);
            cmbFoody(listFood);
            int dong = 10, cot = 10;
            InitTable(dong, cot);
            StatusSetting();
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
                int soThuTuGhe;
                foreach (Button ghe in flpTable.Controls.OfType<Button>())
                {
                    soThuTuGhe = int.Parse(ghe.Text);
                    if (_dbContext.TableFoods.Any(x => x.id == soThuTuGhe))
                    {
                        ghe.BackColor = Color.DarkGoldenrod;
                    }
                }
            }
        }
        private void InitTable(int dong, int cot)
        {
            Button btnGhe;
            int soThuTu = 1;
            int x = 10, y = 10, khoangCach = 100;
            for (int i = 0; i < dong; i++)
            {
                x =10;
                for (int j = 0; j < cot; j++)
                {
                    //Khoi tao doi tuong Button la Ghe
                    btnGhe = new Button();
                    btnGhe.BackColor = System.Drawing.Color.White;
                    btnGhe.Location = new System.Drawing.Point(x, y);
                    btnGhe.Name = "btnGhe" + soThuTu;
                    btnGhe.Size = new System.Drawing.Size(100,100);
                    btnGhe.TabIndex = 0;
                    btnGhe.Text = soThuTu.ToString();
                    btnGhe.UseVisualStyleBackColor = false;
                    btnGhe.Click += BtnGhe_Click;
                    flpTable.Controls.Add(btnGhe);
                    soThuTu++;
                    x += khoangCach;
                }
                y += khoangCach;
            }
        }
        private void BtnGhe_Click(object sender, EventArgs e)
        {
            //todo
            Button btnGhe = (Button)sender;
            DoiMauGhe(btnGhe);
        }
        private void DoiMauGhe(Button btnGhe)
        {
            if (btnGhe.BackColor == Color.DarkGoldenrod)
            {
                MessageBox.Show("GHE DA DUOC MUA");
                return;
            }
            _ = btnGhe.BackColor == Color.White ? btnGhe.BackColor = Color.LightGreen : btnGhe.BackColor = Color.White;
        }

        private void BtnDatMua_Click(object sender, EventArgs e)
        {
            //lay danh cac ghe dang chon
            // - Cong don so tien
            // - Tao hoa don
            // - Luu Hoa don
            // - Luu danh sach hoa don
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
