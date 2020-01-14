using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using System.Text;
using System;

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

                        var noHeader = Environment.GetEnvironmentVariable("REPLY_HEADERS");
                        var responseBody = Environment.GetEnvironmentVariable("RESPONSE_BODY");


                        if (string.IsNullOrWhiteSpace(noHeader))
                        {
                            foreach (var header in request.Headers)
                            {
                                response.Headers.Add(header);
                            } 
                        }

                        if (string.IsNullOrWhiteSpace(responseBody))
                        {
                            await request.Body.CopyToAsync(response.Body);
                        }
                        else
                        {
                            var responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);
                            await response.Body.WriteAsync(responseBodyBytes);
                        }
                    });
                })
                .Build()
                .Run();

            return 0;
        }
    }
}
