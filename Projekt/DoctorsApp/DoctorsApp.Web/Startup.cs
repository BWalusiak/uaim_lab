namespace DoctorsApp.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Application.DataServiceClients;
    using Application.Queries;
    using Configuration;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoctorsApp", Version = "v1" });
            });
            services.AddHttpClient();
            services.AddTransient<IDoctorsQueryHandler, DoctorsQueryHandler>();
            services.AddTransient<IPatientsQueryHandler, PatientsQueryHandler>();
            services.AddTransient<ISelectorQueryHandler, SelectorQueryHandler>();
            services.AddTransient<IPatientsDataServiceClient, PatientsDataServiceClient>();
            services.AddTransient<IDoctorsDataServiceClient, DoctorsDataServiceClient>();

            services.AddSingleton(Configuration.GetSection("ServiceConfiguration").Get<ServiceConfiguration>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoctorsApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}