namespace AudioRecognition.Core.Abstractions
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        string UserName { get; set; }
    }
}
