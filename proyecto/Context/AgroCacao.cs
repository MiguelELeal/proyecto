using Microsoft.EntityFrameworkCore;

using proyecto.Model;

namespace proyecto.Context
{
    public class AgroCacao : DbContext
    {
        public AgroCacao(DbContextOptions<AgroCacao> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<DatosPartida>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<Cultivo>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<EstadoCultivo>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<Insumos>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<InsumosRequeridos>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<Logro>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<LogroConseguido>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<Partida>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<Procedimento>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<Siembra>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<Terreno>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<TipoDocumento>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<TipoProcedimiento>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<Trabajadores>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<TrabajadoresRequeridos>().HasQueryFilter(p => p.status);
            modelBuilder.Entity<Usuario>().HasQueryFilter(p => p.status);
        }

        public DbSet <Usuario> Usuarios { get; set; }
        public DbSet <Rol> Roles { get; set; }
        public DbSet<Insumos> Insumos { get; set; }
        public DbSet<Cultivo> Cultivos { get; set; }
        public DbSet<EstadoCultivo> EstadoCultivos { get; set; }
        public DbSet<Logro> Logros { get; set; }
        public DbSet<Siembra> Siembras { get; set; }
        public DbSet<Terreno> Terrenos { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<TipoProcedimiento> TipoProcedimientos { get; set; }
        public DbSet<InsumosRequeridos> InsumosRequeridos { get; set; }
        public DbSet<LogroConseguido> LogrosConseguidos { get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Trabajadores> Trabajadores { get; set; }
        public DbSet<TrabajadoresRequeridos> TrabajadoresRequeridos { get; set; }
        public DbSet<DatosPartida> DatosPartidas { get; set; }




    }
}
