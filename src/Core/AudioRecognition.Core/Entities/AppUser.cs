using AudioRecognition.Core.Abstractions;

namespace AudioRecognition.Core.Entities
{
    public class AppUser : BaseEntity, IBaseEntity
    {
        public AppUser()
        {
            VoiceMessages = new HashSet<VoiceMessage>();
        }

        public AppUser(int id,
                    string userName)
        {
            Id = id;
            UserName = userName;
        }

        public int Id { get; set; }
        public long ChatId { get; set; }
        public string UserName { get; set; }
        public ICollection<VoiceMessage> VoiceMessages { get; set; }
    }
}
