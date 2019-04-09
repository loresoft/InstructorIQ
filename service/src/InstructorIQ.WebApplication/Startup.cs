using System;
using System.Linq;
using Exceptionless;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.SqlServer;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Options;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Security;
using KickStart;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace InstructorIQ.WebApplication
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
            services.KickStart(c => c
                .IncludeAssemblyFor<ConfigurationServiceModule>()
                .IncludeAssemblyFor<Startup>()
                .Data(ConfigurationServiceModule.ConfigurationKey, Configuration)
                .Data("hostProcess", "web")
                .UseAutoMapper()
                .UseStartupTask()
            );

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".InstructorIQ.Authentication";
                options.SlidingExpiration = true;
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });


            services.AddMemoryCache();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<InstructorIQContext>()
                .AddDefaultTokenProviders();

            services.AddMultitenancy<TenantReadModel, TenantContextResolver>();

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    "font/woff2",
                    "image/svg+xml"
                });
                options.EnableForHttps = true;
            });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageTenantRoute("/Index", false);
                    options.Conventions.AddFolderTenantRoute("/Account", false);
                    options.Conventions.AddFolderTenantRoute("/Calendar");
                    options.Conventions.AddFolderTenantRoute("/Group");
                    options.Conventions.AddFolderTenantRoute("/Instructor");
                    options.Conventions.AddFolderTenantRoute("/Location");
                    options.Conventions.AddFolderTenantRoute("/Member");
                    options.Conventions.AddFolderTenantRoute("/Session");
                    options.Conventions.AddFolderTenantRoute("/Topic");
                    options.Conventions.AddFolderTenantRoute("/Template");
                    options.Conventions.AddFolderTenantRoute("/User");
                })
                .AddFluentValidation();

            services.AddUrlHelper();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    UserPolicies.InstructorPolicy,
                    policy => policy.RequireRole(
                        Core.Data.Constants.Role.GlobalAdministrator,
                        Core.Data.Constants.Role.AdministratorName,
                        Core.Data.Constants.Role.InstructorName
                    )
                );
                options.AddPolicy(
                    UserPolicies.AdministratorPolicy,
                    policy => policy.RequireRole(
                        Core.Data.Constants.Role.GlobalAdministrator,
                        Core.Data.Constants.Role.AdministratorName
                    )
                );
                options.AddPolicy(
                    UserPolicies.GlobalAdministratorPolicy,
                    policy => policy.RequireRole(
                        Core.Data.Constants.Role.GlobalAdministrator
                    )
                );
            });

            // hangfire options
            services.TryAddSingleton(new SqlServerStorageOptions());

            var connectionString = Configuration.GetConnectionString("InstructorIQ");
            services.AddHangfire((provider, configuration) => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseSqlServerStorage(
                    connectionString,
                    provider.GetRequiredService<SqlServerStorageOptions>())
                );

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            var options = app.ApplicationServices.GetService<IOptions<HostingConfiguration>>();

            app.UseExceptionless(options.Value.ExceptionlessKey);
            app.UseSecurityHeaders();
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(365)
                    };
                }
            });

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[] { new DashboardAuthorization() }
            });


            app.UseMultitenancy<TenantReadModel>();

            app.UseMvc();

        }
    }
}
