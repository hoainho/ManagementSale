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
    public partial class fHome : Form
    {
        private Account account;

        public fHome()
        {
            InitializeComponent();
        }

        private void fHome_Load(object sender, EventArgs e)
        {
            toolVisible(false);
            OpenTableForm();
            OpenLoginForm();

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
            this.account = acc;
            mnsInfomation.Text = string.Format(acc.DisplayName);
            toolVisible(false);
        }
        private void toolVisible(bool status)
        {
            if (account == null)
            {
                mnsHome.Visible = status;
                mnsManager.Visible = status;
                mnsInfomation.Visible = status;
                mnsHelp.Visible = status;
            }
            else
            {
                if (account.Type == 1)
                {
                    mnsHome.Visible = !status;
                    mnsManager.Visible = status;
                    mnsInfomation.Visible = !status;
                    mnsHelp.Visible = !status;
                }
                else
                {
                    mnsManager.Visible = !status;
                    mnsHome.Visible = !status;
                    mnsInfomation.Visible = !status;
                    mnsHelp.Visible = !status;
                }
            }
           
        }
        public void showTable()
        {
            if (account != null)
            {
                OpenTableForm();
            }
        }
        public void OpenTableForm()
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
                fAccountDetails frm = new fAccountDetails(account);
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                return;
            }
            frmChild.Activate();
        }
        public void ControlVisible(bool status)
        {
            mnsHome.Visible = status;
            mnsManager.Visible = status;
            mnsInfomation.Visible = status;
            mnsHelp.Visible = status;
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenTableForm();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
