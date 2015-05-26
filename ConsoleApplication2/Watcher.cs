using System;
using System.IO;
using System.Security.Permissions;

public class Watcher
{
	[PermissionSet(SecurityAction.Demand, Name ="FullTrust")]
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

}
