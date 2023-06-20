using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Board.Domain;

namespace Board.Infrastucture.DataAccess.Contexts.Categories
{
    /// <summary>
    /// Конфигурация сущности категории.
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Domain.Category> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Created).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));

            builder.HasMany(s => s.Adverts).WithOne(s => s.Category).HasForeignKey(c => c.CategoryId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
