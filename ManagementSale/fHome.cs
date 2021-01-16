using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSale
{
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
        }

        private void fHome_Load(object sender, EventArgs e)
        {
            OpenLoginForm();
            OpenTableForm();
        }
        public void OpenLoginForm()
        {
            Form frmChild = this.MdiChildren.OfType<fLogin>().FirstOrDefault();

            if (frmChild == null)
            {
                fLogin frm = new fLogin();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.accountAccuracy += Frm_accountAccuracy;
                frm.Show();
                return;
            }
            frmChild.Activate();
        }

        private void Frm_accountAccuracy(Models.Account acc)
        {
            Form frmChild = this.MdiChildren.OfType<fTable>().FirstOrDefault();

            if (frmChild == null)
            {
                fTable frm = new fTable();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                return;
            }
            frmChild.Activate();
        }

        public void OpenTableForm()
        {
            Form frmChild = this.MdiChildren.OfType<fLogin>().FirstOrDefault();

            if (frmChild == null)
            {
                fLogin frm = new fLogin();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                return;
            }
            frmChild.Activate();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmChild = this.MdiChildren.OfType<Admin>().FirstOrDefault();

            if (frmChild == null)
            {
                Admin frm = new Admin();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                return;
            }
            frmChild.Activate();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmChild = this.MdiChildren.OfType<fAccountDetails>().FirstOrDefault();

            if (frmChild == null)
            {
                fAccountDetails frm = new fAccountDetails();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                return;
            }
            frmChild.Activate();
        }
        public void ControlVisible()
        {

        }

        private void hỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmChild = this.MdiChildren.OfType<fHelp>().FirstOrDefault();

            if (frmChild == null)
            {
                fHelp frm = new fHelp();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                return;
            }
            frmChild.Activate();
        }
    }
}
