using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Scrutor;
using ShopBridge.Microservices.Product.Api.Controllers;
using ShopBridge.Microservices.Product.Api.Infrastructure.Filters;
using ShopBridge.Microservices.Product.Data;
using ShopBridge.Microservices.Product.DataInterfaces;
using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.ServiceInterfaces;
using ShopBridge.Microservices.Product.Services;
using ShopBridge.Microservices.Product.Services.Infrastructure.Builders.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShopBridge.Microservices.Product.Api
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                })
                //.AddNewtonsoftJson()
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.PropertyNamingPolicy = null;
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedHost;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                  builder => builder
                                             .SetIsOriginAllowed((host) => true)
                                             .AllowAnyMethod()
                                             .AllowAnyHeader()
                                             .AllowCredentials());
            });

            services.AddHttpContextAccessor();

            return services;
        }

        public static IServiceCollection AddCustomDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDatabaseFactory>(sp =>
            {
                return new DatabaseFactory(sp.GetRequiredService<ILogger<IDatabaseFactory>>(), configuration.GetConnectionString("Default"));
            });
            return services;
        }

        public static IServiceCollection AddCustomAssemblies(this IServiceCollection services)
        {
            var types = new List<Type>() {
                typeof(IDatabaseFactory),
                typeof(DatabaseFactory),
                typeof(IProductService),
                typeof(ProductService),
                typeof(ProductController)
            };

            services.Scan(scan => scan
                .FromAssembliesOf(types)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
            services.AddScoped<ApplicationUser>();

            return services;
        }

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoToModelMappingProfile));
            services.AddAutoMapper(typeof(ModelToDtoMappingProfile));
            return services;
        }

        public static IServiceCollection AddCustomAutoWrapper(this IServiceCollection services)
        {

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' token in the text input below.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = IdentityServerAuthenticationDefaults.AuthenticationScheme
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }

        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .AddHealthChecks()
               .AddCheck(
                   "self",
                   () => HealthCheckResult.Healthy("ShopBridge Product microservice is live"),
                   new string[] { "live" })
               .AddSqlServer(configuration.GetConnectionString("Default"));

            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            }).AddIdentityServerAuthentication(options => {
                options.RequireHttpsMetadata = true;
                options.Authority = configuration.GetValue<string>("AuthApi:Host");
                options.ApiName = configuration.GetValue<string>("AuthApi:ApiName");
            });

            return services;
        }
    }

}
