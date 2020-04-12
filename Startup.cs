using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.TelegramBot;
using apc_bot_api.Models.VkBot;
using apc_bot_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;

namespace apc_bot_api
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
            string connect = Configuration["ConnectionStrings:DefaultConnection"];  // Строка для подключения СУБД PostgreSQL

            services
                .AddDbContext<AppDbContext>(options => options.UseNpgsql(connect)); // Подключение к СУБД PostgreSQL

            services
                .AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            // .AddTokenProvider<DataProtectorTokenProvider<AppUser>>("agosproject");

            // services.AddTransient<IRepository, Repository>();
            // services.AddScoped<IService, Service>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                // .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    // options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>            // Параметры для токена
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // строка, представляющая издателя
                        ValidIssuer = Configuration["JwtToken:ISSUER"],
                        // установка потребителя токена
                        ValidAudience = Configuration["JwtToken:AUDIENCE"],
                        ValidateIssuerSigningKey = true,
                        // установка ключа безопасности
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JwtToken:KEY"])),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // VkBotApi Configurations
            services.AddSingleton<IVkApi>(sp =>
            {
                var api = new VkApi();
                api.Authorize(new ApiAuthParams { AccessToken = VkBotApiSettings.AccessToken });
                return api;
            });

            services.AddCors();
            services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "AGoS restAPI", Version = "v1.0" });
            // });
            // Swagger
            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }
            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            // TelegramBot Client and webHook Initializations
            TeleBot.GetBotClientAsync().Wait();    //// Вызов GetAsyns() для инициализации Телеграм бота и Webhook-а

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
