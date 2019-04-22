namespace WebApiPR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuapp")]
    public partial class usuapp
    {
        public int id { get; set; }

        [Required]
        [StringLength(75)]
        public string nombre { get; set; }

        [Required]
        [StringLength(75)]
        public string usuario { get; set; }

        [Required]
        [StringLength(75)]
        public string emailusu { get; set; }

        [Required]
        [StringLength(25)]
        public string passusu { get; set; }
    }
}
