using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Portal.CrossCutting.DependeceInjection;
using Portal.Domain.Configurations;
using Portal.Domain.Models;
using Portal.Infra.Database.Contexts;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Portal.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddDbContext<AppDbContext> (options => {
                options.UseSqlServer (DabaseConnectionConfiguration.ConnectionString,
                    opt => {
                        opt.MaxBatchSize (1000);
                    });

            });

            ConfigureAPIVersioning (services);

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1",
                    new Swashbuckle.AspNetCore.Swagger.Info {
                        Version = "v1",
                            Title = "Portal API",
                    });

                c.AddSecurityDefinition (
                    "Bearer",
                    new ApiKeyScheme {
                        In = "header",
                            Description = "Autenticação baseada em Json Web Token (JWT)",
                            Name = "Authorization",
                            Type = "apiKey",

                    });

                c.AddSecurityRequirement (new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } } });

            });

            ConfigureAuthentication (services);

            RepositoryDependencyInjection.ConfigureServices (services);
            BusinessLogicDependencyInjection.ConfigureServices (services);

            services.AddCors (options => {
                options.AddPolicy ("AllowAll",
                    builder => {
                        builder
                            .AllowAnyOrigin ()
                            .AllowAnyMethod ()
                            .AllowAnyHeader ()
                            .AllowCredentials ();
                    });
            });

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider ApiVersionProvider) {

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }
            app.UseAuthentication ();

            app.UseHttpsRedirection ();

            app.UseCors ("AllowAll");

            app.UseMvc ();
            app.UseApiVersioning ();

            ConfigureSwagger (app, ApiVersionProvider);

            InitializeDatabase (app);
        }

        private static void ConfigureAPIVersioning (IServiceCollection services) {
            services.AddApiVersioning (p => {
                p.DefaultApiVersion = new ApiVersion (1, 0);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer (p => {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });
        }

        private static void ConfigureAuthentication (IServiceCollection services) {
            var signingConfiguration = new SigningConfiguration ();

            services.AddSingleton (signingConfiguration);

            services.AddAuthentication (authOpt => {
                authOpt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOpt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (bearerOptions => {
                bearerOptions.TokenValidationParameters.IssuerSigningKey = signingConfiguration.Key;

                bearerOptions.TokenValidationParameters.ValidAudience = TokenConfiguration.Audience;

                bearerOptions.TokenValidationParameters.ValidIssuer = TokenConfiguration.Issuer;

                bearerOptions.TokenValidationParameters.ValidateIssuerSigningKey = true;

                bearerOptions.TokenValidationParameters.ValidateLifetime = true;

                bearerOptions.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization (auth => {
                auth.AddPolicy ("Bearer", new AuthorizationPolicyBuilder ()
                    .AddAuthenticationSchemes (JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser ().Build ());
            });
        }

        private static void ConfigureSwagger (IApplicationBuilder app, IApiVersionDescriptionProvider provider) {
            app.UseSwagger ();
            app.UseSwaggerUI (options => {
                foreach (var description in provider.ApiVersionDescriptions) {
                    options.SwaggerEndpoint (
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant ());
                }

                options.DocExpansion (DocExpansion.List);
            });
        }

        private void InitializeDatabase (IApplicationBuilder app) {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory> ().CreateScope ()) {
                ///roda as migrations automaticamente quando sobe o projeto
                scope.ServiceProvider.GetRequiredService<AppDbContext> ().Database.EnsureCreated ();
            }
        }
    }
}