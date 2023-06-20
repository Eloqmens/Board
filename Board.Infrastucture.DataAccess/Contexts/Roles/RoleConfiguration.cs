using Board.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infrastucture.DataAccess.Contexts.Roles
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Domain.Role> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.RoleName).HasMaxLength(30).IsRequired();
        }
    }
}
