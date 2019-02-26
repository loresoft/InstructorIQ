using System;
using System.IdentityModel.Tokens.Jwt;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Options;
using InstructorIQ.Core.Security;
using InstructorIQ.WebService.Middleware;
using KickStart;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace InstructorIQ.WebService
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

            services.AddCors();

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });


            services.Configure<ApiBehaviorOptions>(o =>
                o.InvalidModelStateResponseFactory = a => new UnprocessableEntityObjectResult(new ErrorModel(a.ModelState))
            );

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .WithMethods(HttpMethods.Get, HttpMethods.Post, HttpMethods.Put, HttpMethods.Delete, HttpMethods.Patch, HttpMethods.Options)
                .AllowCredentials()
                .SetPreflightMaxAge(TimeSpan.FromMinutes(5))
                .WithExposedHeaders("ETag")
            );

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
