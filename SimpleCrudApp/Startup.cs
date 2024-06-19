using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.Domain;
using SimpleCrudApp.Service;

namespace SimpleCrudApp
{
   
    
        public class Startup
        {
            private readonly IConfiguration _configuration;
            public Startup(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public void ConfigureServices(IServiceCollection services)
            {
            services.AddDbContext<CitizenshipDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
            services.AddScoped<ICitizenshipService,CitizenshipService>();
               
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseStaticFiles();
                app.UseRouting();
            
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseEndpoints(endpoints =>
                {
                   endpoints.MapControllers();
                    endpoints.MapControllerRoute(
                     name: "default",
                    pattern: "{controller=Home}/{action=CreateCitizenship}/{id?}");

                });
            }
        }
    
}
