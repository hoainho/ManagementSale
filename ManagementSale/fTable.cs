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
        public fTable()
        {
            InitializeComponent();
        }
        private void StatusSetting()
        {
            using (var _dbContext = new CoffeeContextDB())
            {
                int soThuTuGhe;
                foreach (Button ghe in grbHangGhe.Controls.OfType<Button>())
                {
                    soThuTuGhe = int.Parse(ghe.Text);
                    if (_dbContext.ChiTietHoaDons.Any(x => x.SoThuTuGhe == soThuTuGhe))
                    {
                        ghe.BackColor = Color.DarkGoldenrod;
                    }
                }
            }
        }
    }
}
