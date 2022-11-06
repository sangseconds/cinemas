namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SERVICE_TO_CASH
    {
        [Key]
        [StringLength(20)]
        public string ServiceToCashID { get; set; }

        [StringLength(10)]
        public string ServiceID { get; set; }

        public int? ServiceNum { get; set; }

        [StringLength(20)]
        public string ServiceSession { get; set; }

        [StringLength(30)]
        public string ServiceName { get; set; }

        [StringLength(20)]
        public string ServicePrice { get; set; }
    }
}
