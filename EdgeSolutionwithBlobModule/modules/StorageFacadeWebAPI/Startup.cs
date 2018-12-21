using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorageFacadeWebAPI.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace StorageFacadeWebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Storage Facade API", Version = "V1" });
                options.OperationFilter<FormFileSwaggerFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Storage Facade API v1");
            });
            app.UseMvc();            
        }
    }
}