using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using New_Application.Infrastructure;
using New_Application.Repository;
using Newtonsoft.Json;

namespace New_Application {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<NewApplicationDbContext> (options => {
                options.UseSqlServer (Configuration.GetConnectionString ("ApplicationConnection"));
            });
            services.AddMvc ()
                .AddJsonOptions (opt => {
                    opt.SerializerSettings.ReferenceLoopHandling =
                        ReferenceLoopHandling.Ignore;
                });
            services.AddScoped<IEmployeeRepository, EmployeeRepository> ();
            services.AddScoped<IDepartmentRepository, DepartmentRepository> ();
            services.AddAutoMapper ();
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole ();

            loggerFactory.AddDebug (LogLevel.Information);
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseMvc ();
        }
    }
}