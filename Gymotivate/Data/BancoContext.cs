
using Gymotivate.Data.Map;
using Gymotivate.Models;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<CadastreModel> Cadastre { get; set; }
        public DbSet<ConquistasModel> Conquistas { get; set; }
        public DbSet<GrupoConquistasModel> GrupoConquistas { get; set; }
        public DbSet<NameConquistasModel> NameConquistas { get; set; }
        public DbSet<GamesModel> Acertos { get; set; }
        public DbSet<TreinoModel> Treino { get; set; }
        public DbSet<TreinoDiaSemanaModel> TreinoDiaSemana { get; set; }
        public DbSet<ExercicioModel> Exercicio { get; set; }
        public DbSet<TreinoExercicioModel> TreinoExercicio { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConquistaMap());
            modelBuilder.ApplyConfiguration(new GrupoConquistaMap());
            modelBuilder.ApplyConfiguration(new NameConquistasMap());
            modelBuilder.ApplyConfiguration(new GamesMap());
            modelBuilder.ApplyConfiguration(new TreinoMap());
            modelBuilder.ApplyConfiguration(new TreinoDiaSemanaMap());
            modelBuilder.ApplyConfiguration(new ExercicioMap());
            modelBuilder.ApplyConfiguration(new TreinoExercicioMap());


            base.OnModelCreating(modelBuilder);
        }
    }
}
