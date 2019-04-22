namespace WebApiPR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            reservacion = new HashSet<reservacion>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(75)]
        public string nombrecl { get; set; }

        [Required]
        [StringLength(10)]
        public string cellcl { get; set; }

        [Required]
        [StringLength(75)]
        public string emailcl { get; set; }

        [Required]
        [StringLength(25)]
        public string passcl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservacion> reservacion { get; set; }
    }
}
