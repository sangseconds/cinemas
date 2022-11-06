namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILL")]
    public partial class BILL
    {
        [StringLength(10)]
        public string BillID { get; set; }

        [StringLength(10)]
        public string UserID { get; set; }

        [StringLength(20)]
        public string TicketSession { get; set; }

        [StringLength(20)]
        public string ServiceSession { get; set; }

        [StringLength(10)]
        public string CodeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PayDay { get; set; }

        public virtual DISCOUNT_CODE DISCOUNT_CODE { get; set; }

        public virtual USER_ACCOUNT USER_ACCOUNT { get; set; }
    }
}
