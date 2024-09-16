using Gymotivate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymotivate.Data.Map
{
    public class GamesMap : IEntityTypeConfiguration<GamesModel>
    {
        public void Configure(EntityTypeBuilder<GamesModel> builder)
        {
            builder.HasKey(x => x.GamesId);
            builder.HasOne(x => x.Usuario);
        }
    }
}
