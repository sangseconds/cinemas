namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MOVIE")]
    public partial class MOVIE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOVIE()
        {
            MOVIE_TIME = new HashSet<MOVIE_TIME>();
        }

        [StringLength(10)]
        public string MovieID { get; set; }

        [StringLength(50)]
        public string MovieName { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

        [StringLength(100)]
        public string Actor { get; set; }

        [StringLength(30)]
        public string Category { get; set; }

        public double? IMDb { get; set; }

        public byte? MovieLength { get; set; }

        public byte? Rate { get; set; }

        [StringLength(30)]
        public string Nation { get; set; }

        [StringLength(100)]
        public string PosterLink { get; set; }

        [StringLength(100)]
        public string BannerLink { get; set; }

        [StringLength(100)]
        public string TrailerLink { get; set; }

        public string MovieDescription { get; set; }

        public byte? MovieStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIE_TIME> MOVIE_TIME { get; set; }
    }
}
