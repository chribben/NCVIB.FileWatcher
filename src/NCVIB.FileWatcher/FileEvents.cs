namespace NCVIB.FileWatcher
{
    public interface IFileEvent{}
    public class FileCreated : IFileEvent
    {
        public string FilePath { get; set; }
    };
}