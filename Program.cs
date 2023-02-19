using Dziennik_Zadan.Models;
using Dziennik_Zadan.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dziennik_Zadan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<DziennikZadanContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DziennikZadanDatabase")));

            builder.Services.AddIdentityCore<LogowanieUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<DziennikZadanContext>();
            builder.Services.AddTransient<IZadaniaRepository, ZadaniaRepository>();

            var app = builder.Build(); 

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Zadania}/{action=Indexx}/{id?}");

            app.Run();
        }
    }
}