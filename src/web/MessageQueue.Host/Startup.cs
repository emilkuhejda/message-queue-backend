using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using MessageQueue.DataAccess;
using MessageQueue.Domain.Settings;
using MessageQueue.Host.Configuration;
using MessageQueue.Host.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MessageQueue.Host
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
            var appSettingsSection = Configuration.GetSection("ApplicationSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.Configure<AppSettings>(appSettingsSection);

            // Database connection
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(appSettings.ConnectionString, providerOptions => providerOptions.CommandTimeout(300)));

            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ApplicationModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Migrate database
            app.MigrateDatabase();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
