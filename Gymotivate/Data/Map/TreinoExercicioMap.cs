using Gymotivate.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Data.Map
{
    public class TreinoExercicioMap : IEntityTypeConfiguration<TreinoExercicioModel>
    {
        public void Configure(EntityTypeBuilder<TreinoExercicioModel> builder)
        {
            builder.HasKey(x => x.TreinoExercicioId);
            builder.HasOne(x => x.TreinoDiaSemana);
            builder.HasOne(x => x.Exercicio);
        }
    }
}
