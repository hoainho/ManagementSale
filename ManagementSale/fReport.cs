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
using Microsoft.Reporting.WinForms;

namespace ManagementSale
{
    public partial class fReport : Form
    {
        public fReport()
        {
            InitializeComponent();
        }

        private void fReport_Load(object sender, EventArgs e)
        {
            using (var _contextDB = new CoffeeContextDB())
            {
                List<SaleReports> listReport = new List<SaleReports>();
                List<Bill> listBill = _contextDB.Bills.ToList();
                foreach (Bill item in listBill)
                {
                    string status = item.status == 1 ? "Đã Thanh Toán" : "Chưa Thanh Toán";
                    SaleReports temp = new SaleReports();
                    temp.IdTable = item.TableFood.name;
                    temp.idbill = item.id;
                    temp.DateCheckIn = item.DateCheckIn.ToString();
                    temp.DateCheckOut = item.DateCheckOut.ToString();
                    temp.Status = status;
                    temp.Discount = int.Parse(item.discount.ToString()) ;
                    temp.totalPrice = int.Parse(item.totalPrice.ToString());
                    temp.timeReport = DateTime.Now;
                    temp.user = item.Account.DisplayName;
                    listReport.Add(temp);
                }
                this.reportViewer1.LocalReport.ReportPath = "rptReportSale.rdlc";
                var reportDataSource = new ReportDataSource("DataSet1",listReport);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
