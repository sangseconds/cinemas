namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MOVIE_TIME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOVIE_TIME()
        {
            SEATs = new HashSet<SEAT>();
        }

        [Key]
        [StringLength(10)]
        public string MovieTimeID { get; set; }

        [StringLength(10)]
        public string MovieID { get; set; }

        [StringLength(10)]
        public string RoomID { get; set; }

        [StringLength(10)]
        public string ShowTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DayTime { get; set; }

        public virtual MOVIE MOVIE { get; set; }

        public virtual ROOM ROOM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEAT> SEATs { get; set; }
    }
}
