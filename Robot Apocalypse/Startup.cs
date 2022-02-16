using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Robot_Apocalypse.Abstractions;
using Robot_Apocalypse.BusinessLayer;
using Robot_Apocalypse.DataLayer;
using Robot_Apocalypse.DataLayer.Entities;
using System.IO;
using System.Reflection;

namespace Robot_Apocalypse
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
            services.AddDbContext<SurvivorContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:Robot_ApocalypseDB"]));
            services.AddScoped<ISurvivorRepository<Survivor>, SurvivorDataAccess>();
            services.AddScoped<IDataRepository<Location>, LocationDataAccess>();
            services.AddScoped<IDataRepository<ContaminationReport>, ContaminationReportDataAccess>();

            services.AddScoped<SurvivorBusinessLayer>();
            services.AddScoped<RegistrationBusinessLayer>();

            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(XmlCommentsFilePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API");
            });
        }
        //This method gets called by the ConfigureServices, Use this method to geth the file path for the static XmlCommentFilePath
        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
