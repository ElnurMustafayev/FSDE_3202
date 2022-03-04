using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server {
    public class Program {
        public static async Task Main() {
            if(false) {
                TcpListener server = new TcpListener(8080);
                server.Start(10);
                TcpClient client = await server.AcceptTcpClientAsync();

                using(var reader = new StreamReader(client.GetStream())) {
                    string responseTxt = await reader.ReadToEndAsync();
                    Console.WriteLine($"Response: {responseTxt}");
                }
            }

            if(true) {
                HttpListener server = new HttpListener();
                server.Prefixes.Add(@"http://*:80/");
                server.Start();
                Console.WriteLine("Server Started...");

                while(true) {
                    var context = await server.GetContextAsync();

                    var url = context.Request.RawUrl;
                    var @params = context.Request.QueryString;

                    var routs = url.Split('/', StringSplitOptions.RemoveEmptyEntries);

                    foreach(var rout in routs)
                        Console.WriteLine(rout);

                    if(routs.FirstOrDefault().ToLower().Trim() == "user") {
                        using(StreamWriter responseWriter = new StreamWriter(context.Response.OutputStream)) {
                            context.Response.StatusCode = (int)HttpStatusCode.OK;

                            await responseWriter.WriteAsync("User!!!");
                            await responseWriter.FlushAsync();
                        }
                        continue;
                    }
                    else {
                        string responseTxt = null;

                        using(StreamReader requestReader = new StreamReader(context.Request.InputStream)) {
                            responseTxt = await requestReader.ReadToEndAsync();

                            Console.WriteLine($"Method Type: '{context.Request.HttpMethod}'");
                            Console.WriteLine($"Request: '{responseTxt}'");
                        }

                        using(StreamWriter responseWriter = new StreamWriter(context.Response.OutputStream)) {
                            context.Response.StatusCode = (int)HttpStatusCode.OK;

                            var response = new {
                                Request = responseTxt,

                                Status = (int)HttpStatusCode.OK,

                                DueDate = DateTime.Now,

                                Body = new {
                                    Message = "Operation end successfully!"
                                },
                            };

                            string responseJSON = JsonSerializer.Serialize(response);

                            await responseWriter.WriteAsync(responseJSON);
                            await responseWriter.FlushAsync();
                        }
                    }
                }
            }
        }
    }
}
