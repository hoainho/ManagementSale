using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSale
{
    class SaleReports
    {
       public int idbill { get; set; }
       public string IdTable{get; set;}
       public string DateCheckIn{get; set;}
       public string DateCheckOut{get; set;}
       public string Status{get; set;}
       public int Discount{get; set;}
       public int totalPrice{get; set;}
       public DateTime timeReport { get; set; }
       public string user { get; set; }
    }
}
