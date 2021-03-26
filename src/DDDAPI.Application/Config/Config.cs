using System;
using System.Collections.Generic;
using DDDAPI.Data.Context;
using DDDAPI.Data.MappingDto;
using DDDAPI.Data.Repository;
using DDDAPI.Domain.Security;
using DDDAPI.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace DDDAPI.Application.Dependency
{
    public class Config
    {
        public static void ConfigContext (IServiceCollection services)
        {
            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower())
            {
                services.AddDbContext<ContextDB> (
                    options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"), 
                    new MySqlServerVersion(new Version(8, 0 , 21)),
                        mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
                    )
                );
            }
        }

        public static void ConfigAutoMapper (IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new EntityToDtoProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigRepository (IServiceCollection services)
        {
            services.AddScoped (typeof (CEPRepository<>), typeof (CEPRepository<>));
            services.AddScoped (typeof (ItemRepository<>), typeof (ItemRepository<>));
            services.AddScoped (typeof (LoginRepository<>), typeof (LoginRepository<>));
            services.AddScoped (typeof (MunicipioRepository<>), typeof (MunicipioRepository<>));
            services.AddScoped (typeof (UFRepository<>), typeof (UFRepository<>));
            services.AddScoped (typeof (UsuarioAPIRepository<>), typeof (UsuarioAPIRepository<>));
        }
        
        public static void ConfigServices (IServiceCollection services)
        {
            services.AddTransient<CEPService, CEPService>();
            services.AddTransient<ItemService, ItemService>();
            services.AddTransient<LoginService, LoginService>();
            services.AddTransient<MunicipioService, MunicipioService>();
            services.AddTransient<UFService, UFService>();
            services.AddTransient<UsuarioAPIService, UsuarioAPIService>();
        }

        public static void ConfigToken (IServiceCollection services, IConfiguration Configuration)
        {
            var signingConfiguration = new SigningConfiguration();
            services.AddSingleton(signingConfiguration);

            var tokenConfiguration = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfiguration);
            services.AddSingleton(tokenConfiguration);

            services.AddAuthentication(authOptions => 
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions => {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfiguration.Key;
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidIssuer = tokenConfiguration.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth => {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser().Build());
            });
        }
        
        public static void ConfigSwagger (IServiceCollection services)
        {
            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "API DDDAPI",
                    Description = "API DDDAPI",
                    TermsOfService = new Uri("http://"),
                    Contact = new OpenApiContact {
                        Name = "Development Eliseu Oliveir",
                        Email = "eliseu.dev@outlook.com",
                        Url = new Uri("http://instagram.com/oliveiraeliseu.cs")
                    },
                    License = new OpenApiLicense {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("http://")
                    }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });
        }
    }
}
