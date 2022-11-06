namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SERVICE")]
    public partial class SERVICE
    {
        [StringLength(10)]
        public string ServiceID { get; set; }

        [StringLength(30)]
        public string ServiceName { get; set; }

        [StringLength(20)]
        public string ServicePrice { get; set; }

        [StringLength(100)]
        public string ServiceImage { get; set; }
    }
}
