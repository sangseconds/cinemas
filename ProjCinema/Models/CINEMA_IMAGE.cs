namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CINEMA_IMAGE
    {
        [Key]
        [StringLength(10)]
        public string CinemaImageID { get; set; }

        [StringLength(10)]
        public string CinemaID { get; set; }

        [StringLength(100)]
        public string ImageLink { get; set; }

        public virtual CINEMA CINEMA { get; set; }
    }
}
