using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SaveYourSearchAPI.DbContexts;
using System.Web.Http.Cors;
using SaveYourSearchAPI.Extensions;

namespace SaveYourSearchAPI
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
            var connection = @"Server=tcp:naveenpatancheru.database.windows.net,1433;Initial Catalog=SaveYourSearch;Persist Security Info=False;User ID=naveenpatancheru;Password=Ericcartman9985;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        //    services.AddScoped<ISaveYourSearchRepository, SaveYourSearchContext>();
            services.AddDbContext<SaveYourSearchContext>(options =>
            {
                //  options.UseSqlServer(@"Server=.\NAVEENSSQL;Database=CourseLibraryDB;Trusted_Connection=True;");
                options.UseSqlServer(connection);
            });

            //Register swagger
            //services.AddSwaggerGen(c=>
            //{
            //    //   c.SchemaFilter<>();
            //    //  c.SwaggerDoc("5.0.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MainAPi", Version = "v1.0" });
            //    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            //});
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
         
         //   services.AddSwaggerDocumentation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseStaticFiles();
           
            //  app.UseSwagger();
            //app.UseSwaggerUI(c => {

            //    c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API");
            //}
            //);
              app.UseCors("CorsPolicy");
            //  app.UseSwaggerDocumentation();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");

            //    routes.MapSpaFallbackRoute(
            //        name: "spa-fallback",
            //        defaults: new { controller = "Home", action = "Index" });
            //});
        }
    }
}
