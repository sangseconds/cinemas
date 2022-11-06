namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TICKET_TYPE
    {
        [Key]
        [StringLength(10)]
        public string TicketTypeID { get; set; }

        [StringLength(50)]
        public string TicketTypeName { get; set; }

        [StringLength(20)]
        public string Price { get; set; }

        public int? TicketNum { get; set; }
    }
}
