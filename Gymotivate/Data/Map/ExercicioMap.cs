using Gymotivate.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Data.Map
{
    public class ExercicioMap : IEntityTypeConfiguration<ExercicioModel>
    {
        public void Configure(EntityTypeBuilder<ExercicioModel> builder)
        {
            builder.HasKey(x => x.ExercicioId);
        }
    }
}
