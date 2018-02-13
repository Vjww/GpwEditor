using System.Reflection;
using App.BaseGameEditor.Application.Maps.AutoMapper.Reference;
using App.DependencyInjection.Autofac;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.WebService
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
            services.AddMvc();

            // TODO: This is added
            // TODO: AutoMapper and extensions are added via nuget
            services.AddAutoMapper(Assembly.GetAssembly(typeof(ApplicationMaps)));
        }

        // TODO: This is added for autofac
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to AddAutofac in the Program.Main
            // method or this won't be called.
            builder.RegisterModule(new AutofacModule());

            // TODO: Currently required as possibly nothing implements from ILoggerFactory yet
            builder.RegisterType<LoggerFactory>().As<ILoggerFactory>().UsingConstructor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}