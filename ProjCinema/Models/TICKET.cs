namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TICKET")]
    public partial class TICKET
    {
        [StringLength(20)]
        public string TicketID { get; set; }

        [StringLength(20)]
        public string SeatID { get; set; }

        [StringLength(20)]
        public string TicketSession { get; set; }

        [StringLength(50)]
        public string TicketType { get; set; }

        public virtual SEAT SEAT { get; set; }
    }
}
