using EmployeeManagementSystem.Core.IRepository;
using EmployeeManagementSystem.Core.Repository;
using EmployeeManagementSystem.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
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

            services.AddDbContext<EmployeeManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("myConnection")));
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                }
                );
            });

            services.AddSwaggerGen();
            //services.AddControllers();


            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            //  services.AddMvc();
           // services.AddTransient<IEmployeeRepository, EmployeeRepository>();
           services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IWorkingHourRepository, WorkingHourRepository>();
            services.AddScoped<IRequestLeaveRepository,RequestLeaveRepository>();
            services.AddScoped<IPaymentRulesRepository, PaymentRulesRepository>();


            // services.AddScoped<EmployeeRepository>();

            //services.AddScoped<EmployeeRepository>(sp => {
            //    DbContextOptionsBuilder<EmployeeManagementDbContext> optsBuilder = new DbContextOptionsBuilder<EmployeeManagementDbContext>();
            //    optsBuilder.UseSqlServer(Configuration.GetConnectionString(("myConnection")));
            //    EmployeeManagementDbContext ctx = new EmployeeManagementDbContext(optsBuilder.Options);
            //    EmployeeRepository svc = new EmployeeRepository(ctx);
            //    return svc;
            //});



            //services.AddSingleton<IEmployeeRepository, EmployeeRepository>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
              {
                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = "localhost",
                      ValidAudience = "localhost",
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwtConfig:Key"])),
                      ClockSkew = TimeSpan.Zero
                  };
              });

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json","v1");
                c.RoutePrefix = "";
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseRouting();


            app.UseCors("AllowOrigin");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
