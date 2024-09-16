using Gymotivate.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Data.Map
{
    public class TreinoMap : IEntityTypeConfiguration<TreinoModel>
    {
        public void Configure(EntityTypeBuilder<TreinoModel> builder)
        {
            builder.HasKey(x => x.TreinoId);
            builder.HasOne(x => x.User);

        }
    }
}
