using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSale.Models
{
    public class List
    {
        public List(string name, int count, float price, float totalprice)
        {
            this.name = name;
            this.count = count;
            this.Price = price;
            this.Totalprice = totalprice;
        }
        public List(DataRow item)
        {
            this.name = item["name"].ToString();
            this.count = (int)item["count"];
            this.Price = (float)Convert.ToDouble(item["price"].ToString());
            this.Totalprice = (float)Convert.ToDouble(item["totalprice"].ToString()); 
        }

        public string name { get; set; }

        public int count { get; set; }

        private float price { get; set; }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private float totalprice;
        public float Totalprice
        {   
            get { return totalprice; }
            set { totalprice = value; }
        }
       
    }
}
