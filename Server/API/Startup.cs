using AutoMapper;
using API.Filters;
using Data.Context;
using Repository.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using API.IHelpers;
using API.Helpers;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Repository.IRepository;
using Repository.Repository;
using System.IO;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();        
            services.AddTransient<IJWTManager, JWTManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IWaitingRepository, WaitingRepository>();
            services.AddScoped<ISpendingRepository, SpendingRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<ISpendingRepository, SpendingRepository>();
            services.AddScoped<ICheckingRepository, CheckingRepository>();
            services.AddScoped<IFrequencyRepository, FrequencyRepository>();
            services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
            services.AddScoped<ISupplyItemRepository, SupplyItemRepository>();
            services.AddScoped<IMedicineTypeRepository, MedicineTypeRepository>();
            services.AddScoped<ICheckingItemRepository, CheckingItemRepository>();
            services.AddScoped<ICheckingTestRepository, CheckingTestRepository>();
            services.AddScoped<ICheckingMedicineRepository, CheckingMedicineRepository>();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add(typeof(ValidationFilter));
                }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())

                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                { In = ParameterLocation.Header, Description = "Please insert JWT with Bearer into field", Name = "Authorization", Type = SecuritySchemeType.ApiKey });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, System.Array.Empty<string>() } });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                             .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                         ValidateIssuer = false,
                         ValidateAudience = false
                     };
                 });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())

            using (var context = scope.ServiceProvider.GetService<ApplicationContext>())
                context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(true);
                        }
                    });
                });
            }

  

            //app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                await next().ConfigureAwait(true);

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next().ConfigureAwait(true);
                }

            });

            app.UseStaticFiles();
            app.UseDefaultFiles();


            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
