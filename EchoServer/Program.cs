using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using System.Text;

namespace Enterprisecoding.EchoServer
{
    class Program
    {
        static int Main(string[] args)
        {
            WebHost.CreateDefaultBuilder()
                .UseKestrel()
                .Configure(app =>
                {
                    app.Run(async context =>
                    {
                        var request = context.Request;
                        var response = context.Response;


                        if (!args.Any(arg => arg == "--noHeader"))
                        {
                            foreach (var header in request.Headers)
                            {
                                response.Headers.Add(header);
                            } 
                        }

                        var responseBody = args.FirstOrDefault(arg => arg.StartsWith("--response="));
                        if (!string.IsNullOrWhiteSpace(responseBody))
                        {
                            var responseBodyBytes = Encoding.UTF8.GetBytes(responseBody.Substring(11));
                            await response.Body.WriteAsync(responseBodyBytes);
                        }
                        else
                        {
                            await request.Body.CopyToAsync(response.Body);
                        }
                    });
                })
                .Build()
                .Run();

            return 0;
        }
    }
}
