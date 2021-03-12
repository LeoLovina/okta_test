using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebClient.Models;
using WebClient.Services;

namespace WebClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<OktaSettings>(Configuration.GetSection("Okta"));
            services.AddSingleton<ITokenService, OktaTokenService>();
            services.AddTransient<IApiService, SimpleApiService>();

            // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
            services.AddHttpClient("ApiHttpClient", config =>
            {
                config.BaseAddress = new Uri(Configuration["Api:BaseUrl"]);
            });
            //services.AddHttpClient<ITokenService, OktaTokenService>(config =>
            //{
            //    var client_id = Configuration["Okta:ClientId"];
            //    var client_secret = Configuration["Okta:ClientSecret"]; 
            //    var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");
            //    config.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));
            //    config.BaseAddress = new Uri(Configuration["Okta:TokenUrl"]);
            //});
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
