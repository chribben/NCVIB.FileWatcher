using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NCVIB.FileWatcher
{
    internal class FileWatcherService
    {
        private readonly FileWatcherSettings _settings;

        public FileWatcherService(FileWatcherSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");
            _settings = settings;
        }

        public void Start()
        {
            var fw = new FileSystemWatcher(_settings.Folder)
            {
                NotifyFilter = NotifyFilters.FileName
            };
            var createdHandlers = _settings.Handlers.Where(h => h is Action<FileCreated>).Cast<Action<FileCreated>>();
            foreach (var createdHandler in createdHandlers)
            {
                fw.Created += (sender, args) => createdHandler(new FileCreated() { FilePath = args.FullPath });
            }
            fw.EnableRaisingEvents = true;
        }

        public void Stop()
        {
        }
    }
}