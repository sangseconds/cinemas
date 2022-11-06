namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROOM")]
    public partial class ROOM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROOM()
        {
            MOVIE_TIME = new HashSet<MOVIE_TIME>();
        }

        [StringLength(10)]
        public string RoomID { get; set; }

        [StringLength(20)]
        public string RoomName { get; set; }

        [StringLength(10)]
        public string CinemaID { get; set; }

        [StringLength(10)]
        public string ScreenType { get; set; }

        public int? Quantity { get; set; }

        public virtual CINEMA CINEMA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIE_TIME> MOVIE_TIME { get; set; }
    }
}
