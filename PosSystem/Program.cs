using Microsoft.Extensions.Configuration;
using PosSystem.Database;
using Microsoft.EntityFrameworkCore;

namespace PosSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //dependency resolve kore ekhane...
            builder.Services.AddDbContext<PosSystemDbContext>(opt => opt.UseSqlServer("Server=DESKTOP-D63RLDO;Database=PosSystemDB;User Id=sa;Password=Abjt@8632;MultipleActiveResultSets=True"));

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}