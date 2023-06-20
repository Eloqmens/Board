using Board.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastucture.DataAccess.Contexts.Comments
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Domain.Comment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Text).HasMaxLength(256).IsRequired();
            builder.HasOne(x => x.Sender).WithMany(z => z.SendedComments).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.User).WithMany(z => z.RecievedComments).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
