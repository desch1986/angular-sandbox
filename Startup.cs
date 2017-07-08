using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using AngularSandbox.Models;
using AngularSandbox.Repositories;
using AngularSandbox.Repositories.Entities;
using AngularSandbox.Repositories.EntityFramework;

namespace AngularSandbox
{
    public class Startup
    {
        private Container _container;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            _container = new Container();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            SetupDependencyInjection(app);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }

        private void SetupDependencyInjection(IApplicationBuilder app)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            _container.RegisterSingleton<AutoMapper.IConfigurationProvider>(new MapperConfiguration(InitializeAutoMapper));
            _container.Register<IMapper>(() => new Mapper(_container.GetInstance<AutoMapper.IConfigurationProvider>()));

            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);

            _container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());
            
            _container.Register<IDbContext, BasicDataContext>();
            _container.Register<ICrudRepository<ToDoItem>, CrudRepository<ToDoItem>>();
        }

        private void InitializeAutoMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<ToDoItem, ToDoItemDto>()
                  .ReverseMap();
        }
    }
}
