namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CINEMA_LOCATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CINEMA_LOCATION()
        {
            CINEMAs = new HashSet<CINEMA>();
        }

        [Key]
        [StringLength(10)]
        public string LocationID { get; set; }

        [StringLength(50)]
        public string LocationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CINEMA> CINEMAs { get; set; }
    }
}
