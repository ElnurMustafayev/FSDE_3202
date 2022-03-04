using System.Net;

string fileDirection = "FILENAME.jpg";
FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(@$"ftp://212.85.109.51/{fileDirection}");

request.Method = WebRequestMethods.Ftp.DownloadFile;

//request.Credentials = new NetworkCredential("login", "password");
//request.EnableSsl = false;

using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
using Stream stream = response.GetResponseStream();
Console.WriteLine(response.WelcomeMessage);
using FileStream fileStream = new FileStream("test.jpg", FileMode.Create);
Console.WriteLine(response.StatusDescription);
byte[] buffer = new byte[1024];
int size = 0;
while((size = stream.Read(buffer, 0, buffer.Length)) > 0) {
    Console.WriteLine(response.StatusDescription);
    fileStream.Write(buffer, 0, size);
}