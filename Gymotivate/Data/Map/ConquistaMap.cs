using Gymotivate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymotivate.Data.Map
{
    public class ConquistaMap : IEntityTypeConfiguration<ConquistasModel>
    {
        public void Configure(EntityTypeBuilder<ConquistasModel> builder)
        {
            builder.HasKey(x => x.ConquistasId);
            builder.HasOne(x => x.Usuario);
            builder.HasOne(x => x.NameConquistas);
        }
    }
}
