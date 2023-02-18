using Dziennik_Zadan.Models;
using Dziennik_Zadan.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

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
            builder.Services.AddTransient<IZadaniaRepository,ZadaniaRepository>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Zadania}/{action=Index}/{id?}");

            app.Run();
        }
    }
}