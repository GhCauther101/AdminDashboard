using AdminDashboard.API.Remote;
using AdminDashboard.API.Validation;
using AdminDashboard.Entity.Models;
using AdminDashboard.Repository.Context;
using AdminDashboard.Repository.Managers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdminDashboard.API.Extenssion;

public static class ServiceExtenssion
{
    public static void ResolveServiceEndpoints(this IWebHostBuilder webHostBuilder, IConfiguration configuration)
    {
        var firstPort = int.Parse(configuration.GetSection("FirstPort").Value.ToString());
        var secondPort = int.Parse(configuration.GetSection("SecondPort").Value.ToString());
        var certPath = configuration["ASPNETCORE_Kestrel:Certificates:Default:Path"];
        var certPassword = configuration["ASPNETCORE_Kestrel:Certificates:Default:Password"];

        webHostBuilder.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(firstPort, listenOptions =>
            {
                listenOptions.UseHttps(certPath, certPassword);
                listenOptions.Protocols = HttpProtocols.Http2;
            });

            options.ListenAnyIP(secondPort, listenOptions =>
            {
                listenOptions.UseHttps(certPath, certPassword);
                listenOptions.Protocols = HttpProtocols.Http2;
            });

            var cert = new X509Certificate2(certPath, certPassword);

            options.ConfigureHttpsDefaults(h =>
            {
                h.ClientCertificateMode = ClientCertificateMode.AllowCertificate;
                h.CheckCertificateRevocation = false;
                h.ServerCertificate = cert;
            });
        });
    }
    
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins("https://localhost:8000", "https://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
        });
    }

    public static void ConfigureDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        var connectionString = configuration.GetConnectionString("pgConnection");

        services.AddDbContext<IdentityContext>(opts => {
            opts.UseNpgsql(connectionString, b => b.MigrationsAssembly(assemblyName));
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddScoped<DbContextBus>();
        services.AddScoped<RepositoryManager>();
        services.AddScoped<RoleManager<IdentityRole>>();
        services.AddScoped<AuthenticationManager>();
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentityCore<Client>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 10;
            o.User.RequireUniqueEmail = true;
        });

        builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
        builder.AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddCookie().AddJwtBearer(options =>
        {
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Cookies["jwt"];
                    if (!string.IsNullOrEmpty(accessToken))
                        context.Token = accessToken;

                    return Task.CompletedTask;
                }
            };

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = config["JwtSettings:Issuer"],
                ValidAudience = config["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = false,
            };
        });

        services.AddAuthorization();
    }

    public static void AddTransport(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceAddress = configuration.GetSection("CurrencyServiceDefaultLink").Value.ToString().ResolveServiceUrl(configuration);

        services.AddHttpClient("CurrencyServiceTransport", client =>
        {
            client.BaseAddress = new Uri(serviceAddress);
            client.DefaultRequestVersion = new Version(2, 0);
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
        });
    }

    public static void ConfigureRemoteClient(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddTransient<RemoteClient>(builder =>
        {
            var serviceAddress = configuration.GetSection("CurrencyServiceDefaultLink").Value.ToString().ResolveServiceUrl(configuration);
            var httpClientFactory = builder.GetService<IHttpClientFactory>();
            return new RemoteClient(httpClientFactory, serviceAddress);
        });
    }

    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }

    public static void ConfigureModelValidation(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<ValidateModelAttribute>();
        });
        
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
    }

    public static void ConfigureSwaggerGen(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo { Title = "MapZter API", Version = "v1" });
            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Place to add JWT with Bearer",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Name = "Bearer",
                    },
                    new List<string>()
                }
            });
        });
    }

    public static void TryMigrateDatabase(this IServiceProvider serviceProvider, IConfiguration configuration)
    {
        var deployType = configuration.GetSection("DbDeployType").Value.ToString();

        if (deployType.Equals("container"))
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var identityDb = scope.ServiceProvider.GetRequiredService<IdentityContext>();
                identityDb.Database.Migrate();
                identityDb.Database.EnsureCreated();
            }
        }
    }
}