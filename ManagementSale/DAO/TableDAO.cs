using ManagementSale.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSale.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        private TableDAO() { }

        public List<TableFood> LoadTable()
        {
            List<TableFood> listTable = new List<TableFood>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC GetTableList");
            foreach(DataRow item in data.Rows)
            {
                TableFood table = new TableFood(item);
                listTable.Add(table);
            }
            return listTable;
        }
        public void CheckoutTable(int id)
        {
            string query = "UPDATE TableFood SET status = N'Trống' WHERE id =" + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("SwitchTable @idTable1 , @idTable2",new object[]{id1,id2});
        }
        public void  MergeTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("MergeTable @idTable1 , @idTable2", new object[] { id1, id2 });
        }
    }
}
