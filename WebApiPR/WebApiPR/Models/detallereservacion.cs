namespace WebApiPR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detallereservacion")]
    public partial class detallereservacion
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idreservacion { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idproducto { get; set; }

        public decimal? precio { get; set; }

        public int? cantidad { get; set; }

        public decimal? subtotal { get; set; }

        public virtual productos productos { get; set; }

        public virtual reservacion reservacion { get; set; }
    }
}
