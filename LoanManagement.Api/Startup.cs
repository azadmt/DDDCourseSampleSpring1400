using Autofac;
using Framework.Application;
using Framework.Configuration.Autofac;
using Framework.Core.Persistence;
using Framework.Persistence.Ef;
using Loanmanagement.Application.Contract;
using Loanmanagement.Application.LoanHandler;
using LoanManagement.Domain.LoanAggregate;
using LoanManagement.Persistence;
using LoanManagement.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace LoanManagement.Api
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
            services.AddDbContext<LoanManagementDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("WriteConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LoanManagement.Api", Version = "v1" });
            });

         
            }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Framework.Configuration.Autofac.Configurator.Config(builder);

            builder.RegisterType<ApproveLoanCommandHandler>()
                .As<ICommandHandler<ApproveLoanCommand>>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(LoanRepository)))
                  .AssignableTo<IRepository>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterType<CreateLoanCommandHandler>()
            .As<ICommandHandler<CreateLoanCommand>>()
            .InstancePerLifetimeScope();

            builder.RegisterType<LoanManagementDbContext>()
           .As<IUnitOfWork>()
           .InstancePerLifetimeScope();

 //           builder.RegisterType<LoanRepository>()
 //            .As<ILoanRepository>()
 //            .InstancePerLifetimeScope();

 //           builder.RegisterType<>()
 //.As<ILoanRepository>()
 //.InstancePerLifetimeScope();
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoanManagement.Api v1"));
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
