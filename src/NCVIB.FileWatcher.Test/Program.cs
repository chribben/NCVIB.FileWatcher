using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCVIB.FileWatcher.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWatcher.Configuration()
                .Watch(@"c:\temp")
                .HandlerFor<FileCreated>(created => Console.WriteLine(created.FilePath))
                .HandlerFor<FileCreated>(created => Console.WriteLine(created.FilePath));
            FileWatcher.Start();
        }
    }
}
