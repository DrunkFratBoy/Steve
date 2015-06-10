using System;
using System.Net;
using System.IO;
using System.Security.Permissions;

namespace ConsoleApplicationGRACE
{
    public Wprogram ()

    public class Watcher
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run()
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
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Changed;
            watcher.Deleted += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;

            // Begin watching
            watcher.EnableRaisingEvents = true;

            // Wait for users to quit the program
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }
    }

    // DOWNLOAD

    private void Download(string filePath, string fileName)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://172.16.100.56");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("test", "test");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();
        }

        private void Upload (string filePath, string fileName)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://172.16.100.56");
            request.Method = WebRequestMethods.Ftp.UploadFile;
        }

        private void ListDirectoryItems()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://172.16.100.56");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            request.Credentials = new NetworkCredential("test", "test");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);
         
            reader.Close();
            response.Close();
        }


        static void Main(string[] args)
        {
            // List contents of FTP Directory

            Watcher watcher = new Watcher();
            Program program = new Program();
            watcher.Run();
            Console.WriteLine("Downloading..... Please wait....");
            // List contents of FTP Directory
            program.ListDirectoryItems();
            // if there is items in the directory download those items
            program.Download("ftp://www.contoso.com/test.htm", "test.htm");
            Console.WriteLine("File Downloaded");



        }
    }
}
