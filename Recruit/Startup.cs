using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Recruit.Models;

namespace Recruit
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
            services.AddControllersWithViews();
            services.AddKendo();
            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<Candidate>, Recruit.BusinessAccessLayer.CandidateService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork,Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<Candidate>, Recruit.DataAccessLayer.CandidateRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();

            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<Location>, Recruit.BusinessAccessLayer.LocationService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork, Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<Location>, Recruit.DataAccessLayer.LocationRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();

            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<Employee>, Recruit.BusinessAccessLayer.EmployeeService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork, Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<Employee>, Recruit.DataAccessLayer.EmployeeRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();

            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<InterviewDetail>, Recruit.BusinessAccessLayer.InterviewDetailService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork, Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<InterviewDetail>, Recruit.DataAccessLayer.InterviewDetailRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();

            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<InterviewRoundStatus>, Recruit.BusinessAccessLayer.InterviewRoundStatusService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork, Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<InterviewRoundStatus>, Recruit.DataAccessLayer.InterviewRoundStatusRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();

            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<Owner>, Recruit.BusinessAccessLayer.OwnerService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork, Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<Owner>, Recruit.DataAccessLayer.OwnerRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();

            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<ProcessStage>, Recruit.BusinessAccessLayer.ProcessStageService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork, Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<ProcessStage>, Recruit.DataAccessLayer.ProcessStageRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();

            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<ProcessStatus>, Recruit.BusinessAccessLayer.ProcessStatusService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork, Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<ProcessStatus>, Recruit.DataAccessLayer.ProcessStatusRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();

            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<Source>, Recruit.BusinessAccessLayer.SourceService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork, Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<Source>, Recruit.DataAccessLayer.SourceRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();
           
            services.AddSingleton<Recruit.BusinessAccessLayer.Interface.IService<Vacancy>, Recruit.BusinessAccessLayer.VacancyService>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IUnitOfWork, Recruit.DataAccessLayer.UnitOfWork>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IGenericRepository<Vacancy>, Recruit.DataAccessLayer.VacancyRepository>();
            services.AddSingleton<Recruit.DataAccessLayer.Interface.IConnectionFactory, Recruit.DataAccessLayer.ConnectionFactory>();

         

        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
