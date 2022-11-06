namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POST")]
    public partial class POST
    {
        [StringLength(10)]
        public string PostID { get; set; }

        [StringLength(30)]
        public string PostCategory { get; set; }

        [StringLength(100)]
        public string PostThumbnail { get; set; }

        [Column(TypeName = "ntext")]
        public string PostTitle { get; set; }

        [Column(TypeName = "ntext")]
        public string PostDescription { get; set; }

        public DateTime? CreateAt { get; set; }

        public int? AdminID { get; set; }
    }
}
