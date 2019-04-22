namespace WebApiPR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public productos()
        {
            detallereservacion = new HashSet<detallereservacion>();
        }

        public int id { get; set; }

        public int idcategoria { get; set; }

        [Required]
        [StringLength(75)]
        public string nomproducto { get; set; }

        public string descripcion { get; set; }

        public decimal precio { get; set; }

        public int? idestado { get; set; }

        public virtual categorias categorias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detallereservacion> detallereservacion { get; set; }

        public virtual estados estados { get; set; }
    }
}
