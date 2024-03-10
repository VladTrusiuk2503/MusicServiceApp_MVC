using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartDialog.Data;
using StartDialog.Models;
using StartDialog.Services;

namespace StartDialog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTransient<ISongService, SongService>();

            services.AddDbContext<SongDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("SharedConnection")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AdminSong}/{action=Index}/{id?}");
            });
        }
    }
}
