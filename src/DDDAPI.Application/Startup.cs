using System;
using DDDAPI.Application.Dependency;
using DDDAPI.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace application
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
            Config.ConfigContext(services);
            Config.ConfigRepository(services);
            Config.ConfigServices(services);
            Config.ConfigToken(services, Configuration);
            Config.ConfigSwagger(services);
            Config.ConfigAutoMapper(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s => {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "DDDAPI");
                s.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Etapa de realização de migração automática
            if (Environment.GetEnvironmentVariable("MIGRATION").ToLower() == "true".ToLower())
            {
                using var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();
                using var context = service.ServiceProvider.GetService<ContextDB>();
                context.Database.Migrate();
            }
        }
    }
}
