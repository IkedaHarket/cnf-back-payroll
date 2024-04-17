using Backend.ProyectName.API.Bootstrapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Backend.ProyectName.API
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
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("es-CL");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("es-CL") };
                options.RequestCultureProviders = new List<IRequestCultureProvider>();
            });

            var cultureInfo = new CultureInfo("es-CL");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            services.AddControllers();

            //services.AddTokenAuthentication(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.RegisterApplicationExtension();
            services.RegisterInfraestructureExtension(Configuration);

            //services.AddMediatR(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = $"Backend.ProyectName.API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.CustomSchemaIds(type => type.ToString());
                c.IncludeXmlComments(xmlPath);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Cabecera de autorización utilizando el esquema Bearer. \r\n\r\n Ingrese 'Bearer' [espacio] y luego el token en el campo de ingreso abajo.\r\n\r\nEjemplo: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            });

            services.RegisterRepositoryExtension(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            string pathBase = Configuration["API_BASE_PATH"];
            logger.LogInformation($"PATH BASE = {pathBase}");

            if (!string.IsNullOrWhiteSpace(pathBase)) app.UsePathBase($"/{pathBase.TrimStart('/')}");
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint($"{pathBase}/swagger/v1/swagger.json", "Backend.ProyectName.API v1"));
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}