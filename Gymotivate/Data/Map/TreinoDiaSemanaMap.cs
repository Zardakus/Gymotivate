using Gymotivate.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Data.Map
{
    public class TreinoDiaSemanaMap : IEntityTypeConfiguration<TreinoDiaSemanaModel>
    {
        public void Configure(EntityTypeBuilder<TreinoDiaSemanaModel> builder)
        {
            builder.HasKey(x => x.TreinoDiaSemanaId);
            builder.HasOne(x => x.Treino);

        }
    }
}
