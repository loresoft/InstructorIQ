using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Options;
using InstructorIQ.Core.Security;
using InstructorIQ.Web.Middleware;
using KickStart;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace InstructorIQ.Web
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
            services.KickStart(c => c
                .IncludeAssemblyFor<ConfigurationServiceModule>()
                .IncludeAssemblyFor<Startup>()
                .Data(ConfigurationServiceModule.ConfigurationKey, Configuration)
                .Data("hostProcess", "web")
                .UseAutoMapper()
                .UseStartupTask()
            );

            var provider = services.BuildServiceProvider();
            var principalOptions = provider.GetService<IOptions<PrincipalConfiguration>>();
            var hostingOptions = provider.GetService<IOptions<HostingConfiguration>>();

            // disable claim mapping
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            var key = Base64UrlTextEncoder.Decode(principalOptions.Value.AudienceSecret);
            var securityKey = new SymmetricSecurityKey(key);

            var validationParameters = new TokenValidationParameters
            {
                NameClaimType = TokenConstants.Claims.Name,
                RoleClaimType = TokenConstants.Claims.Role,

                ValidIssuer = hostingOptions.Value.ClientDomain,
                ValidAudience = principalOptions.Value.AudienceId,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
            };


            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = validationParameters;
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;

                });


            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Authorization format : Bearer {token}",
                    Name = "Authorization",
                    In = "header"
                });

                c.SwaggerDoc("v1", new Info { Title = "InstructorIQ API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .SetPreflightMaxAge(TimeSpan.FromMinutes(5))
                    .WithExposedHeaders("ETag")
                );
            });

            services
                .AddMvc()
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            app.UseMiddleware<JsonExceptionMiddleware>();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InstructorIQ API");
            });

            app.UseMvc();
        }
    }
}
