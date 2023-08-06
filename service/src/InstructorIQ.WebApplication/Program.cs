using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation.AspNetCore;

using InstructorIQ.Core.Converters;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Rewrite;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;
using Serilog.Events;

namespace InstructorIQ.WebApplication;

public static class Program
{
    private const string OutputTemplate = "{Timestamp:HH:mm:ss.fff} [{Level:u1}] {Message:lj}{NewLine}{Exception}";

    public static async Task<int> Main(string[] args)
    {
        // azure home directory
        var homeDirectory = Environment.GetEnvironmentVariable("HOME") ?? ".";
        var logDirectory = Path.Combine(homeDirectory, "LogFiles");

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate: OutputTemplate)
            .WriteTo.File(
                path: $"{logDirectory}/boot.txt",
                rollingInterval: RollingInterval.Day,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1),
                outputTemplate: OutputTemplate,
                retainedFileCountLimit: 10
            )
            .CreateBootstrapLogger();

        try
        {
            Log.Information("Starting web host");

            var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

            builder.Host
                .UseSerilog((context, services, configuration) => configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("ApplicationName", builder.Environment.ApplicationName)
                    .Enrich.WithProperty("EnvironmentName", builder.Environment.EnvironmentName)
                    .WriteTo.Console(outputTemplate: OutputTemplate)
                    .WriteTo.File(
                        path: $"{logDirectory}/log.txt",
                        rollingInterval: RollingInterval.Day,
                        shared: true,
                        flushToDiskInterval: TimeSpan.FromSeconds(1),
                        outputTemplate: OutputTemplate,
                        retainedFileCountLimit: 10
                    )
                    .WriteTo.AzureTableStorage(
                        connectionString: context.Configuration.GetConnectionString("StorageAccount"),
                        propertyColumns: new[] { "SourceContext", "RequestId", "RequestPath", "ConnectionId", "ApplicationName", "EnvironmentName" }
                    )
                );

            ConfigureServices(builder);

            var app = builder.Build();

            ConfigureMiddleware(app);

            await app.RunAsync();

            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
            return 1;
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

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

        services.AddInstructorIQCore();
        services.AddInstructorIQWebApplication();

        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<InstructorIQContext>()
            .AddDefaultTokenProviders();

        services.AddMultitenancy<TenantReadModel, TenantContextResolver>();

        services.AddResponseCaching();

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
            .AddRazorPages()
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageTenantRoute("/Index", false);
                options.Conventions.AddFolderTenantRoute("/Account", false);
                options.Conventions.AddFolderTenantRoute("/Attendance");
                options.Conventions.AddFolderTenantRoute("/Calendar");
                options.Conventions.AddFolderTenantRoute("/Group");
                options.Conventions.AddFolderTenantRoute("/Instructor");
                options.Conventions.AddFolderTenantRoute("/Location");
                options.Conventions.AddFolderTenantRoute("/Member");
                options.Conventions.AddFolderTenantRoute("/Report");
                options.Conventions.AddFolderTenantRoute("/Session");
                options.Conventions.AddFolderTenantRoute("/SignUp");
                options.Conventions.AddFolderTenantRoute("/Topic");
                options.Conventions.AddFolderTenantRoute("/Template");
                options.Conventions.AddFolderTenantRoute("/User", false);
            })
            .AddMvcOptions(options =>
            {
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
            });

        services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        services.AddUrlHelper();

        services.AddAuthorization(options =>
        {
            options.AddPolicy(
                UserPolicies.UserPolicy,
                policy => policy.RequireRole(
                    Core.Data.Constants.Role.GlobalAdministrator,
                    Core.Data.Constants.Role.AdministratorName,
                    Core.Data.Constants.Role.InstructorName,
                    Core.Data.Constants.Role.AttendeeName,
                    Core.Data.Constants.Role.MemberName
                )
            );
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

    }

    private static void ConfigureMiddleware(Microsoft.AspNetCore.Builder.WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        var policyCollection = new HeaderPolicyCollection()
            .AddXssProtectionBlock()
            .AddContentTypeOptionsNoSniff()
            .AddStrictTransportSecurityMaxAge()
            .AddReferrerPolicyStrictOriginWhenCrossOrigin()
            .RemoveServerHeader()
            .AddContentSecurityPolicy(builder =>
            {
                builder.AddObjectSrc().None();
                builder.AddFormAction().Self();
            });

        app.UseSecurityHeaders(policyCollection);

        app.UseResponseCompression();

        app.UseRewriter(new RewriteOptions()
            .Add(new RedirectToNonWwwRule(308))
            .AddRedirectToHttpsPermanent()
        );
        app.UseHttpsRedirection();

        app.UseStaticFiles(new StaticFileOptions
        {
            ContentTypeProvider = new FileExtensionContentTypeProvider
            {
                Mappings =
                {
                    [".webmanifest"] = "application/manifest+json"
                }
            },
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

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseResponseCaching();

        app.UseMultitenancy<TenantReadModel>();

        app.MapRazorPages();
        app.MapControllers();
    }
}
