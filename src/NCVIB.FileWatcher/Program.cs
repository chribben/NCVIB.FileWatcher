using System;
using System.Linq;
using Topshelf;

namespace NCVIB.FileWatcher
{
    /// <summary>
    /// Generic file watcher service for NCVIB.
    /// <example> 
    /// <code>
    /// FileWatcher.Configuration()
    ///       .Watch(@"c:\temp")
    ///       .HandlerFor&lt;FileCreated&gt;(created => Console.WriteLine(created.FilePath))
    ///        FileWatcher.Start();
    /// </code>
    /// </example>
    /// </summary>
    public class FileWatcher
    {
        private FileWatcher(){}
        private static IFluentConfiguration _fluentConfiguration;
        private static readonly FileWatcherSettings FileWatcherSettings = new FileWatcherSettings();
        /// <summary>
        /// Configuration for the file watcher
        /// </summary>
        /// <returns>
        /// A reference to the file watcher configuration object
        /// </returns>
        public static IFluentConfiguration Configuration()
        {
            return _fluentConfiguration ?? (_fluentConfiguration = new FluentConfiguration(FileWatcherSettings));
        }
        /// <summary>
        /// Starts the file watcher service using the given configuration
        /// </summary>
        public static void Start()
        {
            if (String.IsNullOrEmpty(FileWatcherSettings.Folder))
            {
                throw new Exception("No folder to watch!");
            }
            if (!FileWatcherSettings.Handlers.Any())
            {
                throw new Exception("No file event handlers specified!");
            }
            Main(null);
        }
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<FileWatcherService>(s =>
                {
                    s.ConstructUsing(name => new FileWatcherService(FileWatcherSettings));
                    s.WhenStarted(fw => fw.Start());
                    s.WhenStopped(fw => fw.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("NCVIB FileWatcher Service");
                x.SetDisplayName("NCVIB.FileWatcher");
                x.SetServiceName("NCVIB.FileWatcher");
            });
        }
    }
}
