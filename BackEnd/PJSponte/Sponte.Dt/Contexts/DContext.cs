using Sponte.Sdn;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Sponte.Dt.Context
{
    public class DContext : DbContext
    {
        public DContext(DbContextOptions<DContext> options) : base(options) { }
        public DbSet<Instrutor> Instrutor { get; set; }
        public DbSet<Live> Live { get; internal set; }
        public DbSet<Inscrito> Inscrito { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Instrutor>()
                .HasMany(e => e.Live)
                .WithOne(rs => rs.Instrutor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Live>()
                .HasMany(e => e.Inscricao)
                .WithOne(rs => rs.Live)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inscrito>()
              .HasMany(e => e.Inscricao)
              .WithOne(rs => rs.Inscrito)
              .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
