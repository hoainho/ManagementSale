using ManagementSale.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSale.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        public int GetIDBillbyIDTable(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BILL WHERE idTable =" + id + " and status = 0 ");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.id;
            }
            return -1;
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC InsertBill @idTable", new object[] { id });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT max(id) FROM Bill");
            }
            catch
            {
                return 1;
            }
        }
        public void CheckOut(int id,int discount,int totalPrice)
        {
            string query = "UPDATE Bill SET DateCheckOut = GetDate() ,status = 1 " +",discount= "+discount+ ",totalPrice = " + totalPrice + " WHERE id =" + id ;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
