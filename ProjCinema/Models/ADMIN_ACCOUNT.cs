namespace ProjCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ADMIN_ACCOUNT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminName { get; set; }

        [StringLength(20)]
        public string AdminPassword { get; set; }

        [StringLength(10)]
        public string DepartmentID { get; set; }
    }
}
