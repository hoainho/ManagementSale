namespace ManagementSale.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        public Bill()
        {
            BillInfoes = new HashSet<BillInfo>();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill(int id , DateTime DateCheckIn, DateTime? DateCheckOut, int status)
        {
            this.id = id;
            this.DateCheckIn = DateCheckIn;
            this.DateCheckOut = DateCheckOut;
            this.status = status;
        }
        public Bill(DataRow row)
        {
            this.id = (int)row["id"];
            this.DateCheckIn = (DateTime)row["DateCheckIn"];
            var DateCheckOutTemp = row["DateCheckOut"];
            if(DateCheckOutTemp.ToString() != "")
            this.DateCheckOut = (DateTime?)DateCheckOutTemp;
            this.status = (int)row["status"];
        }
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCheckIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCheckOut { get; set; }

        public int idTable { get; set; }

        public int status { get; set; }

        public int? discount { get; set; }

        public double? totalPrice { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public virtual Account Account { get; set; }

        public virtual TableFood TableFood { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillInfo> BillInfoes { get; set; }
    }
}
