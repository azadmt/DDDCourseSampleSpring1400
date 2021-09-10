using Autofac;
using MassTransit;
using MassTransit.AutofacIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using QueryModel.Data;
using QueryModel.Handler.Customer;
using QueryModel.Handler.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QueryModel.Api
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

            services.AddControllers();
            services.AddDbContext<QueryDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ReadConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QueryModel.Api", Version = "v1" });
            });

            services.AddMassTransit(x =>
            {
                // add all consumers in the specified assembly
                x.AddConsumers(Assembly.GetAssembly(typeof(LoanRequestedEventHandler)));
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost");

                    cfg.ReceiveEndpoint("customer_create", ec =>
                    {
                        // Configure a single consumer
                        ec.ConfigureConsumer<CustomerCreatedEventHandler>(context);

                        //// configure all consumers
                        //ec.ConfigureConsumers(context);

                        //// configure consumer by type
                        //ec.ConfigureConsumer(typeof(ConsumerOne));
                    });

                    // or, configure the endpoints by convention
                    cfg.ConfigureEndpoints(context);
                });

            });

            services.AddMassTransitHostedService();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.AddMassTransit(x =>
            //{
            //    // add all consumers in the specified assembly
            //    x.AddConsumers(Assembly.GetAssembly(typeof(LoanRequestedEventHandler));
            //        x.UsingRabbitMq((context, cfg) =>
            //        {
            //            cfg.Host("localhost");

            //            cfg.ReceiveEndpoint("customer_create", ec =>
            //            {
            //                // Configure a single consumer
            //                ec.ConfigureConsumer<CustomerCreatedEventHandler>(context);

            //                //// configure all consumers
            //                //ec.ConfigureConsumers(context);

            //                //// configure consumer by type
            //                //ec.ConfigureConsumer(typeof(ConsumerOne));
            //            });

            //            // or, configure the endpoints by convention
            //            cfg.ConfigureEndpoints(context);
            //        });              

            //});
            //Framework.Configuration.Autofac.Configurator.Config(builder);

            //        builder.RegisterType<ApproveCustomerCommandHandler>()
            //            .As<ICommandHandler<ApproveCustomerCommand>>()
            //            .InstancePerLifetimeScope();

            //        builder.RegisterType<CreateCustomerCommandHandler>()
            //.As<ICommandHandler<CreateCustomerCommand>>()
            //.InstancePerLifetimeScope();

            //        builder.RegisterType<CustomerManagementDbContext>()
            //       .As<IUnitOfWork>()
            //       .InstancePerLifetimeScope();

            //        builder.RegisterType<CustomerService>()
            //            .As<ICustomerService>()
            //            .InstancePerLifetimeScope();

            //        builder.RegisterType<CustomerRepository>()
            //         .As<ICustomerRepository>()
            //         .InstancePerLifetimeScope();


            //        builder.RegisterType<AutofacCommandBus>()
            //         .As<ICommandBus>()
            //         .InstancePerLifetimeScope();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QueryModel.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeDatabase(app);
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            try
            {
                using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    scope.ServiceProvider.GetRequiredService<QueryDbContext>().Database.Migrate();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
    }
}
