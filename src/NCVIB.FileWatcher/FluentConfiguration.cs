using System;
namespace NCVIB.FileWatcher
{
    public class FluentConfiguration : IFluentConfiguration
    {
        private readonly FileWatcherSettings _fileWatcherSettings;
        public FluentConfiguration(FileWatcherSettings fileWatcherSettings)
        {
            _fileWatcherSettings = fileWatcherSettings;
        }
        public IFluentConfiguration Watch(string folder)
        {
            if (!String.IsNullOrEmpty(_fileWatcherSettings.Folder))
                throw new Exception("Folder to watch can only be set once!");
            _fileWatcherSettings.Folder = folder;
            return this;
        }
        public IFluentConfiguration HandlerFor<T>(Action<T> action) where T : IFileEvent
        {
            _fileWatcherSettings.Handlers.Add(action);
            return this;
        }
    }
}