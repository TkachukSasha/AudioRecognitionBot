using AudioRecognition.Core.Abstractions;

namespace AudioRecognition.Core.Entities
{
    public class User : BaseEntity, IBaseEntity
    {
        public User()
        {
            VoiceMessages = new HashSet<VoiceMessage>();
        }

        public User(long id,
                    string userName)
        {
            Id = id;
            UserName = userName;
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public ICollection<VoiceMessage> VoiceMessages { get; set; }
    }
}
