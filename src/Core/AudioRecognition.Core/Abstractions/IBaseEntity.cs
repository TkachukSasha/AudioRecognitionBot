namespace AudioRecognition.Core.Abstractions
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        string UserName { get; set; }
    }
}
