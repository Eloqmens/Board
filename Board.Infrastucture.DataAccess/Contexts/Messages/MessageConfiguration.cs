using Board.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastucture.DataAccess.Contexts.Messages
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Domain.Message> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Containment).HasMaxLength(256).IsRequired();
            builder.HasOne(x => x.Sender).WithMany(z => z.SendedMessages).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Reciever).WithMany(z => z.RecievedMessages).HasForeignKey(x => x.RecieverId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
