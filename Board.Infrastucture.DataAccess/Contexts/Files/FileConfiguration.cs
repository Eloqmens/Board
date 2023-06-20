using Board.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infrastucture.DataAccess.Contexts.Files
{
    /// <summary>
    /// Конфигурация сущности Файла.
    /// </summary>
    public class FileConfiguration : IEntityTypeConfiguration<Domain.File>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Domain.File> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(256).IsRequired();
            builder.Property(a => a.ContentType).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Created).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));
        }
    }
}
