namespace BlazorServer
{
    using Controller;
    using global::Utilities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Model;
    using Model.Configuration;
    using Utilities;
    using Syncfusion.Blazor;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IEventDispatcher, EventDispatcher>();
            services.AddScoped<IModel, Model>();
            services.AddScoped<IController, Controller>();

            services.AddSyncfusionBlazor();

            services.AddSingleton(Configuration.GetSection("ServiceConfiguration").Get<ServiceConfiguration>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //trial version
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDUwMjYzQDMxMzkyZTMxMmUzME5tQ2d6Y2wwQy8zSVJGRTBoaEdVOUdpSFc3RWRIZ2pWczJscmpSZHVCdTg9");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}