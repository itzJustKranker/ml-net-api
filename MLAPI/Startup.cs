namespace MLAPI
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services;

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
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"), options =>
                {
                    options.EnableRetryOnFailure();
                });
            });
            services.AddTransient<Seed>();
            services.AddScoped(typeof(IMachineLearningService), typeof(MachineLearningService));
            // Configure CORS
            services.AddCors(
                options => options.AddPolicy(
                    "DefaultCorsPolicy",
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            Configuration["CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            DataContext dbContext,
            Seed seeder)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            // Seed Database if needed
            dbContext.Database.EnsureCreated();
            seeder.SeedIfEmpty().Wait();
            app.UseCors("DefaultCorsPolicy"); // Enable CORS!
            
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action=Index}/{id?}");
            });

            app.UseHttpsRedirection();
        }
    }
}