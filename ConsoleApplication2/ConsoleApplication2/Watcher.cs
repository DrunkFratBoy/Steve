using System;
using System.IO;
using System.Security.Permissions;

namespace ConsoleApplication2
{
    public class Watcher
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            string[] args = System.Environment.GetCommandLineArgs();

            // if the directory is not specified, exit the program
            if (args.Length != 2)
            {

                Console.WriteLine("Usage: Watcher.exe (directory)");
                return;
            }

            // Create the file watcher and set its properties
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = args[1];

            // Watch for changes
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            // only watch text files for now.
            watcher.Filter = ".txt";

            // Event handlers
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new FileSystemEventHandler(OnChanged);

            // Begin watching
            watcher.EnableRaisingEvents = true;

            // Wait for users to quit the program
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        // Define the event handlers
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }


    }

  

}