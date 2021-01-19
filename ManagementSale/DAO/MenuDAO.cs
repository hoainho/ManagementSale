using ManagementSale.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSale.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }
        public List<List> GetListMenu(int id)
        {
            List<List> listMenu = new List<List>();

            string query = "SELECT  food.name , BillInfo.count , food.price, food.price * BillInfo.count As totalprice from BillInfo, Food, Bill, TableFood WHERE  bill.status = 0 AND bill.id = BillInfo.idBill AND food.id = BillInfo.idFood AND TableFood.status = N'Có Khách' AND TableFood.id = " + id +" AND idTable =" + id ;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                List menu = new List(item);
                listMenu.Add(menu);
            }    

           return listMenu;
        }

    }
}
