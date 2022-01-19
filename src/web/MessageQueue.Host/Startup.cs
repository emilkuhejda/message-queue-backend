using Autofac;
using MessageQueue.DataAccess;
using MessageQueue.Domain.Settings;
using MessageQueue.Host.Configuration;
using MessageQueue.Host.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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

            // Swagger
            services.AddSwaggerGen(configuration =>
            {
                configuration.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MessageQueue API",
                    Version = "v1"
                });

                configuration.EnableAnnotations();

                configuration.CustomSchemaIds(tpye =>
                {
                    const string ending = "OutputModel";
                    var returnedValue = tpye.Name;
                    if (returnedValue.EndsWith(ending, StringComparison.OrdinalIgnoreCase))
                        returnedValue = returnedValue.Replace(ending, string.Empty, StringComparison.OrdinalIgnoreCase);

                    return returnedValue;
                });

                configuration.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                configuration.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
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

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MessageQueue API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
