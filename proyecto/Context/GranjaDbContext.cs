using Microsoft.EntityFrameworkCore;

using proyecto.Model;

namespace proyecto.Context
{
    public class GranjaDbContext : DbContext
    {
        public GranjaDbContext(DbContextOptions<GranjaDbContext> options) : base(options)
        {

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
       
    }
}
