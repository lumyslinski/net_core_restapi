using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace RestApp
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BuildWeb(args).Build().Run();
        }

        /// <summary>
        /// CreateWebHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder BuildWeb(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .CaptureStartupErrors(true)
                .UseSetting("detailedErrors", "true");
                // TODO:
                // add proper cross platform https support
                // disable here https with self signed certificate
                // because of bug in the latest version of net core
                // dbug: HttpsConnectionAdapter[1]
                // Failed to authenticate HTTPS connection.
                // System.IO.IOException: Authentication failed because the remote party has closed the transport stream.
                //.UseKestrel(options =>
                //{
                //    options.Listen(IPAddress.Any, 5000);
                //});
    }
}
