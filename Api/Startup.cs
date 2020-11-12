using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Domain.Emails.Data;
using  Domain.Emails.Model.Configuration;
using  Domain.Emails.Repositories;
using  Domain.Emails.Services;
using  Infrastructure.Filters;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Codibly
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
            services.AddMvcCore(options =>
            {

                options.Filters.Add(typeof(HttpGlobalExceptionFilter));

            })
            .AddApiExplorer()
            .AddDataAnnotations()
            .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddHttpContextAccessor();

            services.AddControllers();


            var domainAssembly = typeof(Domain.C).Assembly;

            services.AddMediatR(domainAssembly);
            services.AddFluentValidation(new[] { domainAssembly });

            services.AddTransient<IEmailsRepository, EmailsRepository>();
            services.AddTransient<IEmailsService, EmailsService>();

            services.AddDbContext<EmailsDataContext>(options => options.UseInMemoryDatabase(databaseName: "Emails"));


            // configure strongly typed settings object
            var emailSettingsSection = Configuration.GetSection("EmailSettings");
            services.Configure<EmailConfiguration>(emailSettingsSection);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
