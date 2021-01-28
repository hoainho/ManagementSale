namespace ManagementSale.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("BillInfo")]
    public partial class BillInfo
    {
        public BillInfo(int id,int idBill, int idFood, int count)
        {
            this.id = id;
            this.idBill = idBill;
            this.idFood = idFood;
            this.count = count;
        }
        public BillInfo(DataRow item)
        {
            this.id = (int)item["id"];
            this.idBill = (int)item["idBill"];
            this.idFood = (int)item["idFood"];
            this.count = (int)item["count"];
        }

        public BillInfo()
        {
            this.id = 0;
            this.idBill = 0;
            this.idFood = 0;
            this.count = 0;
        }

        public int id { get; set; }

        public int idBill { get; set; }

        public int idFood { get; set; }

        public int count { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Food Food { get; set; }

    }
}
