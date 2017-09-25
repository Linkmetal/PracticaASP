namespace WebApplication3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CURSOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CURSOS()
        {
            ALUMNOS = new HashSet<ALUMNOS>();
            NOTAS = new HashSet<NOTAS>();
        }

        [Key]
        [StringLength(10)]
        public string COD_CUR { get; set; }

        [StringLength(30)]
        public string DESCRIPCION { get; set; }

        public int? HORAS { get; set; }

        [StringLength(30)]
        public string TUTOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALUMNOS> ALUMNOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTAS> NOTAS { get; set; }
    }
}
