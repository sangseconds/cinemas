namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADS")]
    public partial class AD
    {
        [Key]
        [StringLength(10)]
        public string AdsID { get; set; }

        [StringLength(10)]
        public string MovieID { get; set; }

        [StringLength(10)]
        public string PostID { get; set; }

        [StringLength(100)]
        public string Banner { get; set; }

        public byte? Type { get; set; }
    }
}
