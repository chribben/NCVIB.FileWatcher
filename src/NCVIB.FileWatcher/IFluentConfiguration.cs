using System;

namespace NCVIB.FileWatcher
{
    public interface IFluentConfiguration
    {
        IFluentConfiguration Watch(string folder);
        IFluentConfiguration HandlerFor<T>(Action<T> action) where T : IFileEvent;
    }
}