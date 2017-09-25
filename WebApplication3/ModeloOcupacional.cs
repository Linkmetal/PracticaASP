namespace WebApplication3 {
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class ModeloOcupacional:DbContext {
		public ModeloOcupacional()
			: base("name=ModeloOcupacional") {
		}

		public virtual DbSet<ALUMNOS> ALUMNOS { get; set; }
		public virtual DbSet<CURSOS> CURSOS { get; set; }
		public virtual DbSet<NOTAS> NOTAS { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Entity<ALUMNOS>()
				.Property(e => e.COD_ALU)
				.IsUnicode(false);

			modelBuilder.Entity<ALUMNOS>()
				.Property(e => e.COD_CUR)
				.IsUnicode(false);

			modelBuilder.Entity<ALUMNOS>()
				.Property(e => e.DNI)
				.IsUnicode(false);

			modelBuilder.Entity<ALUMNOS>()
				.Property(e => e.APELLIDOS)
				.IsUnicode(false);

			modelBuilder.Entity<ALUMNOS>()
				.Property(e => e.NOMBRE)
				.IsUnicode(false);

			modelBuilder.Entity<ALUMNOS>()
				.HasMany(e => e.NOTAS)
				.WithRequired(e => e.ALUMNOS)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CURSOS>()
				.Property(e => e.COD_CUR)
				.IsUnicode(false);

			modelBuilder.Entity<CURSOS>()
				.Property(e => e.DESCRIPCION)
				.IsUnicode(false);

			modelBuilder.Entity<CURSOS>()
				.Property(e => e.TUTOR)
				.IsUnicode(false);

			modelBuilder.Entity<CURSOS>()
				.HasMany(e => e.ALUMNOS)
				.WithRequired(e => e.CURSOS)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CURSOS>()
				.HasMany(e => e.NOTAS)
				.WithRequired(e => e.CURSOS)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<NOTAS>()
				.Property(e => e.COD_CUR)
				.IsUnicode(false);

			modelBuilder.Entity<NOTAS>()
				.Property(e => e.COD_ALU)
				.IsUnicode(false);
		}
	}
}
