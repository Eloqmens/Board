using Board.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastucture.DataAccess.Contexts.FavoriteAdverts
{
    public class FavovriteAdvertConfiguration : IEntityTypeConfiguration<FavoriteAdvert>
    {
        public void Configure(EntityTypeBuilder<Domain.FavoriteAdvert> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
