using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace InformationalEndpoint
{
    /// <summary>
    /// Provides extension methods for registering an information endpoint to a <see cref="IEndpointRouteBuilder"/>.
    /// </summary>
    public class Informational
    {
        // <summary>
        /// Enable the informational endpoint (/info), which gives basic information about the program.
        /// </summary>
        /// <param name="endpoints">The <see cref="IEndpointRouteBuilder"/>.</param>
        public static void Map(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/info", context =>
            {
                var env = context.Request.HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>() 
                    ?? throw new ArgumentNullException(nameof(IWebHostEnvironment), "An IWebHostEnvironment is expected.");

                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/json; charset=utf-8";

                var options = new JsonWriterOptions { Indented = true };
                using var writer = new Utf8JsonWriter(context?.Response?.BodyWriter, options);

                writer.WriteStartObject();
                writer.WriteString("Server", Environment.MachineName ?? "N/A");
                writer.WriteString("OS", Environment.OSVersion.VersionString ?? "N/A");
                writer.WriteString("User", Environment.UserName ?? "N/A");
                writer.WriteString("Path", env.ContentRootPath.ToUpper() ?? "N/A");
                writer.WriteString("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRIONMENT") ?? "N/A");
                writer.WriteString("Runtime", RuntimeInformation.FrameworkDescription ?? "N/A");
                writer.WriteString("Assembly", Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "N/A");
                writer.WriteEndObject();

                return Task.CompletedTask;
            });
        }
    }
}
