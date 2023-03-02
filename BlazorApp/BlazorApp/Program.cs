using BlazorApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<IFoodService, FastFoodService>();
            builder.Services.AddSingleton<PaymentService>();

            // 3가지 모드
            builder.Services.AddSingleton<SingletonService>(); // 서버가 뜰때 한번 만들어짐. 변동이 없고 모두에게 똑같은 정보를 보여줘야 할때 사용(전역)
            builder.Services.AddTransient<TransientService>(); // 요청 할때마다 계속 
            builder.Services.AddScoped<ScopedService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}