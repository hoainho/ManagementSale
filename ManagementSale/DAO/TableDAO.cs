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
            return listTable;
        }

    }
}
