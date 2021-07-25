using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SeguradoraDeVida
{
    public class Program
    {
        #region M�todos

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        #endregion M�todos
    }
}