namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA")]
    public partial class CINEMA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CINEMA()
        {
            CINEMA_IMAGE = new HashSet<CINEMA_IMAGE>();
            ROOMs = new HashSet<ROOM>();
        }

        [StringLength(10)]
        public string CinemaID { get; set; }

        [StringLength(10)]
        public string LocationID { get; set; }

        [StringLength(100)]
        public string CinemaName { get; set; }

        [StringLength(100)]
        public string CinemaAddress { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public virtual CINEMA_LOCATION CINEMA_LOCATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CINEMA_IMAGE> CINEMA_IMAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOM> ROOMs { get; set; }
    }
}
