using AudioRecognition.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioRecognition.Core.Dal
{
    public class AudioRecognitionContext : DbContext
    {
        public DbSet<AppUser> User { get; set; }
        public DbSet<VoiceMessage> VoiceMessages { get; set; }

        public AudioRecognitionContext(DbContextOptions<AudioRecognitionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
