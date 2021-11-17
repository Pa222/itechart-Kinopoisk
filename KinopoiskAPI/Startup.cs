using Data_Access_Layer;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Repositories;
using Data_Access_Layer.Repositories.Interfaces;
using KinopoiskAPI.Hubs;
using KinopoiskAPI.Services;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.CloudinaryApi;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace KinopoiskAPI
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
            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICloudinaryApi, CloudinaryApi>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IFaqService, FaqService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Iss,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Aud,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddCors();

            services.AddControllers();

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000"));

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/hubs/chat");
            });
        }
    }
}