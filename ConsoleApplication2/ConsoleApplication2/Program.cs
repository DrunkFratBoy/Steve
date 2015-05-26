using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
      
  public Program()
        {
        }

        // DOWNLOAD

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

        private void Upload (string filePath, string fileName)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://something.com");
            request.Method = WebRequestMethods.Ftp.UploadFile;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Downloading..... Please wait....");
            program.Download("ftp://www.contoso.com/test.htm", "test.htm");
            Console.WriteLine("File Downloaded");
        }
    }
}
