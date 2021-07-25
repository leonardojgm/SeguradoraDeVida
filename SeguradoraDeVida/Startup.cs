using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Service;

namespace SeguradoraDeVida
{
    public class Startup
    {
        #region Propriedades

        public IConfiguration Configuration { get; }

        #endregion Propriedades

        #region Construtores

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion Construtores

        #region Métodos

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddRazorPages();

            //Interface e Repositório
            services.AddSingleton<IApoliceRepository, ApoliceRepository>();
            services.AddSingleton<IApoliceRepository, ApoliceRepository>();
            services.AddSingleton<IVidaRepository, VidaRepository>();

            //Interface Serviço
            services.AddSingleton<IApoliceService, ApoliceService>();
            services.AddSingleton<IApoliceVidaService, ApoliceVidaService>();
            services.AddSingleton<IVidaService, VidaService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            UpdateDatabase(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            using Context context = serviceScope.ServiceProvider.GetService<Context>();

            context.Database.Migrate();
        }

        #endregion Métodos
    }
}