namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SEAT")]
    public partial class SEAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEAT()
        {
            TICKETs = new HashSet<TICKET>();
        }

        [StringLength(20)]
        public string SeatID { get; set; }

        [StringLength(4)]
        public string SeatName { get; set; }

        [StringLength(10)]
        public string MovieTimeID { get; set; }

        public virtual MOVIE_TIME MOVIE_TIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET> TICKETs { get; set; }
    }
}
