using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.Asset;
using LearnerManager.API.Contracts.Category;
using LearnerManager.API.Contracts.Message;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Contracts.SMS;
using LearnerManager.API.Contracts.Twillo;
using LearnerManager.API.Contracts.Users;
using LearnerManager.API.Domain;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Domain.Repository.RepositoryWrapper;
using LearnerManager.API.Services.Asset;
using LearnerManager.API.Services.Category;
using LearnerManager.API.Services.Communications;
using LearnerManager.API.Services.Message;
using LearnerManager.API.Services.Sms;
using LearnerManager.API.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Twilio.Clients;

namespace LearnerManager.API.Helpers
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", //change this to website(s) in production :( Please
                        builder => builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
                }
            );
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITwilioService, TwilioService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IAssetService, AssetService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }

        public static void ConfigureSQLServer(this IServiceCollection services, IConfiguration config)
        {
            var _appSettingSection = config.GetSection("sqlserverconnection");
            services.Configure<AppSettings>(_appSettingSection);
            var _appSetting = _appSettingSection.Get<AppSettings>();
            var _connectionString = _appSetting.connectionString;
            if (_connectionString != null)
                services.AddDbContext<RepositoryContext>(
                    options => options.UseSqlServer(_connectionString),
                    ServiceLifetime.Scoped
                );
        }

        public static void ConfigureJWTAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var appSettingsSection = config.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        public static void ConfigureUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<RepositoryContext>();
        }

        public static void ConfigureTwilio(this IServiceCollection services)
        {
            services.AddHttpClient<ITwilioRestClient, CustomTwilioClient>(client =>
                client.DefaultRequestHeaders.Add("X-Custom-Header", "HttpClientFactory-Sample"));   
        }
    }
}
