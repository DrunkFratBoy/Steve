using System;
using System.Net;
using System.IO;

namespace ConsoleApplicationGRACE
{
    class Program
    {
        public Program() { }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Uploading... Please wait...");

            program.ListDirectoryItems();
            program.Upload("ftp://test.com", "test.htm");
            Console.WriteLine("File Uploaded");
        }

        private void Download(string filePath, string fileName)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://50.62.234.1");
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

        private void Upload(string filePath, string fileName)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://something.com");
            request.Method = WebRequestMethods.Ftp.UploadFile;
        }

        private void ListDirectoryItems()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://something.com");
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
    }
}
