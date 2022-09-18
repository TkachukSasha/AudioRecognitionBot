using AudioRecognition.Core.Abstractions;

namespace AudioRecognition.Core.Entities
{
    public class VoiceMessage : BaseEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
