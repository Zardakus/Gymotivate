using Gymotivate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymotivate.Data.Map
{
    public class NameConquistasMap : IEntityTypeConfiguration<NameConquistasModel>
    {
        public void Configure(EntityTypeBuilder<NameConquistasModel> builder)
        {
            builder.HasKey(x => x.NameConquistasId);
            builder.HasOne(x => x.GrupoConquistas);
        }
    }
}
