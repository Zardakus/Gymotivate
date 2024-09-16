using Gymotivate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gymotivate.Data.Map
{
    public class GrupoConquistaMap : IEntityTypeConfiguration<GrupoConquistasModel>
    {
        public void Configure(EntityTypeBuilder<GrupoConquistasModel> builder)
        {
            builder.HasKey(x => x.GroupId);
        }
    }
}
