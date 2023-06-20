using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infrastucture.DataAccess.Contexts.Users
{
    /// <summary>
    /// Конфигурация сущности объявления.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<Domain.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Login).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Created).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));
            builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(f => f.RoleId);
        }
    }
}
