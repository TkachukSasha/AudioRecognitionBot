using AudioRecognition.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AudioRecognition.Core.Dal.Configurations
{
    public class VoiceMessageConfiguration : IEntityTypeConfiguration<VoiceMessage>
    {
        public void Configure(EntityTypeBuilder<VoiceMessage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Message).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.VoiceMessages).HasForeignKey(x => x.User.Id);
        }
    }
}
