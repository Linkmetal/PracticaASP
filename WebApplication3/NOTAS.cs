namespace WebApplication3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NOTAS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string COD_CUR { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string COD_ALU { get; set; }

        public int? NOTA1 { get; set; }

        public int? NOTA2 { get; set; }

        public int? NOTA3 { get; set; }

        public int? MEDIA { get; set; }

        public virtual ALUMNOS ALUMNOS { get; set; }

        public virtual CURSOS CURSOS { get; set; }
    }
}
