using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using student_management_system.Data;
using student_management_system.Services;

namespace student_management_system
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

            builder.Services.AddScoped(sp =>
             new HttpClient
             {
                 BaseAddress = new Uri(builder.Configuration.GetValue<string>("ServerUrl"))
             });
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<HideMessagesAfterDelay>();

            //authentication services
            builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<CustomAuthenticationStateProvider>();
            builder.Services.AddAuthenticationCore();
            //for local storage
            builder.Services.AddBlazoredLocalStorage();
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