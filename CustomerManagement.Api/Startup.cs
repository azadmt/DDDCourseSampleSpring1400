using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CustomerManagement.ApplicationService.Contract.DataContract;
using CustomerManagement.ApplicationService.Contract.ServiceContract;
using CustomerManagement.ApplicationService.Customer;
using CustomerManagement.Domain.Customer;
using CustomerManagement.Perdidtence.Ef;
using Framework.Application;
using Framework.Configuration.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CustomerManagement.Api
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
            services.AddMvc().AddControllersAsServices();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerManagement.Api", Version = "v1" });
            });

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Framework.Configuration.Autofac.Configurator.Config(builder);

            builder.RegisterType<ApproveCustomerCommandHandler>()
                .As<ICommandHandler<ApproveCustomerCommand>>()
                .InstancePerLifetimeScope();

                    builder.RegisterType<CreateCustomerCommandHandler>()
            .As<ICommandHandler<CreateCustomerCommand>>()
            .InstancePerLifetimeScope();

            builder.RegisterType<CustomerService>()
                .As<ICustomerService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>()
             .As<ICustomerRepository>()
             .InstancePerLifetimeScope();


            builder.RegisterType<AutofacCommandBus>()
             .As<ICommandBus>()
             .InstancePerLifetimeScope();


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerManagement.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
