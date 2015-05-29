using System.Collections.Generic;

namespace NCVIB.FileWatcher
{
    public class FileWatcherSettings
    {
        public FileWatcherSettings()
        {
            Handlers = new List<object>();
        }
        public string Folder { get; set; }
        public IList<object> Handlers { get; set; }
    }
}