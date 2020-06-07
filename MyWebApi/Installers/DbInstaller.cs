
using MyWebApi.Installer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyWebApi.Services;
using Pomelo.EntityFrameworkCore.MySql;



namespace MyWebApi.Installers
{
    public class DbInstaller : IInstaller

    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Data.DataContext>(options =>
                options.UseMySql(
                     configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Data.DataContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IIngredientsService, IngredientsService>();

        }
    }
}
