namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class POST_CONTENT
    {
        [Key]
        [StringLength(10)]
        public string PostContentID { get; set; }

        [StringLength(10)]
        public string PostID { get; set; }

        public string PostPara1 { get; set; }

        [StringLength(100)]
        public string PostImg1 { get; set; }

        public string PostPara2 { get; set; }

        [StringLength(100)]
        public string PostImg2 { get; set; }

        public string PostPara3 { get; set; }
    }
}
