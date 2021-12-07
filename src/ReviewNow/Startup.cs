using Application;
using Application.Services;
using Auth0.AspNetCore.Authentication;
using AutoMapper;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ReviewNow
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
            // Cookie configuration for HTTP to support cookies with SameSite=None


            // Cookie configuration for HTTPS
            // services.Configure<CookiePolicyOptions>(options =>
            // {
            //    options.MinimumSameSitePolicy = SameSiteMode.None
            // });
            //---auth0Configuration
            services
                .AddAuth0WebAppAuthentication(options => {
                    options.Domain = Configuration["Auth0:dev-kax74vow.us.auth0.com"];
                    options.ClientId = Configuration["Auth0:bj1sn1EwwyjtgceQBxTCCuMzsA2UsnMd"];
                });
            //------------------------
            services.AddControllersWithViews();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

            // Register the Swagger generator, defining 1 or more Swagger documents////to use swager
            services.AddSwaggerGen();
            // conexion databasae
            services.AddDbContext<ReviewNowContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            //dependency injection
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IWrapperPlaceRepository, WrapperPlaceRepository>();
            services.AddScoped<IWrapperStringPathReviewRepository, WraperStringPAthReviewRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IRecomandationService, RecomandationServices>();
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            //aici pt fiecare category
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   //---auth0Configuration
            //app.UseAuthentication();
            //app.UseAuthorization();
            //--------------------
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
